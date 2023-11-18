﻿using System.Diagnostics.CodeAnalysis;

namespace CourierAPI.Models
{
    public class InquiryDTO
    {
        [SetsRequiredMembers]
        public InquiryDTO(
            double dimX, double dimY, double dimZ, double weight,
            DateOnly deliveryDate,
            LocationDTO startLocation, LocationDTO endLocation,
            bool hightPriority, bool weekendDelivery,
            int id = -1
            )
        {
            DimX = dimX; DimY = dimY; DimZ = dimZ;
            Weight = weight;
            DeliveryDate = deliveryDate;
            StartLocation = startLocation;
            EndLocation = endLocation;
            HightPriority = hightPriority;
            WeekendDelivery = weekendDelivery;
            if (id != -1)
                Id = id;
        }

        public required double DimX { get; set; }
        public required double DimY { get; set; }
        public required double DimZ { get; set; }
        public required double Weight { get; set; }
        public required DateOnly DeliveryDate { get; set; }
        public required LocationDTO StartLocation { get; set; }
        public required LocationDTO EndLocation { get; set; }
        public required bool HightPriority { get; set; }
        public required bool WeekendDelivery { get; set; }
        public int Id { get; set; }
    }
}