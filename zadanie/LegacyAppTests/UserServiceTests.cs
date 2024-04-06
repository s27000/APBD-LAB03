using LegacyApp;
using System;

namespace LegacyAppTests
{
    class UserServiceTests
    {
        static void Main(string[] args)
        {
            //AddUser_Should_Return_False_When_Missing_FirstName();
            //AddUser_Should_Return_False_When_Missing_SecondName();
        }

        [Fact]
        public void AddUser_Should_Return_False_When_Missing_FirstName()
        {
            var us = new UserService();

            var result = us.AddUser("", "Kowalski", "kowalski@wp.pl", new DateTime(2015, 12, 25), 1);

            Assert.Equal(false, result);
        }

        static void AddUser_Should_Return_False_When_Missing_SecondName()
        {
            var us = new UserService();
            Console.Write(us.AddUser("Karol", "", "kowalski@wp.pl", new DateTime(2015, 12, 25), 1));
        }


    }
}
