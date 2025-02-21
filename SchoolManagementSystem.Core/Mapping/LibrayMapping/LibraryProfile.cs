using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.LibrayMapping
{
    public partial class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            LibraryCommandMapping();
            LibraryQueryMapping();
        }
    }
}
