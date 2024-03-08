using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApi.Domain.Commands.ClienteCommand;

namespace ShopApi.Domain.Test.CommandTests.ClienteTests
{
    [TestClass]
    public class EditClienteTest
    {
        [TestMethod]
        public void Valid_command_should_edit_client()
        {
            var customerName = "Cliente Editado";
            var email = "editado@gmail.com";
            var phone = "987654321";
            

            var clientId = Guid.NewGuid();
            var userpassword = "123456";
            var userlogin = "editado";

            var command = new ClienteEditCommand(clientId, customerName, email, phone, userlogin, userpassword);

            command.Validate();

            Assert.IsTrue(command.IsValid);

        }

        [TestMethod]
        public void Invalid_command_should_not_edit_client()
        {
            var customerName = "aa";
            var email = "aaa";
            var phone = "aa";
            var clientId = Guid.NewGuid();
            var userPassword = "aa";
            var userLogin = "aa";

            var command = new ClienteEditCommand(
                clientId,
                customerName,
                email,
                phone,
                userLogin,
                userPassword);

            command.Validate();

            Assert.IsFalse(command.IsValid);
        }
    }
}