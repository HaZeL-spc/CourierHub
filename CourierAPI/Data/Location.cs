using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

//public record Location
//{
//    public int Id { get; set; }
//    public string Street { get; set; }
//    public string StreetNumber { get; set; }
//    public string City { get; set; }
//    public string PostCode { get; set; }
//    public string Country { get; set; }
//}

public class Location
{
    public Location()
    {
        Street = string.Empty;
        StreetNumber = string.Empty;
        City = string.Empty;
        PostCode = string.Empty;
        Country = string.Empty;
    }

    public Location(int id, string street, string streetNumber, string city, string postCode, string country)
    {
        Id = id;
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        PostCode = postCode;
        Country = country;
    }
    public Location(string street, string streetNumber, string city, string postCode, string country)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        PostCode = postCode;
        Country = country;
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string StreetNumber { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string PostCode { get; set; }
    [Required]
    public string Country { get; set; }
}
