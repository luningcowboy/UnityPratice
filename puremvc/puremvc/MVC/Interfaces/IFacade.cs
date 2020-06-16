namespace MVC.Interfaces
{
    public interface IFacade: INotifier
    {
        void RegisterProxy(IProxy proxy);

        IProxy RetrieveProxy(string proxyName);
    }
}