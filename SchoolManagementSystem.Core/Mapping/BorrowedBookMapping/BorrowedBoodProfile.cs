using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.BorrowedBookMapping
{
    public partial class BorrowedBoodProfile : Profile
    {
        public BorrowedBoodProfile()
        {
            GetBorrowedBoodQueryMapping();
            AddBorrowedBoodCommandMapping();
        }
    }
}
