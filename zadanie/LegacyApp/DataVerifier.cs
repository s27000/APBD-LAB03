using System;

public class DataVerifier
{
	public static void verifyData(string firstName, string lastName, string email)
	{
        try
        {
            verifyName(firstName, lastName);
            verifyEmail(email);
        }catch(InvalidDataException e)
        {
            throw e;
        }
    }

    public static void verifyName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            throw new InvalidDataException("Incorrect First name or Last name");
        }
    }

    public static void verifyEmail(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            throw new InvalidDataException("Incorrect email");
        }
    }
}
