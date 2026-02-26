using System.Data;

public interface IUnitOfWork : IDisposable
{
  //  IBookingRepository BookingRepository { get; }
    Task BeginTransactionAsync(IsolationLevel isolationLevel );
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> SaveChangesAsync();
    IBookingRepository BookingRepository { get; }
}