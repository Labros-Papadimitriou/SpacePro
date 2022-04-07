using Entities.BroadClasses;
using Entities.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class NewsListener : INewsListener
    {
        public int NewsListenerId { get; set; }
        public string UserId { get; set; }

        public void Update(Newsletter newsletter)
        {
            throw new NotImplementedException();
        }
    }
}
