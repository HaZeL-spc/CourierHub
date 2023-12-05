using CourierAPI.Models;

namespace CourierAPI.Data
{
    public record Courier
    {
        public int Id { get; init; }
        public string Start {  get; set; }
        public string End { get; set; }
        public double Cena {  get; set; }
        public double CenaHighPriority { get; set; }
        public bool CzyWeekend {  get; set; }
        public int Workload { get; set; }
        public int MaxPackages { get; set; }

        public Courier()
        {
            this.Start = "";
            this.End = "";
            this.Cena = 0;
            this.CenaHighPriority = 0;
            this.CzyWeekend = false;
            this.Workload = 0;
            this.MaxPackages = 5;
        }

        public Courier(CourierDTO courierDTO)
        {
            this.Id = courierDTO.Id;
            this.Start = courierDTO.Start;
            this.End = courierDTO.End;
            this.Cena = courierDTO.Cena;
            this.CenaHighPriority = courierDTO.CenaHighPriority;
            this.CzyWeekend = courierDTO.CzyWeekend;
            this.Workload = courierDTO.Workload;
            this.MaxPackages = courierDTO.MaxPackages;
        }
    }
}
