namespace LeadMSAPP.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseCode { get; set; }
        public int Duration { get; set; } // Duration in hours
        public decimal Price { get; set; }
        public string? Level { get; set; } // Beginner, Intermediate, Advanced
        public string? Category { get; set; } // e.g., Programming, Design, Marketing
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<Batch>? Batch { get; set; }
    }
}
