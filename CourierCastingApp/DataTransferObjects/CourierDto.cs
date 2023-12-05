namespace CourierCastingApp.DataTransferObjects
{
    public record CourierDto(
    int Id,
    string Start,
    string End,
    double Cena,
    double CenaHighPriority,
    bool CzyWeekend,
    int Workload,
    int MaxPackages)
    {
        public CourierDto() : this(2, "", "", 0, 0, false, 0, 5) { }
    }
}
