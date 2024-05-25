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

namespace FlexiSchools.Application.Lecture.Handlers.Commands
{
    public class SubjectInsertCommandHandler : IRequestHandler<SubjectInsertCommand, int>
    {
        private readonly IApplicationContext _context;
        public SubjectInsertCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<int> Handle(SubjectInsertCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var subject = new FlexiSchools.Core.Entities.Subject();
                subject.Id = command.Id;
                subject.Name = command.Name;

                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                return subject.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

