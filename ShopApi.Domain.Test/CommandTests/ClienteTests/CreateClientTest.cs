using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Test.CommandTests.ClienteTests
{
    [TestClass]
    public class CreateClientTest
    {

        [TestMethod]
        public void Should_not_create_client_with_invalid_command()
        {
            // Cenário: comando de criação de cliente inválido
            var command = new ClienteCreateCommand("", "", "", "", DateTime.Now, "", "", Enums.ETipoAcesso.Cliente);

            // Ação: validação do comando
            command.Validate();

            // Assertiva: o comando não deve ser válido
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Should_create_valid_client()
        {
            // Cenário: comando de criação de cliente válido
            var clientName = "Cliente";
            var clientEmail = "cliente@gmail.com";
            var clientPhone = "999999999";
            var clientCpf = "12345678901";
            var clientTypeAccess = Enums.ETipoAcesso.Cliente;

            var userName = clientName;
            var userPassword = "123456";

            var command = new ClienteCreateCommand(
                clientName,
                clientEmail,
                clientPhone,
                clientCpf,
                DateTime.Parse("01/01/2000"), // Data de nascimento válida
                userName,
                userPassword,
                clientTypeAccess);

            // Ação: validação do comando
            command.Validate();

            // Assertiva: o comando deve ser válido
            Assert.IsTrue(command.IsValid);
        }


    }
}