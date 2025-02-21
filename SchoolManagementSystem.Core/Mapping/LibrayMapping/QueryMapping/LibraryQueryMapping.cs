using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.LibrayMapping
{
    public partial class LibraryProfile
    {
        public void LibraryQueryMapping()
        {
            CreateMap<Library, LibraryDto>();
        }
    }
}
