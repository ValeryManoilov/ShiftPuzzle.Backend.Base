public interface IAccountManager
{
    bool RegisterAccount(User account);
    bool LoginAccount(User account);
    bool LogoutAccount(); 
    List<User> GetAccounts(); 
}