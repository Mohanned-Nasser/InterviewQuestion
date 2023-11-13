using TicketSystem.Models;

namespace InterviewQuestion.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetByIdAsync(int id);

       
        bool Add(Ticket club);
        bool Delete(Ticket club);
        bool Update(Ticket club);

        bool Save();

    }
}
