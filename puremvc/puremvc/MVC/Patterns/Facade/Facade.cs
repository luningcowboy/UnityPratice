using System;
using MVC.Interfaces;
using MVC.Patterns.Observer;
using System.Collections.Concurrent;

namespace MVC.Patterns.Facade
{
    public class Facade : IFacade
    {
        public Facade(string key)
        {
            InitializeNotifier(key);
            InstanceMap.TryAdd(key, new Lazy<IFacade>(this));
            InitializeFacade();
        }

        public virtual void InitializeFacade()
        {
            InitializeModel();
            InitializeController();
            InitializeView();
        }

        public static IFacade GetInstance(string key, Func<string, IFacade> factory)
        {
            return InstanceMap.GetOrAdd(key, new Lazy<IFacade>(factory(key))).Value;
        }
    }
}
