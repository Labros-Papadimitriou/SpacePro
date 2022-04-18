using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyDatabase;
using PayPal.Api;
using Persistance_UnitOfWork;
using SpacePro.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.PaymentControllers
{
    public class PaypalController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public Payment payment;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null && HttpContext == null)
                {
                    return new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                }
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public PaypalController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult PaymentWithPaypal(string price, string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(price,apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception)
            {
                return View("FailureView");
            }
            //setting user role to subscriber on successful payment
            var userId = User.Identity.GetUserId();
            var result = Task.Run(async () => await UserManager.AddToRoleAsync(userId, "Subscriber")).Result;
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment()
            {
                id = paymentId
            };
            return payment.Execute(apiContext, paymentExecution);
        }

        public Payment CreatePayment(string price,APIContext apiContext, string redirectUrl)
        {
            var user = Task.Run(async ()=>await unitOfWork.ApplicationUsers.SingleOrDefault(x=>x.UserName==User.Identity.Name)).Result;
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "SpacePro subscription",
                currency = "USD",
                price = price,
                quantity = "1",
                sku = "sku"
            });   
            var payer = new Payer()
            {
                payment_method = "paypal",
                payer_info = new PayerInfo() 
                { 
                    first_name=user.FirstName,
                    last_name=user.LastName
                }
                
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = price
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = price, // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "SpacePro Subscription purchace",
                invoice_number = new Random().Next(100000).ToString(), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return payment.Create(apiContext);
        }
    }
}