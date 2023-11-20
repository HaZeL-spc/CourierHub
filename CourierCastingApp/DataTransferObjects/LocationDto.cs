using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.DataTransferObjects;

public class LocationDto
{
    [Display(Name = "Ulica")]
    [Required]
    public string Street { get; set; } = "";
    [Required]
    [Display(Name = "Numer ulicy")]
    public string StreetNumber { get; set; } = "";
    [Required]
    [Display(Name = "Miasto")]
    public string City { get; set; } = "";
    [Required]
    [Display(Name = "Adres pocztowy")]
    public string PostCode { get; set; } = "";
    [Required]
    [Display(Name = "Państwo")]
    public string Country { get; set; } = "";

    public LocationDto(string street, string streetNumber, string city, string postCode, string country)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        PostCode = postCode;
        Country = country;
    }

    public LocationDto()
    {

    }
}
