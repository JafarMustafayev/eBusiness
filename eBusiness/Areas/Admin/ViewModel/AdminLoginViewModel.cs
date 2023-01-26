
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModel
{
    public class AdminLoginViewModel
    {
        [Required,StringLength(maximumLength:30,MinimumLength =5)]
        public string UserName { get; set; }

        [Required,StringLength(maximumLength:30,MinimumLength =8),DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
