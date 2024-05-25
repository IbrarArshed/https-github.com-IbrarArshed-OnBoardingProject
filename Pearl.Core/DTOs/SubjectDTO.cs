using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Core.DTOs
{
    public class SubjectDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LectureDTO> Lectures { get; set; } = new List<LectureDTO>();
        public List<StudentDTO> EnrolledStudents { get; private set; }

        public SubjectDTO()
        {
            EnrolledStudents = new List<StudentDTO>();
        }
    }
}
