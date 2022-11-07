using System.Collections.Generic;

namespace Petzey.Model.Consultations
{
    public class Prescription
    {
        public Prescription()
        {
            Medicines = new HashSet<Medicine>();
        }
        public int Id { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        
    }
}