using LegacyApp;
using System;

namespace LegacyAppTest
{
    [TestClass]
    public class LegacyAppTest
    {
        [TestMethod]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            var service = new UserService();

            var result = service.AddUser("", "Kowalski", "kowalski@wp.pl", new DateTime(2001, 10, 25), 1);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddUser_Should_Return_False_When_Missing_SecondName()
        {
            var service = new UserService();

            var result = service.AddUser("Karol", "", "kowalski@wp.pl", new DateTime(2001, 10, 25), 1);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddUser_Should_Return_False_If_Email_Is_Incorrect()
        {
            var service = new UserService();

            var result = service.AddUser("Karol", "Kowalski", "kowalskiwp.pl", new DateTime(2001, 10, 25), 1);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddUser_Should_Return_False_If_Age_is_too_small()
        {
            var service = new UserService();

            var result = service.AddUser("Karol", "Kowalski", "kowalskiwp.pl", new DateTime(2020, 10, 25), 1);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddUser_Should_Return_False_If_CreditLimit_is_too_small()
        {
            var service = new UserService();

            var result = service.AddUser("Karol", "Kowalski", "kowalski@wp.pl", new DateTime(2001, 10, 25), 1);

            Assert.AreEqual(false, result);
        }
    }
}