using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderPaid
    {
        [Display(Name = "شماره فاکتور")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "تاریخ و زمان انجام تراکنش")]
        public string? DateTimeIR { get; set; }
        [Display(Name = "شناسه نشانه")]
        public string? Token { get; set; }
        [Display(Name = "شناسه پذیرنده")]
        public string? AcceptorId { get; set; }
        [Display(Name = "کد نتیجه عملیات")]
        public string? ResponseCode { get; set; }
        [Display(Name = "شناسه پرداخت")]
        public string? PaymentId { get; set; }
        [Display(Name = "شناسه درخواست")]
        public string? RequestId { get; set; }
        [Display(Name = "شماره ارجاع")]
        public string? RetrievalReferenceNumber { get; set; }
        [Display(Name = "مبلغ‌ (تومان)")]
        public string? Amount { get; set; }
        [Display(Name = "شماره کارت")]
        public string? MaskedPen { get; set; }
        [Display(Name = "شماره پیگیری")]
        public string? SystemTranceAuditNumber { get; set; }
        [Display(Name = "وضعیت سفارش")]
        public StatusOrder StatusOrder { get; set; } = StatusOrder.Paid;

        [Display(Name = "شناسه مشتری")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser? user { get; set; }
    }
}

