using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Core.Models
{
    public class PersonalData : Entity
    {
        public int? CvId { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
    }
}
