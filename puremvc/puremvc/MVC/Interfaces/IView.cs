namespace MVC.Interfaces
{
    public interface IView
    {
        void RegisterObserver(string notificationName, IObserver observer);
        void RemoveObserver(string notificationName, object notifyContent);
        void NotifyObservers(INotification notification);
        void RegisterMediator(IMediator mediator);
        IMediator RetrieveMediator(string mediatorName);
        IMediator RemoveMediator(string mediatorName);
        bool HastMediator(string mediatorName);
    }
}
