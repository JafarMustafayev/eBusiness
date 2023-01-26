using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBusiness.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int PositionId { get; set; }

        
        [StringLength(maximumLength:25,MinimumLength =2,ErrorMessage ="Max 25 min2 element ola biler")]
        public string Name { get; set; }

        [StringLength(maximumLength:100)]
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }


    }
}
