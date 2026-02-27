public interface IUserService
{
    User CreateUser(User user);
    User GetUserById(int userId);
    User GetUserByEmail(string email);    
   
}