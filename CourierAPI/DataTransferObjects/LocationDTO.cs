using CourierAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierAPI.Models
{

    public class LocationDTO
    {
        [SetsRequiredMembers]
        public LocationDTO(int id, string street, string streetNumber, string city, string postCode, string country)
        {
            Id = id;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostCode = postCode;
            Country = country;
        }
        [SetsRequiredMembers]
        public LocationDTO(string street, string streetNumber, string city, string postCode, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostCode = postCode;
            Country = country;
        }
        [SetsRequiredMembers]
        public LocationDTO(Location location)
        {
            Id = location.Id;
            Street = location.Street;
            StreetNumber = location.StreetNumber;
            City = location.City;
            PostCode = location.PostCode;
            Country = location.Country;
        }
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string StreetNumber { get; set; }
        public required string City { get; set; }
        public required string PostCode { get; set; }
        public required string Country { get; set; }
    }
}
