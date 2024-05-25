using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Core.Model
{
    public class Lecture : BaseNonAuditable
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public  Subject Subject { get; set; }

        public int LectureTheatreId { get; set; }
        public  LectureTheatre LectureTheatre { get; set; }
        public int DayOfWeek { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
