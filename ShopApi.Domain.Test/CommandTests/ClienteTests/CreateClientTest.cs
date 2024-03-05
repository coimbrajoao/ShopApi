using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Test.CommandTests.ClienteTests
{
    [TestClass]
    public class CreateClientTest
    {

        [TestMethod]
        public void Comando_invalido_nao_cria_cliente()
        {
            var usuario = new Usuario("cliente", "");
            var command = new ClienteCreateCommand("", "", "", "", DateTime.Now, usuario.Login, usuario.Senha);
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }

        [TestMethod]
        public void Comando_Valido_cria_cliente()
        {
            var usuario = new Usuario("cliente", "123456");
            var command = new ClienteCreateCommand("Cliente", "cliente@gmail.com", "999999999", "12345678901", DateTime.Now, usuario.Login, usuario.Senha);
            command.Validate();
            Assert.AreEqual(command.IsValid, true);
        }

    }
}