namespace MVC.Interfaces
{
    public interface IFacade: INotifier
    {
        void RegisterProxy(IProxy proxy);

        IProxy RetrieveProxy(string proxyName);
        IProxy RemoveProxy(string proxyName);
        bool HasProxy(string proxyName);
        void RegisterCommand(string notificationName, Func<ICommand> commandFunc);
        void RemoveCommand(string notificationName);
        bool HasCommand(string notificationName);
        void ReigisterMediator(IMediator mediator);
        IMediator RetrieveMediator(string mediatorName);
        bool HasMediator(string mediatorName);
        void NotifyObservers(INotification notification);
    }
}
