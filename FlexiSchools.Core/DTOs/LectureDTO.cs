using FlexiSchools.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Core.DTOs
{
    public class LectureDTO
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public  SubjectDTO Subject { get; set; }

        public int LectureTheatreId { get; set; }
        public  LectureTheatreDTO LectureTheatre { get; set; }
        public int DayOfWeek { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
