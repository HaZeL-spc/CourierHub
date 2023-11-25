using CourierAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierAPI.Models
{

	public record LocationDTO
	{
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
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string City { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; }
		public LocationDTO()
		{
			Street = "";
			StreetNumber = "";
			City = "";
			PostCode = "";
			Country = "";
		}
	}
}
