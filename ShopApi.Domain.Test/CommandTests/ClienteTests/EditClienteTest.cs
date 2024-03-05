using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Test.FakeRepository;
using System;

namespace ShopApi.Domain.Test.CommandTests.ClienteTests
{
    [TestClass]
    public class EditClienteTest
    {
        private readonly ClienteEditCommand _invalidCommand;
        private readonly ClienteEditCommand _validCommand;


        public EditClienteTest()
        {
            // Configurar cenário de teste com um comando inválido
            _invalidCommand = new ClienteEditCommand(Guid.NewGuid(), "", "", "", "", DateTime.Now, "invalid_login", "senha_invalida");

            // Configurar cenário de teste com um comando válido
            _validCommand = new ClienteEditCommand(Guid.NewGuid(), "Cliente Válido", "cliente_valido@gmail.com", "999999999", "98765432109", DateTime.Now, "valid_login", "senha_valida");

        }

        [TestMethod]
        public void ComandoInvalidoNaoEditaCliente()
        {
            _invalidCommand.Validate();
            // Assert: Verificar se o cliente não foi editado
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }

        [TestMethod]
        public void ComandoValidoEditaCliente()
        {
            _validCommand.Validate();
            // Assert: Verificar se o cliente foi editado
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}
