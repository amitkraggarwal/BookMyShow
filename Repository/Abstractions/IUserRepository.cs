public interface IUserRepository
{
    // CRUD operations for User entity
    User CreateUser(User user);
    User GetUserById(int userId);
    User GetUserByEmail(string email);
}