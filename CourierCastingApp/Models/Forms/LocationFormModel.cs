using System;
using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.Models.Forms
{
    public class LocationFormModel
    {
        [Required(ErrorMessage = "Please enter the street.")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter the street number.")]
        [Display(Name = "Numer ulicy")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please enter the city.")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the postal code.")]
        [Display(Name = "Adres pocztowy")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Please enter the country.")]
        [Display(Name = "Państwo")]
        public string Country { get; set; }

    }
}

