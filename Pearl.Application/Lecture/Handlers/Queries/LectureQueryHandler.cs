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

namespace Pearl.Application.Lecture.Handlers.Queries
{
    public class LectureQueryHandler : IRequestHandler<LectureQuery, List<LectureDTO>>
    {
        private readonly IApplicationContext _context;
        public LectureQueryHandler(IApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<LectureDTO>> Handle(LectureQuery request, CancellationToken cancellationToken)
        {
           

            if (request.Id >0)
            {
                var lecture = await _context.Lectures.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
                var lectList = new List<LectureDTO>
                {
                    new LectureDTO
                    {
                        Id = lecture.Id,
                        SubjectId = lecture.SubjectId,
                        LectureTheatreId = lecture.LectureTheatreId,
                        DayOfWeek = lecture.DayOfWeek,
                        StartTime = lecture.StartTime,
                        DurationInMinutes = lecture.DurationInMinutes
                    }
                };
                return lectList;
            }
            else
            {
                var lecture = await _context.Lectures.ToListAsync();
                var lectList = new List<LectureDTO>();
                foreach (var item in lecture)
                {
                    lectList.Add(new LectureDTO
                    {
                        Id = item.Id,
                        SubjectId = item.SubjectId,
                        LectureTheatreId = item.LectureTheatreId,
                        DayOfWeek = item.DayOfWeek,
                        StartTime = item.StartTime,
                        DurationInMinutes = item.DurationInMinutes
                    });
                }
                return lectList;
            }
        }
        //public async Task<int> Handle(LectureQuery query, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var lecture = new Pearl.Core.Model.Lecture();
        //        lecture.Id = query.Id;
        //        lecture.SubjectId = query.SubjectId;
        //        lecture.LectureTheatreId = query.LectureTheatreId;
        //        lecture.DayOfWeek = query.DayOfWeek;
        //        lecture.StartTime = query.StartTime;
        //        lecture.DurationInMinutes = query.DurationInMinutes;


        //        _context.Lectures.Add(lecture);
        //        await _context.SaveChangesAsync();

        //        return lecture.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}

