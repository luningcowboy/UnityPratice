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

        public static void InitializeController()
        {
            controller = Controller.GetInstance(multitonKey, key => new Controller(key));
        }

        public virtual void InitializeModel()
        {
            model = Model.GetInstance(multitonKey, key => new Model(key));
        }

        public virtual void InitializeView()
        {
            view = View.GetInstance(multitonKey, key => new View(key));
        }

        public virtual void RegisterCommand(string notificationName, Func<ICommand> commandFunc)
        {
            controller.RegisterCommand(notificationName, commandFunc);
        }

        public virtual void RemoveCommand(string notificationName)
        {
            controller.RemoveCommand(notificationName);
        }

        public virtual bool HasCommand(string notificationName)
        {
            return controller.HasCommand(notificationName);
        }

        public virtual void RegisterProxy(IProxy proxy)
        {
            model.RegisterProxy(proxy);
        }

        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return model.RetrieveProxy(proxyName);
        }

        public virtual IProxy RemoveProxy(string proxyName)
        {
            return model.RemoveProxy(proxyName);
        }

        public virtual bool HasProxy(string proxyName)
        {
            return model.HasProxy(proxyName);
        }

        public virtual void RegisterMediator(IMediator mediator)
        {
            view.RegisterMediator(mediator);
        }
    }
}
