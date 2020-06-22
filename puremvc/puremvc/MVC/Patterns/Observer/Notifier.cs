using System;
using MVC.Interfaces;

namespace MVC.Patterns.Observer
{
    public class Notifier: INotifier
    {
        public virtual void SendNotification(string notificationName, object body = null, string type = null)
        {
            Facade.SendNotification(notificationName, body, type);
        }

        public void InitializeNotifier(string key)
        {
            MultitonKey = key;
        }

        protected IFacade Facade
        {
            get{
                if (MultitonKey == null) throw new Exception(MULTITON_MSG);
                return Patterns.Facade.Facade.GetInstance(MultitonKey, key => new Facade.Facade(key));
            }
        }

        public string MultitonKey {get; protected set;}

        protected string MULTITON_MSG = "multitonKey for this Notifier not yet initialized";
    }
}
