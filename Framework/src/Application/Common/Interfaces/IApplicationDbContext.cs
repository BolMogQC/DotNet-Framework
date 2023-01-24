using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    
    public Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
}