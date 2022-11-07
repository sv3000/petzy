using System.ComponentModel.DataAnnotations.Schema;

namespace Petzey.Model.Consultations
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Appointment Appointment { get; set; }
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
    }
}