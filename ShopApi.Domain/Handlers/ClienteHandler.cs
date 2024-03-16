using Flunt.Notifications;
using SecureIdentity.Password;
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

            if (_repository.Exists(c => c.CPF == command.CPF))
            {
                command.AddNotification("CPF", "CPF já cadastrado");
                return new GenericCommandResult(false, "CPF already exists", command.Notifications);
            }

            string Hashshed = PasswordHasher.Hash(command.Senha);
            
            var eTipoAcesso = ETipoAcesso.Cliente;
            var client = new Cliente(command.Nome, command.Email, command.Telefone, command.CPF, command.DataNascimento, eTipoAcesso);
            _repository.Create(client);

            var Usuario = new Usuario(command.Login, Hashshed);
            Usuario.Cliente = client;// Adicionar o cliente ao usuario
            _usuarioRepository.Create(Usuario);

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