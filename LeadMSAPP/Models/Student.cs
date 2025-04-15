using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadMSAPP.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int LeadStatusId { get; set; }
        public virtual LeadStatus? LeadStatus { get; set; }
        public int EntityStatusId { get; set; }
        public virtual EntityStatus? EntityStatus { get; set; }
        public virtual ICollection<Enroll>? Enrollment { get; set; }
        public virtual ICollection<PaymentHistory>? PaymentHistory { get; set; }

        [NotMapped]
        [Required]
        public int BatchId { set; get; }
    }
}
