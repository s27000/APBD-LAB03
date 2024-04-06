using LegacyApp;
using System;

public class DataVerifier
{
	public static void VerifyData(string firstName, string lastName, string email)
	{
        try
        {
            VerifyName(firstName, lastName);
            VerifyEmail(email);
        }catch(InvalidDataException e)
        {
            throw e;
        }
    }

    public static void VerifyName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            throw new InvalidDataException("Incorrect First name or Last name");
        }
    }

    public static void VerifyEmail(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            throw new InvalidDataException("Incorrect email");
        }
    }

    public static void VerifyAge(DateTime dateOfBirth, int ageLimit)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < ageLimit)
        {
            throw new InvalidDataException("Age is smaller than " + ageLimit);
        }
    }

    public static void VerifyCreditLimit(int creditLimit, int minCreditLimit)
    {
        if (creditLimit < minCreditLimit)
        {
            throw new InvalidDataException("Credit limit is smaller than " + minCreditLimit);
        }
    }
}
