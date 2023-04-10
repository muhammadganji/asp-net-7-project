namespace Entities
{
    /// <summary>
    /// وضعیت سفارش
    /// </summary>
    public enum StatusOrder
    {
        /// <summary>
        /// سبد خرید
        /// </summary>
        InCart,
        /// <summary>
        /// پرداخت شده
        /// </summary>
        Paid,
        /// <summary>
        /// در حال پردازش
        /// </summary>
        Processing,
        /// <summary>
        /// ارسال شده
        /// </summary>
        Sent,
        /// <summary>
        /// تحویل داده شده
        /// </summary>
        Delivered,
        /// <summary>
        /// لغو شده
        /// </summary>
        Canceled
    }
}
