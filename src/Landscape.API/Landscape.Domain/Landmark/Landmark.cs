using Landscape.Domain.Abstractions;

namespace Landscape.Domain.Landmark;

public sealed class Landmark : Entity
{
    public Landmark(Guid id, Name name, Description description, Coordinate coordinate, Address address) : base(id)
    {
        Name = name;
        Description = description;
       
        Coordinate = coordinate;
        Address = address;
    }

    public Landmark()
    {
        
    }
    public Name Name { get; private set; }
    
    public Address Address { get; private set; }
    
    public Description Description { get; private set; }
    
    public Coordinate Coordinate { get; private set; }
}

public record Name(string Value);
public record Description (string Value);
public record State(string Value);
public record Park(string Value);
