using MVC.Interfaces;
using MVC.Patterns.Observer;

namespace MVC.Patterns.Porxy
{
    public class Proxy: Notifier, IProxy
    {
        public const string NAME = "Proxy";

        public Proxy(string proxyName, object data = null)
        {
            ProxyName = proxyName ?? Name;
            if(data != null) Data = data;
        }

        public virtual void OnRegister()
        {
        }

        public string ProxyName{get; protected set;}

        public object Data {get; set;}
    }
}
