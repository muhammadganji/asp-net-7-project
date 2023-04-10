using ServiceReference1;

namespace Ui.Tools
{
    public class MessageSms
    {
        /// <summary>
        ///  ییام مدیر
        /// ثبت سفارش جدید
        /// </summary>
        /// <param name="amount">مبلغ سفارش</param>
        /// <returns></returns>
        public async Task<bool> SendAlarmAdmin(string amount)
        {

            try
            {
                SettingXML info = new SettingXML();
                DateTimePersian data = new DateTimePersian();
                string[] PatternValues = { amount, data.GetDateTimeIR() };

                AmootSMSWebService2SoapClient client = new AmootSMSWebService2SoapClient(new AmootSMSWebService2SoapClient.EndpointConfiguration());

                SendResult result = await client.SendWithPatternAsync(info.UserName, info.Password,
                    info.PhoneAlarmAdmin, info.PatternCodeAlarmAdmin, PatternValues);


                if (result.Status == Status.Success)
                {
                    return true;
                }
                else { return false; }
            }
            catch
            {

                return false;
            }
        }


        /// <summary>
        ///  ییام پشتیبانی
        /// ثبت سفارش جدید
        /// </summary>
        /// <param name="amount">مبلغ سفارش</param>
        /// <returns></returns>
        public async Task<bool> SendAlarmBackup(string amount)
        {

            try
            {
                SettingXML info = new SettingXML();
                if (info.PhoneAlarmBackup != string.Empty)
                {
                    DateTimePersian data = new DateTimePersian();
                    string[] PatternValues = { amount, data.GetDateTimeIR() };

                    AmootSMSWebService2SoapClient client = new AmootSMSWebService2SoapClient(new AmootSMSWebService2SoapClient.EndpointConfiguration());

                    SendResult result = await client.SendWithPatternAsync(info.UserName, info.Password,
                        info.PhoneAlarmBackup, info.PatternCodeAlarmAdmin, PatternValues);
                    if (result.Status == Status.Success)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }

            }
            catch
            {

                return false;
            }

        }


        /// <summary>
        /// ارسال کد یکبار مصرف
        /// </summary>
        /// <param name="Mobile">شماره موبایل</param>
        /// <returns>کد 5 رقمی</returns>
        public async Task<string> SendOTP(string Mobile)
        {
            SettingXML info = new SettingXML();
            var rand = new Random();
            int codeGenerateforOTP = rand.Next(30000, 70001);
            string[] PatternValues = new string[] { codeGenerateforOTP.ToString() };

            try
            {
                AmootSMSWebService2SoapClient client = new AmootSMSWebService2SoapClient
                (new AmootSMSWebService2SoapClient.EndpointConfiguration());

                SendResult result = await client.SendWithPatternAsync(info.UserName, info.Password,
                    Mobile, info.PatternCodeIDOTP, PatternValues);

                if (result.Status == Status.Success)
                {
                    return codeGenerateforOTP.ToString();
                }
                else { return string.Empty; }

            }
            catch
            {
                return string.Empty;
            }
        }




    }
}
