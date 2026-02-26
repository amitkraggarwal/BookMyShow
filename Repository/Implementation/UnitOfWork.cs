using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

/*
    * UnitOfWork.cs
    * This class implements the Unit of Work pattern, which is used to manage database transactions and coordinate the work of
      multiple repositories. It ensures that all operations within a transaction are completed successfully before committing, 
      and it provides a way to roll back changes if any operation fails.
    * The UnitOfWork class encapsulates the AppDbContext and provides methods for beginning, committing, and rolling back transactions, as well as saving changes to the database. It also exposes the BookingRepository for performing CRUD operations on bookings.
    */

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;
    public IBookingRepository BookingRepository { get; }
    
    public UnitOfWork(AppDbContext context, IBookingRepository bookingRepository)
    {
        _context = context;
        BookingRepository = bookingRepository;
    }


    public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _transaction.CommitAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}