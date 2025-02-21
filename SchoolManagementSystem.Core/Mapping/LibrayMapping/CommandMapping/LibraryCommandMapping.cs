using Microsoft.Extensions.DependencyModel;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Mapping.LibrayMapping
{
    public partial class LibraryProfile
    {
        public void LibraryCommandMapping()
        {
            CreateMap<LibraryDto, Library>();
        }
    }
}
