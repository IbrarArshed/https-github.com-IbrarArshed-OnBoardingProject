using Pearl.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Core.DTOs
{
    public class LectureTheatreDTO : BaseNonAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<LectureDTO> Lectures { get; set; } = new List<LectureDTO>();
        public bool CapacityExceeds()
        {
            return Lectures.Count > Capacity;
        }
    }
}
