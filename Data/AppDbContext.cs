using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)    { }

//    public AppDbContext()   {  }
    public DbSet<City> City { get; set; }
    public DbSet<Booking> Booking { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Theatre> Theatre { get; set; }
    public DbSet<Screen> Screen { get; set; }
    public DbSet<Seat> Seat { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Show> Show { get; set; }
    public DbSet<ShowSeatType> ShowSeatType { get; set; }
    public DbSet<ShowFeature> ShowFeature { get; set; }
    public DbSet<ScreenFeature> ScreenFeature { get; set; }
    public DbSet<ShowSeat> ShowSeat { get; set; }
    public DbSet<User> User { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and keys if needed
        base.OnModelCreating(modelBuilder);
    }
}
