
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        [StringLength(maximumLength:30,MinimumLength =2,ErrorMessage ="Max 30 min 2 element yazmaq olar")]
        public string FullName { get; set; }
    }
}
