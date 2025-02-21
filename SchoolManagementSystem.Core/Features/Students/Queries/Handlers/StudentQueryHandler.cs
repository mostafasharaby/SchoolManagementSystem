using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Wrapper;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{

    public class StudentQueryHandler : IRequestHandler<GetStudentByIdQuery, Response<StudentDto>>,
                                        IRequestHandler<GetAllStudentsQuery, Response<List<StudentDto>>>,
                                        IRequestHandler<GetStudentsPaginatedQuery, PaginatedResult<Student>>,
                                        IRequestHandler<GetStudentCoursesQuery, Response<List<CourseDto>>>,
                                        IRequestHandler<GetStudentAttendanceQuery, Response<List<AttendanceDto>>>,
                                        IRequestHandler<GetStudentExamResultsQuery, Response<List<ExamResultDto>>>,
                                        IRequestHandler<GetStudentBorrowedBooksQuery, Response<List<BorrowedBookDto>>>,
                                        IRequestHandler<GetStudentFeeHistoryQuery, Response<List<FeeDto>>>
    {
        private readonly IStudentService _studentService;
        private readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService, ResponseHandler responseHandler, IMapper mapper)
        {
            _studentService = studentService;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        public async Task<Response<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentAsyncByID(request.StudentID);
            if (student == null)
                return _responseHandler.NotFound<StudentDto>("Student not found.");

            var dto = _mapper.Map<StudentDto>(student);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentAsync();
            var dtoList = _mapper.Map<List<StudentDto>>(students);
            return _responseHandler.Success(dtoList);
        }

        public Task<PaginatedResult<Student>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = _studentService.GetStudentAsyncOrderd(request.OrderBy); // Now ordering is handled

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                list = _studentService.GetStudentAsyncFilter(request.Search);
            }

            return list.ToPaginatedListAsync(request.PageNumber, request.PageSize);

        }

        public async Task<Response<List<CourseDto>>> Handle(GetStudentCoursesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetStudentCoursesAsync(request.StudentID);
                var resultMapper = _mapper.Map<List<CourseDto>>(result);
                return _responseHandler.Success(resultMapper);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<CourseDto>>(ex.Message);
            }
        }

        public async Task<Response<List<AttendanceDto>>> Handle(GetStudentAttendanceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetStudentAttendanceAsync(request.StudentID);
                var resultMapper = _mapper.Map<List<AttendanceDto>>(result);
                return _responseHandler.Success(resultMapper);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<AttendanceDto>>(ex.Message);
            }
        }

        public async Task<Response<List<ExamResultDto>>> Handle(GetStudentExamResultsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetStudentExamResultsAsync(request.StudentID);
                var resultMapper = _mapper.Map<List<ExamResultDto>>(result);
                return _responseHandler.Success(resultMapper);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<ExamResultDto>>(ex.Message);
            }
        }

        public async Task<Response<List<BorrowedBookDto>>> Handle(GetStudentBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetStudentBorrowedBooksAsync(request.StudentID);
                var resultMapper = _mapper.Map<List<BorrowedBookDto>>(result);
                return _responseHandler.Success(resultMapper);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<BorrowedBookDto>>(ex.Message);
            }
        }

        public async Task<Response<List<FeeDto>>> Handle(GetStudentFeeHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetStudentFeeHistoryAsync(request.StudentID);
                var resultMapper = _mapper.Map<List<FeeDto>>(result);
                return _responseHandler.Success(resultMapper);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<FeeDto>>(ex.Message);
            }
        }
    }

}
