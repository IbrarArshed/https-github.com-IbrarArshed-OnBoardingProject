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
using FlexiSchools.Application.LectureTheatre.Requests.Queries;

namespace FlexiSchools.Application.Students.Handlers.Queries
{
    public class StudentQueryHandler : IRequestHandler<StudentQuery, List<StudentDTO>>
    {
        private readonly IApplicationContext _context;
        public StudentQueryHandler(IApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<StudentDTO>> Handle(StudentQuery request, CancellationToken cancellationToken)
        {
           

            if (request.Id >0)
            {
                var std = await _context.Students.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
                var stdList = new List<StudentDTO>
                {
                    new StudentDTO
                    {
                        Id = std.Id,
                        FullName = std.FullName
                    }
                };
                return stdList;
            }
            else
            {
                var stds = await _context.Students.ToListAsync();
                var stdList = new List<StudentDTO>();
                foreach (var item in stds)
                {
                    stdList.Add(new StudentDTO
                    {
                        Id = item.Id,
                        FullName = item.FullName,
                    });
                }
                return stdList;
            }
        }
    }
}

