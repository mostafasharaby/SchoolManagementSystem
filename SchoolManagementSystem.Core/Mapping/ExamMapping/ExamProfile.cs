using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ExamMapping
{
    public partial class ExamProfile : Profile
    {
        public ExamProfile()
        {
            ExamQueryMapping();
            ExamCommandMapping();
        }
    }
}
