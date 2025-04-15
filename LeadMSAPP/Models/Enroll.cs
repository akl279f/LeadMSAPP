namespace LeadMSAPP.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        public decimal FeePaid { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int BatchId { get; set; }
        public virtual Batch? Batch { get; set; }
    }
}
