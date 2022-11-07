using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System.Data.Entity;

namespace Petzey.Repository.Consultations
{
    public class VitalRepository:IVitalRepository
    {
        public Vital AddVitalByAppId(Vital VitalToSave)
        {
            using (var db = new ConsultationContext())
            {
                db.Entry(VitalToSave).State = EntityState.Modified;
                db.SaveChanges();
                return VitalToSave;
            }
        }

        public Vital UpdateVital(Vital VitalToUpdate)
        {
            using (var db = new ConsultationContext())
            {
                var Vital = db.Vitals.Find(VitalToUpdate.Id);
                if (VitalToUpdate == null) throw new NotFoundException();
                db.Entry(VitalToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return VitalToUpdate;
            }
        }

        public bool DeleteVital(int vitalId)
        {
            using (var db = new ConsultationContext())
            {
                var vital = db.Vitals.Find(vitalId);
                db.Vitals.Remove(vital);
                return db.SaveChanges() > 0;
            }
        }

        public Vital GetVitalById(int vitalId)
        {
            using (var db = new ConsultationContext())
            {
                var Vital = db.Vitals.Find(vitalId);
                return Vital;
            }
        }

        public Vital GetVitalByAppointmentId(int appointmentId)
        {
            using (var db = new ConsultationContext())
            {
                var appointment = db.Appointments.Find(appointmentId);
                return appointment.Vital;
            }
        }
    }
}
