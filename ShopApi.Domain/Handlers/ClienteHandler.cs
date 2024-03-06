using Flunt.Notifications;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;
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
                return new GenericCommandResult(false, "Ops, parece que sua requisição está errada", command.Notifications);
            }
            // Criar o usuário
            var usuario = new Usuario(command.Login, command.Senha);
            _usuarioRepository.Create(usuario);

            // Gerar o cliente
            var Cliente = new Cliente(command.Nome, command.Email, command.Telefone, command.CPF, command.DataNascimento, usuario);

            // Salvar o cliente
            _repository.Create(Cliente);

            // Retornar o resultado
            return new GenericCommandResult(true, "Cliente salvo com sucesso", command);
        }
        public ICommandResult Handle(ClienteEditCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua requisição está errada", command.Notifications);
            }

            var cliente = _repository.GetById(command.Id, command.Nome);
            // Criar o usuário
            var usuario = new Usuario(command.Login, command.Senha);
            _usuarioRepository.Update(usuario);

            // Gerar o cliente
            var Cliente = new Cliente(command.Nome, command.Email, command.Telefone, command.CPF, command.DataNascimento, usuario);

            // Salvar o cliente
            _repository.Update(Cliente);

            // Retornar o resultado
            return new GenericCommandResult(true, "Cliente atualizado com sucesso", command);
        }
    }

}