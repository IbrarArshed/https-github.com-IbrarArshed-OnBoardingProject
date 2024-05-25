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

namespace Pearl.Application.LectureTheatre.Handlers.Commands
{
    public class LectureTheatreInsertCommandHandler : IRequestHandler<LectureTheatreInsertCommand, int>
    {
        private readonly IApplicationContext _context;
        public LectureTheatreInsertCommandHandler(IApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<int> Handle(LectureTheatreInsertCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var lecture = new Pearl.Core.Model.LectureTheatre();
                lecture.Id = command.Id;
                lecture.Name = command.Name;
                lecture.Capacity = command.Capacity;
               

                _context.LectureTheatres.Add(lecture);
                await _context.SaveChangesAsync();

                return lecture.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

