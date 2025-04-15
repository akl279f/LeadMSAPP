namespace LeadMSAPP.Models
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; } = Guid.NewGuid().ToString();
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal AmountPaid { get; set; }
        public string? PaymentMethod { get; set; } // Example: "Cash", "Card", "Bank Transfer"
        public decimal TotalFee { get; set; }
        public decimal Due { get; set; }
        public string? Remarks { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}
