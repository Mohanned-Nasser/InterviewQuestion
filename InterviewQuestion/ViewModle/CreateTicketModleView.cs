using InterviewQuestion.Data.Enum;
using TicketSystem.data.Enum;

namespace InterviewQuestion.ViewModle
{
    public class CreateTicketModleView
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }

        public TicketPriority Priority { get; set; }
        public TicketSeverity Severity { get; set; }
        public TicketType Type { get; set; }

        public string Status { get; set; }

    }
}
