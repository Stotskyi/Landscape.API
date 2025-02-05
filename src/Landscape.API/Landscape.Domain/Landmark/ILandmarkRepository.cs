namespace Landscape.Domain.Landmark;

public interface ILandmarkRepository
{
    Task<Landmark?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}