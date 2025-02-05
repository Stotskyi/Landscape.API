using Landscape.Domain.Abstractions;

namespace Landscape.Domain.Landmark;

public static class LandmarkErrors
{
    public static Error NotFound = new(
        "landmark.NotFound",
        "The landmark with the specified identifier was not found");

}