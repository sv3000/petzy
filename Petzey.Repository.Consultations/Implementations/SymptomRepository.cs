using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Implementations
{
    public class SymptomRepository:ISymptomRepository
    {
        public Symptom AddSymptomByAppId(Symptom symptomToSave)
        {
            using (var db = new ConsultationContext())
            {
                db.Symptoms.Add(symptomToSave);
                db.SaveChanges();
                return symptomToSave;
            }
        }

        public bool UpdateSymptom(Symptom symptom)
        {
            using (var db = new ConsultationContext())
            {
                var symptoms = db.Symptoms.Find(symptom.Id);
                if (symptom == null) throw new NotFoundException();
                db.Entry(symptom).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public bool DeleteSymptom(int symptomId)
        {
            using(var db = new ConsultationContext())
            {
                var symptom = db.Symptoms.Find(symptomId);
                db.Symptoms.Remove(symptom);
                return db.SaveChanges()>0;
            }
        }

        public Symptom GetSymptomById(int symptomId)
        {
            using(var db = new ConsultationContext())
            {
                var symptom = db.Symptoms.Find(symptomId);
                return symptom;
            }
        }

        public ICollection<Symptom> GetSymptomsByAppoointmentId(int appointmentId)
        {
            using (var db = new ConsultationContext())
            {
                var appointment = db.Appointments.Find(appointmentId);
                return appointment.Symptom.ToList();
            }
        }
        public ICollection<Symptom> GetAllSymptoms()
        {
            using(var db = new ConsultationContext())
            {
                var symptoms = db.Symptoms.ToList();
                return symptoms;
            }
        }
    }
}
