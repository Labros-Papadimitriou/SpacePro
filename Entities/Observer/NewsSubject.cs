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
        private readonly List<INewsListener> _newsListeners;

        public NewsSubject(List<INewsListener> newsListeners)
        {
            _newsListeners = newsListeners;
        }

        private void Notify(Newsletter newsletter)
        {
            foreach (var newslistener in _newsListeners)
            {
                newslistener.Update(newsletter);
            }
        }

        public void AttachListener(INewsListener listener)
        {
            _newsListeners.Add(listener);
        }
        public void DetachListener(INewsListener listener)
        {
            _newsListeners.Remove(listener);
        }

        public void AddNewsletter(Newsletter newsletter)
        {
            Notify(newsletter);
        }
      

    }
}
