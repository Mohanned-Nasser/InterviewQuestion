using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace runGroupWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public int? Age { get; set; }
        public const string QA = "QA";
        public const string RD = "RD";



    }
}
