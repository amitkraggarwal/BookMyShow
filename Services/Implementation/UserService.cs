public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(User user)

    {
        if (string.IsNullOrEmpty(user.name) || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password))
        {
            throw new InvalidOperationException("User name, email, and password cannot be null or empty.");
        }

        if (_userRepository.GetUserByEmail(user.email) != null)
        {
            throw new UserExistsException("A user with the same email already exists.");
        }
       
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);
        user.password = hashedPassword;

        return _userRepository.CreateUser(user);
    }

    public User GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }


}