using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using TicketSystem.data.Enum;
using InterviewQuestion.Data.Enum;

namespace TicketSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }

        public TicketPriority Priority { get; set; }
        public TicketSeverity Severity { get; set; }
        public TicketType Type { get; set; }

        public string? Status { get; set; }

    }
}
