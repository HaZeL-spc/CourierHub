using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Data
{
    public class SessionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public SessionHistory(int id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }

        public SessionHistory(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }
}
