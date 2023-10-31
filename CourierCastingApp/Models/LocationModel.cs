using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models;

public class LocationModel
{
    [Display(Name = "Ulica")]
    public required string Street { get; set; }

    [Display(Name = "Numer ulicy")]
    public required string StreetNumber { get; set; }

    [Display(Name = "Miasto")]
    public required string City { get; set; }

    [Display(Name = "Adres pocztowy")]
    public required string PostCode { get; set; }

    [Display(Name = "Państwo")]
    public required string Country { get; set; }

    [SetsRequiredMembers]
    public LocationModel(string street, string streetNumber, string city, string postCode, string country)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        PostCode = postCode;
        Country = country;
    }
}
