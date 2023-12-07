using System;
using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.Models.Forms
{
    public class InquiryFormModel
    {
        [Required(ErrorMessage = "Please enter the value for DimX.")]
        public double DimX { get; set; }

        [Required(ErrorMessage = "Please enter the value for DimY.")]
        public double DimY { get; set; }

        [Required(ErrorMessage = "Please enter the value for DimZ.")]
        public double DimZ { get; set; }

        [Required(ErrorMessage = "Please enter the weight.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Please select a delivery date.")]
        public DateOnly DeliveryDate { get; set; }

		[Required(ErrorMessage = "Please select a delivery time.")]
		public TimeOnly DeliveryTime { get; set; }

		[Required(ErrorMessage = "Please enter the name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please select whether it's high priority.")]
        public bool HighPriority { get; set; }

        [Required(ErrorMessage = "Please select whether it's a weekend delivery.")]
        public bool WeekendDelivery { get; set; }

        public LocationFormModel StartLocation { get; set; }
        public LocationFormModel EndLocation { get; set; }
    }
}
