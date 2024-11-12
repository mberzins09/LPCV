namespace LatvijasPastsMVC.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public string Faculty { get; set; }
        public string FieldOfStudy { get; set; }
        public string EducationLevel { get; set; }
        public string Status { get; set; } // Completed, Ongoing, etc.
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
