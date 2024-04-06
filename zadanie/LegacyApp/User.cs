using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User(object client, DateTime dateOfBirth, string emailAdress, string firstName, string lastName)
        {
            try
            {
                DataVerifier.VerifyData(firstName, lastName, emailAdress);
            }catch (InvalidDataException e){
                throw e;
            }
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAdress;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}