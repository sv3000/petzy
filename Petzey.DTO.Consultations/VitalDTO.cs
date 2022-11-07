using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class VitalDTO
    {
        public int Id { get; set; }
        public float Ecg { get; set; }
        public float Temperature { get; set; }
        public float Respiration_rate { get; set; }
        public int AppointmentId { get; set; }
    }
}
