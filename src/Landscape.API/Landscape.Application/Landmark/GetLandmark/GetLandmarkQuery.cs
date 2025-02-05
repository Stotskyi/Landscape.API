using Landscape.Application.Abstractions.Messaging;

namespace Landscape.Application.Landmark.GetLandmark;

public sealed record GetLandmarkQuery(Guid LandmarkId) : IQuery<LandmarkResponse>
{
}