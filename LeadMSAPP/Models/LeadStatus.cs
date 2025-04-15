namespace LeadMSAPP.Models
{
    public class LeadStatus
    {
        public int Id { get; set; }
        public string? Status { get; set; } // Example: "New", "Follow-up", "Converted"
        public string? Description { get; set; }
        public string? LeadType { get; set; } // Example: "Cold", "Warm", "Hot"
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<Student>? Student { get; set; }
    }
}
