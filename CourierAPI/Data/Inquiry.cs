using CourierAPI.Helpers;
using CourierAPI.Models;

namespace CourierAPI.Data;

    public record Inquiry
    {
        public Inquiry(InquiryDTO inquiryDTO)
        {
            DimX = inquiryDTO.DimX;
            DimY = inquiryDTO.DimY;
            DimZ = inquiryDTO.DimZ;
            Weight = inquiryDTO.Weight;
            DeliveryDate = inquiryDTO.DeliveryDate;
            Name = inquiryDTO.Name;
            StartLocation = new Location(inquiryDTO.StartLocation);
            EndLocation = new Location(inquiryDTO.EndLocation);
            HightPriority = inquiryDTO.HightPriority;
            Courier = new Courier(inquiryDTO.Courier);
            WeekendDelivery = inquiryDTO.WeekendDelivery;
			InquiryStatus = inquiryDTO.InquiryStatus;
	}

	public Inquiry(double dimX, double dimY, double dimZ, double weight, DateTime deliveryDate, string name, Location? startLocation, Location? endLocation, bool hightPriority, bool weekendDelivery)
	{
		DimX = dimX;
		DimY = dimY;
		DimZ = dimZ;
		Weight = weight;
		DeliveryDate = deliveryDate;
		Name = name;
		StartLocation = startLocation;
		EndLocation = endLocation;
		HightPriority = hightPriority;
		WeekendDelivery = weekendDelivery;
	}

	public Inquiry()
	{
		// Initialize properties with default values
		DimX = 0;
		DimY = 0;
		DimZ = 0;
		Weight = 0;
		HightPriority = false;
		WeekendDelivery = false;
		Name = string.Empty;
		StartLocation = new Location();
		EndLocation = new Location();
	}
	//public Inquiry(double dimX, double dimY, double dimZ, double weightPriority, double weekendDelivery, DateTime delive)

	public double DimX { get; init; }
        public double DimY { get; init; }
        public double DimZ { get; init; }
        public double Weight { get; init; }
        public DateTime DeliveryDate { get; init; }
        public string Name { get; init; } = "";
        public virtual Location? StartLocation { get; init; }
        public virtual Location? EndLocation { get; init; }
        public bool HightPriority { get; init; }
        public bool WeekendDelivery { get; set; }
        public virtual Courier? Courier { get; set; }
        public int Id { get; init; }
        public InquiryStatus InquiryStatus { get; set; } = InquiryStatus.NotConsidered;
    }

    
