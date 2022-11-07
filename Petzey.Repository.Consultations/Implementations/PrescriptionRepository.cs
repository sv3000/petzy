using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations
{
    public class PrescriptionRepository:IPrescriptionRepository
    { 
        public Prescription AddPrescription(Prescription prescription, int appointmentId)
        {
            using(var db = new ConsultationContext())
            {
                var appointment = db.Appointments.Find(appointmentId);
                appointment.Prescription = prescription;
                db.SaveChanges();
                return appointment.Prescription;
            }
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            using(var db = new ConsultationContext())
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return medicine;
            }
        }
        
        public Prescription EditPrescription(Prescription prescription)
        {
            using(var db = new ConsultationContext())
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return prescription;
            }   
        }

        public Medicine GetMedicine(int Id)
        {
            using(var db = new ConsultationContext())
            {
                var result = db.Medicines.Where(m => m.Id == Id);
                return result.FirstOrDefault();
            }
        }

        public ICollection<Medicine> GetAllMedicinesByPrescriptionId(int PrescriptionId)
        {
            using(var db = new ConsultationContext())
            {
                var result = db.Prescriptions.Include(a=>a.Medicines).Where(a => a.Id == PrescriptionId).First();
                return result.Medicines.ToList();
            }
        }
    }
}
