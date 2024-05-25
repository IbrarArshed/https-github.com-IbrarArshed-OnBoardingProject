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

namespace Pearl.Application.Lecture.Handlers.Commands
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
                var subject = new Pearl.Core.Model.Subject();
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

