namespace LeadMSAPP.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ParentId { get; set; } = null;
        public string? ParentName { get; set; } = null;
        public string? ParentDescription { get; set; } = null;
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public virtual ICollection<Enroll>? Enrollment { get; set; }
    }
}
