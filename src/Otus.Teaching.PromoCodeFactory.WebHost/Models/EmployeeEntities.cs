using System.ComponentModel.DataAnnotations;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class EmployeeEntities
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}