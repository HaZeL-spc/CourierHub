using CourierCastingApp.DataTransferObjects;

namespace CourierCastingApp.ViewModels
{
	public class CourierVm
	{
		public int Id { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
		public double Cena { get; set; }
		public double CenaHighPriority { get; set; }
		public bool CzyWeekend { get; set; }
		public int Workload { get; set; }
		public int MaxPackages { get; set; }
		// Other properties as needed...

		public CourierVm(CourierDto courier)
		{
			Id = courier.Id;
			Start = courier.Start;
			End = courier.End;
			Cena = courier.Cena;
			CenaHighPriority = courier.CenaHighPriority;
			CzyWeekend = courier.CzyWeekend;
			Workload = courier.Workload;
			MaxPackages = courier.MaxPackages;
		}

		public CourierVm()
		{
			Id = 0;
			Start = String.Empty;
			End = String.Empty;
			Cena = 0;
			CenaHighPriority = 0;
			CzyWeekend = false;
			Workload = 0;
			MaxPackages = 0;
		}
	}
}
