using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   
using Microsoft.AspNetCore.Identity;

public class AccountController : ControllerBase
{
    private readonly IAccountManager _accountManager;

    public AccountController(IAccountManager accountManager)
    {
        _accountManager = accountManager;
    }    

    [HttpPost("/api/account/register")]
    public IActionResult Create([FromBody] User account)
    {
        return Ok(_accountManager.RegisterAccount(account)); 
    }   

    [HttpPost("api/account/login")]    
    public IActionResult Login([FromBody] User account)
    {
        return Ok(_accountManager.LoginAccount(account));
    }

    [HttpPost("api/account/logout")]    
    public IActionResult Logout()
    {
        return Ok(_accountManager.LogoutAccount());
    }   

    [HttpPost("api/account")]    
    public List<User> GetAccounts()
    {
        return _accountManager.GetAccounts();
    }   

} 