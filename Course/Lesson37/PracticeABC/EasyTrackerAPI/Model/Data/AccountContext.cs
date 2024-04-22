using Microsoft.EntityFrameworkCore;

public class AccountContext : DbContext
{
    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
        Console.WriteLine("AccountContext created");
        Database.EnsureCreated();

    }
    

    
}