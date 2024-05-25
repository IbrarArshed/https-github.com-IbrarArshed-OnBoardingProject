using MediatR;
using FlexiSchools.Core.Enumeration;
using FlexiSchools.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlexiSchools.Application.Lecture.Requests.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using FlexiSchools.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FlexiSchools.Core.Entities;
using FlexiSchools.Application.Lecture.Requests.Commands;
using FlexiSchools.Application.LectureTheatre.Requests.Commands;

namespace FlexiSchools.Application.Students.Handlers.Commands
{
    public class StudentUpdateCommandHandler : IRequestHandler<StudentUpdateCommand, StudentDTO>
    {
        private readonly IApplicationContext _context;
        public StudentUpdateCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<StudentDTO> Handle(StudentUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var std = await _context.Students.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                std.Id = command.Id;
                std.FullName = command.FullName;
               
                _context.Students.Update(std);
                await _context.SaveChangesAsync();

                return ModelMapper(std);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static StudentDTO ModelMapper(Core.Entities.Student lecture)
        {
            return new StudentDTO
            {
                Id = lecture.Id,
                FullName = lecture.FullName,
            };
        }
    }
}

