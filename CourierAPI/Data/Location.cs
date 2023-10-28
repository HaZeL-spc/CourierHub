using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public class Location
{
    [Key]
    public int Id { get; set; }
    public required string Street { get; set; }
    public required string StreetNumber { get; set; }
    public required string City { get; set; }
    public required string PostCode { get; set; }
    public required string Country { get; set; }
}
