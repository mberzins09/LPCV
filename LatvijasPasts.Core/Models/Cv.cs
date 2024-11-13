using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Core.Models
{
    public class Cv : Entity
    {
        public PersonalData? PersonalData { get; set; }
        public Address? Address { get; set; }
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    }
}
