namespace MVC.Interfaces
{
    public interface IController
    {
        void ReigisterCommand(string notificationName, Func<ICommand> factory);

        void ExecuteCommand(INotification notification);

        void RemoveCommand(string notificationName);

        bool HasCommand(string notificationName);

    }
}