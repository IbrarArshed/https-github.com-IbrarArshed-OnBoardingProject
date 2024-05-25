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
using Pearl.Application.Subjects.Requests.Queries;

namespace Pearl.Application.Lecture.Handlers.Queries
{
    public class SubjectQueryHandler : IRequestHandler<SubjectQuery, List<SubjectDTO>>
    {
        private readonly IApplicationContext _context;
        public SubjectQueryHandler(IApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<SubjectDTO>> Handle(SubjectQuery request, CancellationToken cancellationToken)
        {
           

            if (request.Id >0)
            {
                var subject = await _context.Subjects.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
                var subjectList = new List<SubjectDTO>
                {
                    new SubjectDTO
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                    }
                };
                return subjectList;
            }
            else
            {
                var subject = await _context.Subjects.ToListAsync();
                var subjectList = new List<SubjectDTO>();
                foreach (var item in subjectList)
                {
                    subjectList.Add(new SubjectDTO
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
                return subjectList;
            }
        }
    }
}

