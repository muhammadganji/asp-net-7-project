using System.Globalization;

namespace Ui.Tools
{
    public class DateTimePersian
    {
        /// <summary>
        /// Get Date Persian 
        /// </summary>
        /// <returns>Ex. (1400-9-26)</returns>
        public string GetDateIR()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dateTimeNow = DateTime.Now;
            string DateTimeIR = pc.GetYear(dateTimeNow).ToString() + "/" + pc.GetMonth(dateTimeNow).ToString() + "/" + pc.GetDayOfMonth(dateTimeNow).ToString();


            return DateTimeIR;
        }
        /// <summary>
        /// Get DateTime Persian
        /// </summary>
        /// <returns>Ex. (1400-9-26 17:17)</returns>
        public string GetDateTimeIR()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dateTimeNow = DateTime.Now;
            string DateTimeIR = pc.GetYear(dateTimeNow).ToString()
                + "/" + pc.GetMonth(dateTimeNow).ToString()
                + "/" + pc.GetDayOfMonth(dateTimeNow).ToString()
                + " " + pc.GetHour(dateTimeNow).ToString() +
                ":" + pc.GetMinute(dateTimeNow).ToString();
            return DateTimeIR;
        }
    }
}
