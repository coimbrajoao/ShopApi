using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Flunt.Notifications;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Handlers;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Enums;

namespace ShopApi.Tests.Handlers
{
    [TestClass]
    public class ClienteHandlerTests
    {
        // [TestMethod]
        // public void Handle_ValidCreateCommand_ReturnsSuccessResult()
        // {
        //     // Arrange
        //     var mockClienteRepository = new Mock<IClienteRepository>();
        //     var mockUsuarioRepository = new Mock<IUsuario>();
        //     var handler = new ClienteHandler(mockClienteRepository.Object, mockUsuarioRepository.Object);
        //     var command = new ClienteCreateCommand
        //     {
        //         Nome = "John Doe",
        //         Email = "john@example.com",
        //         Telefone = "123456789",
        //         CPF = "123.456.789-00",
        //         DataNascimento = DateTime.Now,
        //         Login = "johndoe",
        //         Senha = "password"
        //     };

        //     // Act
        //     var result = handler.Handle(command) as GenericCommandResult;

        //     // Assert
        //     Assert.IsNotNull(result);
        //     Assert.IsTrue(result.Success);
        //     Assert.AreEqual("Client created", result.Message);
        //     Assert.IsNotNull(result.Data);
        //     Assert.IsInstanceOfType(result.Data, typeof(ClienteCreateCommand));

        //     // Verificar se os métodos de repositório foram chamados
        //     mockUsuarioRepository.Verify(r => r.Create(It.IsAny<Usuario>()), Times.Once);
        //     mockClienteRepository.Verify(r => r.Create(It.IsAny<Cliente>()), Times.Once);
        // }

        [TestMethod]
        public void Handle_ValidEditCommand_ReturnsSuccessResult()
        {
            // Arrange
            var mockClienteRepository = new Mock<IClienteRepository>();
            var mockUsuarioRepository = new Mock<IUsuario>();
            var handler = new ClienteHandler(mockClienteRepository.Object, mockUsuarioRepository.Object);
            var existingCliente = new Cliente("John Doe", "john@example.com", "123456789", "123.456.789-00", DateTime.Now, ETipoAcesso.Cliente);
             mockClienteRepository.Setup(r => r.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(existingCliente);
            var command = new ClienteEditCommand
            {
                Id = Guid.NewGuid(),
                Nome = "John Doe",
                Email = "john@example.com",
                Telefone = "987654321"
            };

            // Act
            var result = handler.Handle(command) as GenericCommandResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Cliente atualizado com sucesso", result.Message);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(ClienteEditCommand));

            // Verificar se o método de repositório foi chamado
            mockClienteRepository.Verify(r => r.Update(existingCliente), Times.Once);
        }

        // Adicione mais testes conforme necessário para cobrir outros cenários.
    }
}
