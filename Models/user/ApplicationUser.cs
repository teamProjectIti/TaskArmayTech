using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Models.user
{
    public class ApplicationUser  
    {
        [Display(Name = "User Name")]
        public string Name { get; set; }
        public string City { get; set; }
    }
}
