using CourierCastingApp.Models.Forms;

namespace CourierCastingApp.DataTransferObjects;

public record InquiryDto(
	double DimX,
	double DimY,
	double DimZ,
	double Weight,
	DateTime DeliveryDate,
	string Name,
	LocationDto StartLocation,
	LocationDto EndLocation,
	bool HightPriority,
	bool WeekendDelivery,
    CourierDto Courier,
    int Id
)
{
	// Your custom constructor
	public InquiryDto(InquiryFormModel model, CourierDto courier = null) : this(
	DimX: model.DimX,
	DimY: model.DimY,
	DimZ: model.DimZ,
	Weight: model.Weight,
	DeliveryDate: model.DeliveryDate.ToDateTime(model.DeliveryTime),
	Name: model.Name,
	StartLocation: new LocationDto(model.StartLocation),
	EndLocation: new LocationDto(model.EndLocation),
	HightPriority: model.HighPriority,
	Courier: new CourierDto(),
	WeekendDelivery: model.WeekendDelivery,
	Id: 2
)
	{
		if (courier != null)
            Courier = courier;

		// Additional logic in the constructor if needed
	}

	public InquiryDto() : this(0, 0, 0, 0, DateTime.MinValue, "", new LocationDto(), new LocationDto(), false, false, new CourierDto(), 0)
	{
	}
}












//    public class InquiryDtoe
//    {
//        public InquiryDto(
//            double dimX, double dimY, double dimZ, double weight, 
//            DateOnly deliveryDate, string name,
//            LocationDto startLocation, LocationDto endLocation, 
//            bool hightPriority, bool weekendDelivery, 
//            int id = -1
//            )
//        {
//            DimX = dimX; DimY = dimY; DimZ = dimZ;
//            Weight = weight;
//            DeliveryDate = deliveryDate;
//            StartLocation = startLocation;
//            EndLocation = endLocation;
//            HightPriority = hightPriority;
//            WeekendDelivery = weekendDelivery;
//            Name = name;
//            if (id != -1)
//                Id = id;
//        }

//        public InquiryDto()
//        {

//        }

//        [Required]
//        public double DimX { get; set; }
//        [Required]
//        public double DimY { get; set; }
//        [Required]
//        public double DimZ { get; set; }
//        [Required]
//        public double Weight { get; set; }
//        [Required]
//        public DateOnly DeliveryDate { get; set; }
//        [Required]
//        public string Name { get; set; } = "";
//        [Required]
//        public LocationDto StartLocation { get; set; } = new LocationDto();
//        [Required]
//        public LocationDto EndLocation { get; set; } = new LocationDto();
//        [Required]
//        public bool HightPriority { get; set; }
//        [Required]
//        public bool WeekendDelivery { get; set; }
//        [Required]
//        public int Id { get; set; }
//    }
