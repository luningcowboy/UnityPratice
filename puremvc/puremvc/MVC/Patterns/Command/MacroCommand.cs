using System;
using System.Collections.Generic;
using MVC.Interfaces;
using MVC.Patterns.Observer;

namespace MVC.Patterns.Command
{
    public class MacroCommand : Notifier, ICommand
    {
        public MacroCommand()
        {
            subcommands = new List<Func<ICommand>>();
            InitializeMacroCommand();
        }
        protected virtual void InitializeMacroCommand()
        {
        }
        protected void AddSubCommand(Func<ICommand> factory)
        {
            subcommands.Add(factory);
        }
        public virtual void Execute(INotification notification)
        {
            while(subcommands.Count > 0){
                var factory = subcommands[0];
                commandInstance.InitializeNotifier(MultitonKey);
                commandInstance.Execute(notification);
                subcommands.RemoveAt(0);
            }
        }
        public readonly IList<Func<ICommand>> subcommands;
    }
}
