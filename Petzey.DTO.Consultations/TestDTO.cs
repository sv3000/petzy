using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AppointmentId { get; set; }
    }
}
