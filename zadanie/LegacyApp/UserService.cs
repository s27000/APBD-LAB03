using System;

namespace LegacyApp
{
   public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;

        private const int minAge = 21;
        private const int minUserCreditLimit = 500;
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
            var client = _clientRepository.GetById(clientId);
            try
            {
                DataVerifier.VerifyAge(dateOfBirth, minAge);
                User user = new User(client, dateOfBirth, email, firstName, lastName);
                SetUserCreditLimit(client, user);
                UserDataAccess.AddUser(user);
            }
            catch(InvalidDataException)
            {
                return false;
            }
            return true;
        }

        internal void SetUserCreditLimit(Client client, User user)
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
            if (user.HasCreditLimit)
            {
                DataVerifier.VerifyCreditLimit(user.CreditLimit, minUserCreditLimit);
            }
        }
    }
}
