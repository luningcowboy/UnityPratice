namespace MVC.Interfaces
{
    public interface IObserver
    {
        Action<INotification> NotifyMethod{set;}
        object NotifyContext {set;}
        void NotifyObserve(INotification notification);
        bool CompareNotifyContext(object obj);
    }
}
