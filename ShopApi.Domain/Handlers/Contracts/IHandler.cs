using ShopApi.Domain.Commands.Contracts;

namespace ShopApi.Domain.Handlers.Contracts
{
    public interface IHandler <T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}