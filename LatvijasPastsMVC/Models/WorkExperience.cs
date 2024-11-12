namespace LatvijasPastsMVC.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string WorkLoad { get; set; } // Part-time, Full-time
        public string Responsibilities { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
