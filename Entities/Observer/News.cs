using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public class News : NewsSubject
    {
        public News(List<NewsListener> newsListeners) : base(newsListeners)
        {
        }
    }
}
