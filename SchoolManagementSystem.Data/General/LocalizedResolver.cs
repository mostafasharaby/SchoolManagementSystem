using AutoMapper;

namespace SchoolManagementSystem.Data.General
{
    public class LocalizedEntityGeneral
    {
        public string GetCultureLanguage(string ArabicText, string EnglishText)
        {
            var CultureLang = Thread.CurrentThread.CurrentUICulture;
            if (CultureLang.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return ArabicText;
            }
            return EnglishText;
        }

    }
    public class LocalizedResolver<TSource> : IValueResolver<TSource, object, string>
    {
        private readonly Func<TSource, string> _arabicSelector;
        private readonly Func<TSource, string> _englishSelector;

        public LocalizedResolver(Func<TSource, string> arabicSelector, Func<TSource, string> englishSelector)
        {
            _arabicSelector = arabicSelector;
            _englishSelector = englishSelector;
        }

        public string Resolve(TSource source, object destination, string destMember, ResolutionContext context)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
            return culture.Equals("ar") ? _arabicSelector(source) : _englishSelector(source);
        }
    }
}
