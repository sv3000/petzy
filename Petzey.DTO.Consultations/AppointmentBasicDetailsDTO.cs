using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class AppointmentBasicDetailsDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string PatientName { get; set; }
        public string Issue { get; set; }
    }
}
