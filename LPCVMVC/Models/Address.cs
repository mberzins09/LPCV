namespace LatvijasPasts.Core.Models
{
    public class Address : Entity
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
