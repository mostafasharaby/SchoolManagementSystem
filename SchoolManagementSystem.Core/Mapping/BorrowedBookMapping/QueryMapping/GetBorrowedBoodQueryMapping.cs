using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.BorrowedBookMapping
{
    public partial class BorrowedBoodProfile
    {
        public void GetBorrowedBoodQueryMapping()
        {
            CreateMap<BorrowedBook, BorrowedBookDto>();
        }
    }
}
