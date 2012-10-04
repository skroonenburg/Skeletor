namespace Skeletor.Core.Framework
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        object Handle(TCommand command);
    }
}