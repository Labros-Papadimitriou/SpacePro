using Entities.BroadClasses;
using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public abstract class NewsSubject
    {
        private List<NewsListener> _newsListeners;

        public void AttachRangeListeners(List<NewsListener> listeners)
        {
            _newsListeners.AddRange(listeners);
        }

        public void DetachListener(NewsListener listener)
        {
            _newsListeners.Remove(listener);
        }

        private void Notify(Newsletter newsletter)
        {
            foreach (var newslistener in _newsListeners)
            {
                newslistener.Update(newsletter);
            }
        }

        public void AddNewsletter(Newsletter newsletter)
        {
            Notify(newsletter);
        }
    }
}
