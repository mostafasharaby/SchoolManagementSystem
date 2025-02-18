using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Courses.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Courses.Commands.Handlers
{
    public class CourseCommandHandler : IRequestHandler<AddCourseCommand, Response<string>>,
                                        IRequestHandler<UpdateCourseCommand, Response<string>>,
                                        IRequestHandler<DeleteCourseCommand, Response<string>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public CourseCommandHandler(IMapper mapper, ResponseHandler responseHandler, ICourseService courseService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _courseService = courseService;
        }

        public async Task<Response<string>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            await _courseService.AddCourseAsync(course);
            return _responseHandler.Created("Course created successfully.");
        }

        public async Task<Response<string>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = _mapper.Map<Course>(request);
                await _courseService.UpdateCourseAsync(course);
                return _responseHandler.Success("Course updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest<string>("An unexpected error occurred: " + ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await _courseService.DeleteCourseAsync(request.CourseID);
            if (!result)
                return _responseHandler.NotFound<string>("Course not found.");

            return _responseHandler.Success("Course deleted successfully.");
        }
    }

}
