namespace LeadMSAPP.Models
{
    public class EntityStatus
    {
        public int Id { get; set; }
        public string? StatusName { get; set; } // Example: "Active", "Inactive", "Pending"
        public string? Description { get; set; }
        public string? StatusType { get; set; } // Example: "Student", "Course", "Payment"
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<Student>? Student { get; set; }
    }
}
