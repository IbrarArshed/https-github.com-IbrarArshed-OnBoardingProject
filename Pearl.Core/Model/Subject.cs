using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Core.Model
{
    public class Subject : BaseNonAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Student> EnrolledStudents { get; private set; }

        public Subject()
        {
            EnrolledStudents = new List<Student>();
        }
    }
}
