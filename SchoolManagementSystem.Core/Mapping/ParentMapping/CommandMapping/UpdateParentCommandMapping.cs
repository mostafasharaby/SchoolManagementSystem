﻿using SchoolManagementSystem.Core.Features.Parents.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ParentMapping
{
    public partial class ParentProfile
    {
        public void UpdateParentCommandMapping()
        {
            CreateMap<UpdateParentCommand, Parent>();
        }
    }
}
