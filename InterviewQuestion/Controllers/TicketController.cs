using InterviewQuestion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using TicketSystem.data.Enum;
using TicketSystem.Models;
using InterviewQuestion.ViewModels;
using InterviewQuestion.ViewModle;
using System.Net;
using InterviewQuestion.Data.Enum;
using Microsoft.AspNetCore.Authorization;

namespace InterviewQuestion.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketrepository;

        public TicketController(ITicketRepository ticketRepository)
        {

            _ticketrepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ticket> ticket = await _ticketrepository.GetAll();
            return View(ticket);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Ticket ticket = await _ticketrepository.GetByIdAsync(id);
            return View(ticket);

        }
        [Authorize(Roles = "QA")]
        [HttpGet]
        public IActionResult Create()
        
        {
            
            var createTicketViewModel = new CreateTicketModleView() ;
            return View(createTicketViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketModleView ticket)
        {
            if (ModelState.IsValid)
            {
                

                var tickett = new Ticket
                {
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Summary = ticket.Summary,
                    Priority = ticket.Priority,
                    Severity = ticket.Severity,
                    Type = ticket.Type,
                    Status = "Assigned"



                };
                _ticketrepository.Add(tickett);
                return RedirectToAction("Index");
            }
            

            return View(ticket);
        }
        [Authorize(Roles = "QA")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var ticket = await _ticketrepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return View("error");
            }
            var tickett = new Ticket
            {
                Title = ticket.Title,
                Description = ticket.Description,
                Summary = ticket.Summary,
                Priority = ticket.Priority,
                Severity  = ticket.Severity,
                Type = ticket.Type,
    };
            return View(tickett);

        }

        [Authorize(Roles = "QA")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Ticket");
                return View("Edit", ticket);
            }
            var tickett = new Ticket
            {
                Id = id,
                Title = ticket.Title,
                Description = ticket.Description,

                Summary = ticket.Summary,
                Priority = ticket.Priority,
                Severity = ticket.Severity,
                Type = ticket.Type,
                Status = "Resolved"
                      
                
            };

            _ticketrepository.Update(tickett);

            return RedirectToAction("Index");
        }




        [Authorize(Roles = "RD")]
        [HttpGet]
        public async Task<IActionResult> Resolve(int id)
        {

            var ticket = await _ticketrepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return View("error");
            }
            var tickett = new Ticket
            {
                Title = ticket.Title,
                Description = ticket.Description,
                Summary = ticket.Summary,
                Priority = ticket.Priority,
                Severity = ticket.Severity,
                Type = ticket.Type,
                Status = "Resolve"
            };
            return View(tickett);
        }
        [Authorize(Roles = "RD")]
        [HttpPost]
        public async Task<IActionResult> Resolve(int id, Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to Resolve Ticket");
                return View("Resolve", ticket);
            }
            var tickett = new Ticket
            {
                Id = id,
                Title = ticket.Title,
                Description = ticket.Description,

                Summary = ticket.Summary,
                Priority = ticket.Priority,
                Severity = ticket.Severity,
                Type = ticket.Type,
                Status = "Resolved"

            };

            _ticketrepository.Update(tickett);

            return RedirectToAction("Index");
        }
















    }
}
