namespace CQRSDemoApp.Command
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}