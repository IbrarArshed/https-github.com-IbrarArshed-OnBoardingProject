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
using FlexiSchools.Application.Students.Requests.Commands;

namespace FlexiSchools.Application.Students.Handlers.Commands
{
    public class StudentInsertCommandHandler : IRequestHandler<StudentInsertCommand, int>
    {
        private readonly IApplicationContext _context;
        public StudentInsertCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<int> Handle(StudentInsertCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var std = new FlexiSchools.Core.Entities.Student();
                std.Id = command.Id;
                std.FullName = command.FullName;

                _context.Students.Add(std);
                await _context.SaveChangesAsync();

                return std.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

