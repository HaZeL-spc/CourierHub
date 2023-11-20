using CourierCastingApp.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.IO;

namespace CourierCastingApp.ViewModels
{
    public class LocationVm
    {
        [Display(Name = "Ulica")]
        public string Street { get; set; } = "";

        [Display(Name = "Numer ulicy")]
        public string StreetNumber { get; set; } = "";

        [Display(Name = "Miasto")]
        public string City { get; set; } = "";

        [Display(Name = "Adres pocztowy")]
        public string PostCode { get; set; } = "";

        [Display(Name = "Państwo")]
        public string Country { get; set; } = "";

        public LocationVm(string street, string streetNumber, string city, string postCode, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostCode = postCode;
            Country = country;
        }

        public LocationVm() { }

        public LocationVm(LocationDto dto)
        {
            Street = dto.Street;
            StreetNumber = dto.StreetNumber;
            City = dto.City;
            PostCode = dto.PostCode;
            Country = dto.Country;
        }
    }
}
