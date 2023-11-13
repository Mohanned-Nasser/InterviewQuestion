using Microsoft.EntityFrameworkCore;
using InterviewQuestion.Models;
using System.Collections.Generic;
using System.Diagnostics;   
using System.Net;
using runGroupWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TicketSystem.Models;

namespace runGroupWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }

      

    }
}
