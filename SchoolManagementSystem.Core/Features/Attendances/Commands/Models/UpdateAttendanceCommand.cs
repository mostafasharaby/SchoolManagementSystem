﻿using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Attendances.Commands.Models
{
    public class UpdateAttendanceCommand : AttendanceDto, IRequest<Response<string>>
    {
        public int AttendanceID { get; set; }
    }

}
