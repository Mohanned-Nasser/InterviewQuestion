using InterviewQuestion.Interfaces;
using Microsoft.EntityFrameworkCore;
using runGroupWebApp.Data;
using TicketSystem.Models;

namespace InterviewQuestion.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Ticket ticket)
        {
            _context.Add(ticket);
            return Save();
        }

        public bool Delete(Ticket ticket)
        {
            _context.Remove(ticket);
            return Save();
        }
        public bool Update(Ticket ticket)
        {
            _context.Update(ticket);
            return Save();
        }


        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();

        }
        public async Task<Ticket?> GetByIdAsync(int id)
        {
            // for further developerment we will link the user to the ticket
            //return await _context.Tickets.Include(i => i.CreatedBy).FirstOrDefaultAsync(i => i.Id == id);
            return await _context.Tickets.FirstOrDefaultAsync(i => i.Id == id);
        }
        
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
