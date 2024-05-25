using FlexiSchools.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Core.Model
{
    public class LectureTheatre : BaseNonAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int LectureTheatreId { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public bool CapacityExceeds()
        {
            return Lectures.Count > Capacity;
        }
    }
}
