namespace Landscape.Application.Landmark.GetLandmark;

public sealed class LandmarkResponse
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public string State { get; init; }
    
    public string Park { get; init; }
    
    public double Latitude { get; init; }
    
    public double Longitude { get; init; }
}