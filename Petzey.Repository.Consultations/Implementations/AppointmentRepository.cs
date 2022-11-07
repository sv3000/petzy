using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Petzey.Repository.Consultations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ConsultationContext db;
        public AppointmentRepository()
        {
            this.db = new ConsultationContext();
        }

        public bool AcceptAppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);

            appointment.Status = AppointmentStatus.CONFIRMED;
            return db.SaveChanges() > 0;
        }


        public int AppointmentCount(int doctorId)
        {
            return db.Appointments.Where(a => a.VetDetails.VetId == doctorId).Count();
        }

        public List<int> GetIdsAssociatedWithAppointment(int appointmentId)
        {
            return db.Appointments.Where(x => x.Id == appointmentId).Select(x => new List<int>
            {
                x.Id,
                x.PetParent.PetParentId,
                x.VetDetails.VetId
            }).FirstOrDefault();
        }

        public int AppointmentCount(int doctorId, string status)
        {
            return db.Appointments.Where(a => a.VetDetails.VetId == doctorId && a.Status.ToString().ToLower().Equals(status.ToLower())).Count();
        }

        public bool CloseAppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);
            appointment.Status = AppointmentStatus.CLOSED;
            return db.SaveChanges() > 0;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return appointment;
        }

        public ICollection<Appointment> GetAllAppointmentsByVetId(int vetId, DateTime FromDate, DateTime ToDate)
        {
            var appointments = db.Appointments.Include(x => x.Pet).Include(x => x.PetParent).Include(x => x.VetDetails).Where(x => x.VetDetails.VetId == vetId && x.AppointmentDate >= FromDate && x.AppointmentDate <= ToDate).OrderByDescending(x => x.AppointmentDate).OrderByDescending(x => x.AppointmentTime).ToList();
            return appointments;
        }

        public ICollection<Appointment> GetAllAppointmentsByPetParentId(int petParentId, DateTime FromDate, DateTime ToDate)
        {
            var appointments = db.Appointments.Include(x => x.Pet).Include(x => x.VetDetails).Include(x => x.PetParent).Where(x => x.PetParent.PetParentId == petParentId && x.AppointmentDate >= FromDate && x.AppointmentDate <= ToDate).OrderByDescending(x => x.AppointmentDate).OrderByDescending(x => x.AppointmentTime).ToList();
            return appointments;
        }

        public ICollection<Appointment> GetAllAppointmentsByPetParentIdandStatus(int petParentId,AppointmentStatus status)
        {
            var appointments = db.Appointments.Include(x => x.Pet).Include(x => x.VetDetails).Include(x=>x.PetParent).Where(x => x.PetParent.PetParentId == petParentId && x.Status == status).OrderByDescending(x => x.AppointmentDate).OrderByDescending(x => x.AppointmentTime).ToList();
            return appointments;
        }

        public ICollection<Appointment> GetAllAppointmentFilterWithStatus(int doctorId, AppointmentStatus status, DateTime FromDate, DateTime ToDate)
        {
            var appointments = db.Appointments.Include(x => x.Pet).Include(x => x.PetParent).Include(x=>x.VetDetails).Where(a => a.VetDetails.VetId == doctorId && a.Status == status && a.AppointmentDate >= FromDate && a.AppointmentDate <= ToDate).OrderByDescending(x => x.AppointmentDate).OrderByDescending(x => x.AppointmentTime).ToList();
            return appointments;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            var result = db.Appointments
                .Include(a => a.Prescription)
                .Include(a=>a.Prescription.Medicines)
                .Include(a =>a.Test)
                .Include(a=>a.PetParent)
                .Include(a=>a.Pet)
                .Include(a=>a.VetDetails)
                .Include(a=>a.Vital)
                .Include(a=>a.Symptom)
                .Where(a=>a.Id == appointmentId).First();
            return  result;
        }
      
       public ICollection<Appointment> GetAllAppointments()
        {
            return db.Appointments.Include(a => a.VetDetails).Include(a => a.Pet).Include(a => a.PetParent).ToList();
        }

        public bool RejectApppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);

            appointment.Status = AppointmentStatus.CANCELLED;
            return db.SaveChanges() > 0;
        }

        public int TotalAppointmentCount(int doctorId)
        {
            return db.Appointments.Where(a=>a.VetDetails.VetId==doctorId).Count();
        }

        public int TotalAppointmentCountBasedOnStatus(int doctorId, AppointmentStatus status)
        {
            return db.Appointments.Where(a => a.Status.CompareTo(status) == 0).Count();
        }

        public ICollection<Appointment> GetAllAppointmentsByDate(int VetId, DateTime FromDate, DateTime ToDate)
        {
            return db.Appointments.Include(a=>a.VetDetails).Include(a=>a.Pet).Include(a=>a.PetParent).Where(a => a.AppointmentDate >= FromDate && a.AppointmentDate <= ToDate && a.VetDetails.VetId == VetId).ToList();
        }
      
    }
}
