namespace LatvijasPasts.Core.Models
{
    public class Cv : Entity
    {
        public PersonalData? PersonalData { get; set; }
        public Address? Address { get; set; }
        public Education? Education { get; set; }
        public WorkExperience? WorkExperience { get; set; }
    }
}
