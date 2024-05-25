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
using FlexiSchools.Core.Model;
using FlexiSchools.Application.Lecture.Requests.Commands;

namespace FlexiSchools.Application.Lecture.Handlers.Commands
{
    public class SubjectUpdateCommandHandler : IRequestHandler<SubjectUpdateCommand, SubjectDTO>
    {
        private readonly IApplicationContext _context;
        public SubjectUpdateCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<SubjectDTO> Handle(SubjectUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var lecture = await _context.Subjects.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                lecture.Id = command.Id;
                lecture.Name = command.Name;
               
                _context.Subjects.Update(lecture);
                await _context.SaveChangesAsync();

                return ModelMapper(lecture);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static SubjectDTO ModelMapper(Core.Model.Subject sub)
        {
            return new SubjectDTO
            {
                Id = sub.Id,
                Name = sub.Name
            };
        }
    }
}

