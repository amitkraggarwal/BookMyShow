public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User CreateUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User GetUserByEmail(string email)
    {
        return _context.User.FirstOrDefault(u => u.email == email);
    }

    public User GetUserById(int userId)
    {
        return _context.User.Find(userId);
    }


}