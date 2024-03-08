using Flunt.Notifications;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Enums;
using ShopApi.Domain.Handlers.Contracts;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Handlers
{
    public class ClienteHandler : Notification,
     IHandler<ClienteCreateCommand>
    {
        private readonly IClienteRepository _repository;
        private readonly IUsuario _usuarioRepository;

        public ClienteHandler(IClienteRepository repository, IUsuario usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;

        }
        public ICommandResult Handle(ClienteCreateCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Invalid request", command.Notifications);
            }
            var eTipoAcesso = ETipoAcesso.Cliente;
            var client = new Cliente(command.Nome, command.Email, command.Telefone, command.CPF, command.DataNascimento, new Usuario(command.Login, command.Senha), eTipoAcesso);

            _usuarioRepository.Create(client.Usuario);
            _repository.Create(client);

            return new GenericCommandResult(true, "Client created", command);
        }

        public ICommandResult Handle(ClienteEditCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua requisição está errada", command.Notifications);
            }

            var cliente = _repository.GetById(command.Id, command.Nome);

            cliente.EditarCliente(command.Email, command.Telefone, command.Nome);
            // Salvar o cliente

            _repository.Update(cliente);

            // Retornar o resultado
            return new GenericCommandResult(true, "Cliente atualizado com sucesso", command);
        }
    }

}