namespace CourierAPI.Models
{
    using global::CourierAPI.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    namespace CourierAPI.Models
    {

        public class LocationModel
        {
            public LocationModel(LocationDTO location)
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
            public LocationModel()
            {
                Street = "";
                StreetNumber = "";
                City = "";
                PostCode = "";
                Country = "";
            }
        }
    }

}
