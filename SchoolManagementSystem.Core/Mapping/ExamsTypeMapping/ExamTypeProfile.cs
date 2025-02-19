using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ExamsTypeMapping
{
    public partial class ExamTypeProfile : Profile
    {
        public ExamTypeProfile()
        {
            ExamTypeCommandMapping();
            ExamTypeQueryMapping();
        }
    }
}
