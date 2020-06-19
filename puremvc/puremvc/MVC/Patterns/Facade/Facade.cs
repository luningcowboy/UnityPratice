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

        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            return view.RetrieveMediator(mediatorName);
        }

        public virtual IMediator RemoveMediator(string mediatorName)
        {
            return view.RemoveMediator(mediatorName);
        }

        public virtual bool HasMediator(string mediatorName)
        {
            return view.HasMediator(mediatorName);
        }

        public virtual void SendNotification(string notificationName, object body = null, string type = null)
        {
            NotifyObservers(new Notification(notificationName, body, type));
        }

        public virtual void NotifyObservers(INotification notification){
            view.NotifyObservers(notification);
        }

        public virtual void InitializeNotifier(string key)
        {
            multitonKey = key;
        }

        public static void HasCore(string key)
        {
            return InstanceMap.TryGetValue(key, out _);
        }

        public static void RemoveCore(string key){
            if(InstanceMap.TryGetValue(key, out _) == false) return;
            Model.RemoveModle(key);
            View.RemoveView(key);
            Controller.RemoveController(key);
            InstanceMap.TryRemove(key, out _);
        }

        protected IController controller;
        protected IModel model;
        protected IView view;
        protected string multitonKey;
        protected static readonly ConcurrentDictionary<string, Lazy<IFacade>> InstanceMap = new ConcurrentDictionary<string, Lazy<IFacade>>();
    }
}
