using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MVC.Insterfaces;
using MVC.Patterns.Observer;

namespace MVC.Core
{
    public class View: IView
    {
        public View(string key)
        {
            multitonKey = key;
            InstanceMap.TryAdd(key, new Lazy<IView>(this));
            mediatorMap = new ConcurrentDictionary<string, IMediator>();
            observerMap = new ConcurrentDictionary<string, IList<IObserver>>();
            InitializeView();
        }

        protected virtual void InitializeView()
        {}

        public static IView GetInstance(string key, Func<stirng, IView> factory)
        {
            return InstanceMap.GetOrAdd(key, new Lazy<Iview>(factory(key)).Value);
        }

        public virtual void RegisterObserver(string notificationName, IObserver observer)
        {
            if(observerMap.TryGetValue(notificationName, out var observers))
            {
                observers.Add(observer);
            }
            else
            {
                observerMap.TryAdd(notificationName, new List<IObserver>{observer});
            }
        }

        public virtual void NotifyObservers(INotification notification)
        {
            if(observermap.TryGetValue(notification.name, out var observersRef))
            {
                var observers = new List<IObserver>(observersRef);
                foreach(var observer in observers)
                {
                    observer.NotifyObserver(notification);
                }
            }
        }

        public virtual void RemoveObserver(string notificationName, object notifyContext)
        {
            if(observerMap.TryGetValue(notificationName, out var observers))
            {
                for(var i = 0; i < observers.Count; i++)
                {
                    if(observers[i].CompareNotifyContext(notifyContext))
                    {
                        observers.RemoveAt(i);
                        break;
                    }
                }
                if(observers.Count == 0)
                    observerMap.TryRemove(notificationName, out _);
            }
        }
    }

}
