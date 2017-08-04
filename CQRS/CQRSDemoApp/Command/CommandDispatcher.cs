using System;

namespace CQRSDemoApp.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDependencyResolver resolver;

        public CommandDispatcher(IDependencyResolver resolver)
        {
            this.resolver = resolver;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var handler = resolver.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new NullReferenceException("handler not found");

            handler.Execute(command);
        }
    }
}