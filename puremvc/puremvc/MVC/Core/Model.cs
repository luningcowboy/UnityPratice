using System;
using System.Collections.Concurrent;
using MVC.Interfaces;

namespace MVC.Core
{
    public class Model : IModel
    {
        public Model(string key)
        {
            multitonKey = key;
            InstanceMap.TryAdd(key, new Lazy<IModel>(this));
            proxyMap = new ConcurrentDictionary<string, IProxy>();
            InitializeModel();
        }

        protected virtual void InitializeModel()
        {
        }

        public static IModel GetInstance(string key, Func<string, IModel> factory)
        {
            return InstanceMap.GetOrAdd(key, new Lazy<IModel>(factory(key)).Value);
        }

        public virtual void RegisterProxy(IProxy proxy)
        {
            proxy.InitializeNotifier(multitonKey);
            proxyMap[proxy.ProxyName] = proxy;
            proxy.OnRegister();
        }

        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return proxyMap.TryGetValue(proxyName, out var proxy) ? proxy : null;
        }

        public virtual IProxy RemoveProxy(string proxyName)
        {
            if(proxyMap.TryRemove(proxyName, out var proxy))
            {
                proxy.OnRemove();
            }
            return proxy;
        }

        public virtual bool HasProxy(string proxyName)
        {
            return proxyMap.ContainsKey(proxyName);
        }

        public static void RemoveModel(stirng key)
        {
            InstanceMap.TryRemove(key, out _);
        }

        protected readonly string multitonKey;

        protected readonly ConcurrentDictionary<string, IProxy> proxyMap;

        protected static readonly ConcurrentDictionary<string, Lazy<IModel>> InstanceMap = new ConcurrentDictionary<string, Lazy<IModel>>();


    }
}
