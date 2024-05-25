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
using FlexiSchools.Application.LectureTheatre.Requests.Queries;

namespace FlexiSchools.Application.LectureTheatre.Handlers.Queries
{
    public class LectureTheatreQueryHandler : IRequestHandler<LectureTheatreQuery, List<LectureTheatreDTO>>
    {
        private readonly IApplicationContext _context;
        public LectureTheatreQueryHandler(IApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<LectureTheatreDTO>> Handle(LectureTheatreQuery request, CancellationToken cancellationToken)
        {
           

            if (request.Id >0)
            {
                var lecture = await _context.LectureTheatres.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
                var lectList = new List<LectureTheatreDTO>
                {
                    new LectureTheatreDTO
                    {
                        Id = lecture.Id,
                        Name = lecture.Name,
                        Capacity = lecture.Capacity
                    }
                };
                return lectList;
            }
            else
            {
                var lecture = await _context.LectureTheatres.ToListAsync();
                var lectList = new List<LectureTheatreDTO>();
                foreach (var item in lecture)
                {
                    lectList.Add(new LectureTheatreDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Capacity = item.Capacity
                    });
                }
                return lectList;
            }
        }
    }
}

