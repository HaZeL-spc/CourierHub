using CourierAPI.Data;

namespace CourierAPI.Models
{
    public record CourierDTO
    {
        public int Id { get; set; }

        public string Start { get; set; }
        public string End { get; set; }

        public double Cena { get; set; }

        public double CenaHighPriority { get; set; }

        public bool CzyWeekend { get; set; }

        public int Workload { get; set; }

        public int MaxPackages { get; set; }

        public CourierDTO() {
            this.Id = 2;
            this.Start = "";
            this.End = "";
            this.Cena = 0;
            this.CenaHighPriority = 0;
            this.CzyWeekend = false;
            this.Workload = 0;
            this.MaxPackages = 5;
        }

        public CourierDTO(Courier courier)
        {
            if (courier is null)
            {
                this.Id = 2;
                this.Start = "";
                this.End = "";
                this.Cena = 0;
                this.CenaHighPriority = 0;
                this.CzyWeekend = false;
                this.Workload = 0;
                this.MaxPackages = 5;
            } else
            {
                this.Id = courier.Id;
                this.Start = courier.Start;
                this.End = courier.End;
                this.Cena = courier.Cena;
                this.CenaHighPriority = courier.CenaHighPriority;
                this.CzyWeekend = courier.CzyWeekend;
                this.Workload = courier.Workload;
                this.MaxPackages = courier.MaxPackages;
            }
        }
    }
}
