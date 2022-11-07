using System.ComponentModel.DataAnnotations.Schema;

namespace Petzey.Model.Consultations
{
    public class Vital
    {
        public int Id { get; set; }
        public float ECG { get; set; }
        public float Temperature { get; set; }
        public float RespirationRate { get; set; }
        public int AppointmentId { get; set; }

    }
}