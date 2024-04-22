using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public class AccountManager : IAccountManager
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }   

    public bool RegisterAccount(User account)
    {
        var user = new IdentityUser { UserName = account.Name, Email = account.Email };
        var result = _userManager.CreateAsync(user, account.Password).Result;
        if (result.Succeeded)
        {
            _signInManager.SignInAsync(user, false).Wait();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LoginAccount(User account)
    {
        var result = _signInManager.PasswordSignInAsync(account.Name, account.Password, false, false).Result;
        if (result.Succeeded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LogoutAccount()
    {
        _signInManager.SignOutAsync().Wait();
        return true;
    }

    public List<User> GetAccounts()
    {
        return _userManager.Users.Select(u => new User { Name = u.UserName, Email = u.Email }).ToList(); 
    }

    public bool VerifyAccount(User account)
    {
        User user = _context.Users.FirstOrDefault(u => u.Name == account.Name 
        && u.Password == account.Password);

        if (user != null)
        {
            CurrentUser = user;
            Console.WriteLine("Account verified");
            Logger(user);
            user.IsVerified = true;
            return true;
        }
        else
        {
            Console.WriteLine("Account not verified");
            user.IsVerified = false;
            return false;
        }
    }

    private static void Logger(User account)
    {
        string logMessage = $"{account.Name}, {account.Password}, {DateTime.Now}\n";
        File.AppendAllText("ActionLog.csv", logMessage);
    }
}   