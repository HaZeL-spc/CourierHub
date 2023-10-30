using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models;

public class LocationModel
{
    [SetsRequiredMembers]
    public LocationModel(string street, string streetNumber, string city, string postCode, string country)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        PostCode = postCode;
        Country = country;
    }   

    public required string Street { get; set; }
    public required string StreetNumber { get; set; }
    public required string City { get; set; }
    public required string PostCode { get; set; }
    public required string Country { get; set; }
}
