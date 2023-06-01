using parsage_test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace parsage_test.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Bike> Bikes { get; }
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
