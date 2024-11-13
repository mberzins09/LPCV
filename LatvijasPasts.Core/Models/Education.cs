namespace LatvijasPasts.Core.Models
{
    public class Education : Entity
    {
        public string? InstitutionName { get; set; }
        public string? Faculty { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? EducationLevel { get; set; }
        public string? Status { get; set; } 
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
