
using InterviewQuestion.Data;
using Microsoft.AspNetCore.Identity;
using runGroupWebApp.Data;
using runGroupWebApp.Models;
using TicketSystem.data.Enum;
using TicketSystem.Models;

namespace RunGroopWebApp.Data
{
    public class Seed
    {
       

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Tickets.Any())
                {
                    context.Tickets.AddRange(new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Title = "Ticket 1",

                            Description = "This is the description of the first Ticket",
                            Priority = TicketPriority.Critical,
                            Summary = "First Summary",
                            Severity = TicketSeverity.Level3,
                            Type = TicketType.Bug
                         },
                         new Ticket()
                        {
                            Title = "Ticket 2",

                            Description = "This is the description of the second Ticket",
                            Priority = TicketPriority.Low,
                            Summary = "First Summary",
                            Severity = TicketSeverity.Level3,
                            Type = TicketType.Bug
                         },
                         new Ticket()
                        {
                            Title = "Ticket 3",

                            Description = "This is the description of the third Ticket",
                            Priority = TicketPriority.High,
                            Summary = "third Summary",
                            Severity = TicketSeverity.Level1,
                            Type = TicketType.Bug
                         },
                         new Ticket()
                        {
                            Title = "Ticket 4",

                            Description = "This is the description of the first Ticket",
                            Priority = TicketPriority.Medium,
                            Summary = "fourth Summary",
                            Severity = TicketSeverity.Level3,
                            Type = TicketType.Bug
                         },
                    });
                    context.SaveChanges();
                }

            }



        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.QA))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.QA));
                if (!await roleManager.RoleExistsAsync(UserRoles.RD))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.RD));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.QA);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.RD);
                }
            }
        }


    }
}