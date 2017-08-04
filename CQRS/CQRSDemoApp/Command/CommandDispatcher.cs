using System;

namespace CQRSDemoApp.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var resolver = Resolver.Bootstrap();
            if (command == null)
                throw new ArgumentNullException("command");

            var handler = resolver.GetInstance<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new NullReferenceException("handler not found");

            handler.Execute(command);
        }
    }
}