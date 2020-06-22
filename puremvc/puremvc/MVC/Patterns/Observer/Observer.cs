using System;
using MVC.Interfaces;

namespace MVC.Patterns.Observer
{
    public class Observer : IObserver
    {
        public Observer(Action<INotification> notifyMethod, object notifyContext)
        {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }

        public virtual void NotifyObserver(INotification notification)
        {
            NotifyMethod(notification);
        }

        public virtual bool CompareNotifyContext(object obj)
        {
            return NotifyContext.Equals(obj);
        }

        public Action<INotification> NotifyMethod {get; set;}
        public object NotifyContext {get; set;}
    }
}
