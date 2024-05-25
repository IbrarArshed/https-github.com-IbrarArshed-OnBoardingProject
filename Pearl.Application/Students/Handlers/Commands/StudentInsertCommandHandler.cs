using MediatR;
using Pearl.Core.Enumeration;
using Pearl.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pearl.Application.Lecture.Requests.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Pearl.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Pearl.Core.Model;
using Pearl.Application.Lecture.Requests.Commands;
using Pearl.Application.LectureTheatre.Requests.Commands;
using Pearl.Application.Students.Requests.Commands;

namespace Pearl.Application.Students.Handlers.Commands
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
                var std = new Pearl.Core.Model.Student();
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

