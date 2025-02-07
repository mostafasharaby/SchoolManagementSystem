using System.Globalization;

namespace SchoolManagementSystem.Data.General
{
    public class LocalizedEntityGeneral
    {
        public string GetCultureLanguage(string ArabicText, string EnglishText)
        {
            CultureInfo CultureLang = Thread.CurrentThread.CurrentUICulture;
            if (CultureLang.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return ArabicText;
            }
            return EnglishText;
        }

    }
}
