using System.Xml;

namespace Ui.Tools
{
    public class SettingXML
    {
        // :::::::::::::   Company    :::::::::::::
        /// <summary>
        /// نام شرکت
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// آدرس شرکت
        /// </summary>
        public string Address { get;}
        /// <summary>
        /// کد پستی شرکت
        /// </summary>
        public string Zipcode { get;}
        /// <summary>
        /// تلفن شرکت
        /// </summary>
        public string Phone { get;}
        /// <summary>
        /// پیج اینستاگرام
        /// </summary>
        public string Instagram { get; }
        /// <summary>
        /// شماره اطلاع رسانی ادمین
        /// </summary>
        public string PhoneAlarmAdmin { get; }
        /// <summary>
        /// شماره پشتیبانی سایت
        /// </summary>
        public string PhoneAlarmBackup { get;}


        // :::::::::::::   Amot    :::::::::::::
        /// <summary>
        /// نام کاربری سرویس پیامکی
        /// </summary>
        public string UserName { get;}
        /// <summary>
        /// رمز عبور پیامکی
        /// </summary>
        public string Password { get; }
        /// <summary>
        /// کد پترن احراز هویت
        /// </summary>
        public int PatternCodeIDOTP { get; }
        /// <summary>
        /// کد پترن اطلاع رسانی ادمین
        /// ثبت سفارش جدید
        /// </summary>
        public int PatternCodeAlarmAdmin { get; }

        /// <summary>
        /// زمان منقضی شدن کوکی در محصولات
        /// </summary>
        public int TimeExpiresForCookeis { get; }


        /// <summary>
        /// 
        /// </summary>
        public string TreminalId { get; }

        /// <summary>
        /// 
        /// </summary>
        public string AcceptorId { get; }

        public string PassPhrase { get; }





        public SettingXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("SettingXML.xml");

                Name = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("Name")[0].InnerText;
                Address = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("Address")[0].InnerText;
                Zipcode = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("Zipcode")[0].InnerText;
                Phone = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("Phone")[0].InnerText;
                Instagram = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("Instagram")[0].InnerText;
                PhoneAlarmAdmin = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("PhoneAlarmAdmin")[0].InnerText;
                PhoneAlarmBackup = doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("PhoneAlarmBackup")[0].InnerText;
                TimeExpiresForCookeis = Convert.ToInt32(doc.SelectNodes("DocumentElement/Company")[0].SelectNodes("TimeExpiresForCookeis")[0].InnerText);


                UserName = doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("UserName")[0].InnerText;
                Password = doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("Password")[0].InnerText;
                PatternCodeIDOTP = Convert.ToInt32(doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("PatternCodeIDOTP")[0].InnerText);
                PatternCodeAlarmAdmin = Convert.ToInt32(doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("PatternCodeAlarmAdmin")[0].InnerText);


                TreminalId = doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("TreminalId")[0].InnerText;
                AcceptorId = doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("AcceptorId")[0].InnerText;
                PassPhrase = doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("PassPhrase")[0].InnerText;

            }
            catch { }

        }
    }
}
