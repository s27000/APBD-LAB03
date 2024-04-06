using System;

namespace LegacyApp
{
   public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }
        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            /*
            if(incorrectName(firstName,lastName) || incorrectEmail(email) || insufficentAge(dateOfBirth)){
                return false;
            }
            */

            var client = _clientRepository.GetById(clientId);
            User user;
            try
            {
                user = new User(client, dateOfBirth, email, firstName, lastName);
            }
            catch(InvalidDataException)
            {
                return false;
            }

            updateUserCreditLimit(client, user);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        public bool incorrectName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return true;
            }
            return false;
        }
        
        public bool incorrectEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return true;
            }
            return false;
        }

        public bool insufficentAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return true;
            }
            return false;
        }

        public void updateUserCreditLimit(Client client, User user)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}
