using Landscape.Application.Exceptions;
using Landscape.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Landscape.Infrastructure;

public sealed  class ApplicationDbContext :DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }
}