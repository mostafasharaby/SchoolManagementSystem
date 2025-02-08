using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            getStudentDtoQueryMapping();
            AddStudentProfile();
            UpdateStudentProfile();
            //StudentByIdResponseMapping();
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
