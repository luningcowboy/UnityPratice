namespace MVC.Interfaces
{
    public interface ICommand : INotifier
    {
        void Execute(INotification notification);
    }
}