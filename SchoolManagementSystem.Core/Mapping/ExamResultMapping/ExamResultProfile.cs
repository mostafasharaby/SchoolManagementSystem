using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ExamResultMapping
{
    public partial class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            ExamResultCommandMapping();
            ExamResultQueryMapping();
        }
    }
}
