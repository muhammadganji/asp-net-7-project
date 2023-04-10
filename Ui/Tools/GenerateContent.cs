namespace Ui.Tools
{
    public static class GenerateContent
    {
        public static string UserName()
        {
            Random rnd = new Random();
            string username = "Hirkan" + DateTime.Now.ToString("yyyyMMdd") + 
                rnd.Next(minValue: 2500, maxValue: 9999).ToString();
            return username;
        }
    }
}
