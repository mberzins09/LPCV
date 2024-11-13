namespace LatvijasPasts.Core.Models
{
    public class WorkExperience : Entity
    {
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public string? WorkLoad { get; set; } 
        public string? Responsibilities { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
