using MediatR;
using FlexiSchools.Core.DTOs;
using FlexiSchools.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Lecture.Requests.Commands
{
    public class LectureInsertCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int LectureTheatreId { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
