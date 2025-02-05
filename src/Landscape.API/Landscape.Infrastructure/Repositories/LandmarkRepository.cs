using Landscape.Domain.Landmark;

namespace Landscape.Infrastructure.Repositories;

internal sealed class LandmarkRepository : Repository<Landmark>,ILandmarkRepository
{
    public LandmarkRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}