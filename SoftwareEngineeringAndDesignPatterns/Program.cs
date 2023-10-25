using System;

public class User
{
    public string Password { get; set; }
    public virtual void PasswordHash()
    {
       
    }
}

public class AuthorizedUser : User
{
    public bool IsAdmin { get; set; }
    public AuthorizedUser(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
}

public class UserFactory
{
    public static User CreateUser(bool twoFactorRequired, bool isAdmin = false)
    {
        if (twoFactorRequired)
        {
            if (CheckTwoFactorAuthentication())
            {
                return new AuthorizedUser(isAdmin);
            }
            else
            {
                throw new Exception("TwoFactorAuthentication is not valid.");
            }
        }
        else
        {
            return new AuthorizedUser(isAdmin);
        }
    }

    private static bool CheckTwoFactorAuthentication()
    {
        // if else return true or false
        
        return true; 
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            User user1 = UserFactory.CreateUser(true, true); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
