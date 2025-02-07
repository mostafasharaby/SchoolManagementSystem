using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Wrapper;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    internal class GetStudentsPaginatedHandler : IRequestHandler<GetStudentsPaginatedQuery, PaginatedResult<Student>>
    {
        private readonly IStudentService _studentService;

        public GetStudentsPaginatedHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public Task<PaginatedResult<Student>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            //var searchedList = _studentService.GetStudentAsyncFilter(request.Search);
            //var orderdList = _studentService.GetStudentAsyncOrderd(request.OrderBy);
            //if (!searchedList.Any())
            //{
            //    if (!orderdList.Any()) 
            //    {
            //        return list.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    }
            //    return list.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //}            

            //return searchedList.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            var list = _studentService.GetStudentAsyncOrderd(request.OrderBy); // Now ordering is handled

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                list = _studentService.GetStudentAsyncFilter(request.Search);
            }

            return list.ToPaginatedListAsync(request.PageNumber, request.PageSize);

        }
    }
}
