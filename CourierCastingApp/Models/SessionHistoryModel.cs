using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models
{
    public class SessionHistoryModel
    {
        public int Id { get; set; }
        public required DateTime Timestamp { get; set; }


        [SetsRequiredMembers]
        public SessionHistoryModel(int id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }
    }
}
