using Entities;

namespace Ui.Models
{
    public class PaymentGetwayViewModel
    {
        /// <summary>
        /// شناسه پرداخت سفارش
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// مبلغ قابل پرداخت
        /// </summary>
        public ulong Amount { get; set; }
        /// <summary>
        /// تاریخ پرداخت سفارش
        /// </summary>
        public string DateTime { get; set; }
        
    }
}
