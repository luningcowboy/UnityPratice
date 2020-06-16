using MVC.Interfaces;
using MVC.Patterns.Observer;

namespace MVC.Patterns.Command
{
    public class SimpleCommand : Notifier, ICommand
    {
        public virtual void Execute(INotification notification)
        {}
    }
}
