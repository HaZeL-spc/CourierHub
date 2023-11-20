﻿using CourierCastingApp.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.ViewModels
{
    public class InquiryVm
    {
        public InquiryVm(InquiryDto dto
            )
        {
            DimX = dto.DimX; DimY = dto.DimY; DimZ = dto.DimZ;
            Weight = dto.Weight;
            DeliveryDate = dto.DeliveryDate;
            StartLocation = new LocationVm(dto.StartLocation);
            EndLocation = new LocationVm(dto.EndLocation);
            HightPriority = dto.HightPriority;
            WeekendDelivery = dto.WeekendDelivery;
            Name = dto.Name;
            if (dto.Id != -1)
                Id = dto.Id;
        }

        public InquiryVm()
        {

        }

        [Display(Name = "Wymiar x")]
        public double DimX { get; set; }
        [Display(Name = "Wymiar y")]
        public double DimY { get; set; }
        [Display(Name = "Wymiar z")]
        public double DimZ { get; set; }
        [Display(Name = "Waga")]
        public double Weight { get; set; }
        [Display(Name = "Termin dostawy")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; } = "";
        [Display(Name = "Adres odbioru")]
        public LocationVm StartLocation { get; set; } = new LocationVm();
        [Display(Name = "Adres dostawy")]
        public LocationVm EndLocation { get; set; } = new LocationVm();
        [Display(Name = "Priorytet")]
        public bool HightPriority { get; set; }
        [Display(Name = "Dostawa w weekend")]
        public bool WeekendDelivery { get; set; }
        [Display(Name = "Id zapytania")]
        public int Id { get; set; }

        public string HightPriorityDisplay()
        {
            return HightPriority ? "Tak" : "Nie";
        }

        public string WeekendDeliveryDisplay()
        {
            return WeekendDelivery ? "Tak" : "Nie";
        }
    }
}