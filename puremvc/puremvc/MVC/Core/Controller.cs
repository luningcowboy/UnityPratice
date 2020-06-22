using System;
using System.Collections.Concurrent;
using MVC.Interfaces;
using MVC.Patterns.Observer;

namespace MVC.Core
{
    public class Controller: IController
    {
        public Controller(string key)
        {
            multitonKey = key;
            InstanceMap.TryAdd(multitonKey, new Lazy<IController>(this));
            commandMap = new ConcurrentDictionary<string, Func<ICommand>>();
            InitializeController();
        }

        protected virtual void InitializeController()
        {
            view = View.GetInstance(multitonKey, key => new View(key));
        }

        public static IController GetInstance(string key, Func<string, IController> factory)
        {
            return InstanceMap.GetOrAdd(key, new Lazy<IController>(factory(key))).Value;
        }
    }
}
