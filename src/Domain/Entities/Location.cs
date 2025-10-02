namespace Domain.Entities;

public class Location
{
    public long Id { get; set; }

    public string Country { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string? HouseNumber { get; set; }
    public string? ZipCode { get; set; }
    public string? Landmark { get; set; }
    public ICollection<Home> Homes { get; set; } 
}
