using CourierCastingApp.Models.Forms;
using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.ViewModels
{
	public class InquiryResultVm
	{
		public InquiryFormModel InquiryModel { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }

		// Include CourierViewModel
		public CourierVm[] BestCouriers { get; set; }

		public bool validateInquiryModel()
		{
            // Explicitly validate InquiryModel
            var validationContext = new ValidationContext(InquiryModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(InquiryModel, validationContext, validationResults, validateAllProperties: true);

			return isValid;
        }
	}
}
