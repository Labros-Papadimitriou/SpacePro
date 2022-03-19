using Entities.IdentityUsers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Controllers.HelperClasses
{
    public class ApplicationUserHelper
    {
        #region SubOfTheMonth
        public ApplicationUser GetSubOfTheMonth(Persistance_UnitOfWork.IUnitOfWork unitOfWork)
        {
            var subs = GetSubscribers(unitOfWork);
            var count = subs.Count();
            if (IsLastDay(DateTime.Now) && !IsSubCountZero(count))
            {
                var randomIndex = GetRandomIndex(count);
                var winner = GetWinner(subs, randomIndex);
                return winner;
            }
            return null;
        }

        public bool IsLastDay(DateTime date) => date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        public bool IsSubCountZero(int count) => count == 0;
        public ApplicationUser GetWinner(IEnumerable<ApplicationUser> subs, int randomIndex)
        {
            return subs.Where((x, i) => i == randomIndex).FirstOrDefault();
        }
        public int GetRandomIndex(int count)
        {
            Random random = new Random();
            return random.Next(count);
        }
        //this requires finding the roles name to string in order to work
        public IEnumerable<ApplicationUser> GetSubscribers(Persistance_UnitOfWork.IUnitOfWork unitOfWork)
        {
            return unitOfWork.ApplicationUsers.GetAll().Where(x=>x.Roles.Any(s=>s.Equals("Subscriber")));
        }
        #endregion

        #region AuthorOfTheMonth
        public ApplicationUser GetAuthorOfTheMonth(Persistance_UnitOfWork.IUnitOfWork unitOfWork)
        {
            var authors = GetAuthors(unitOfWork);
            if (IsLastDay(DateTime.Now)&&IsSubCountZero(authors.Count()))
            {
                return GetAuthorWithMostLikes(authors);
            }
            return null;
        }
        public IEnumerable<ApplicationUser> GetAuthors(Persistance_UnitOfWork.IUnitOfWork unitOfWork)
        {
            return unitOfWork.ApplicationUsers.GetAll().Where(x => x.Roles.Any(s => s.Equals("Author")));
        }
        public ApplicationUser GetAuthorWithMostLikes(IEnumerable<ApplicationUser> authors)
        {
            return authors.Select(x=>new {auth=x, likes=x.UserPosts.OrderByDescending(p=>p.PostLikes).FirstOrDefault()})
                .OrderByDescending(x=>x.likes).FirstOrDefault().auth;
        }
        #endregion
    }
}