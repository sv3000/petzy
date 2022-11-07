using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment CreateAppointment(Appointment appointment);
        Appointment GetAppointment(int appointmentId);
      //  ICollection<Appointment> GetAllAppointmentByDoctorId(int doctorId);
        ICollection<Appointment> GetAllAppointmentFilterWithStatus(int doctorId, AppointmentStatus status, DateTime FromDate, DateTime ToDate);
        int TotalAppointmentCount(int doctorId);
        int TotalAppointmentCountBasedOnStatus(int doctorId, AppointmentStatus status);
        bool AcceptAppointment(int appointmentId);
        bool RejectApppointment(int appointmentId);
      //  IQueryable<AppointmentStatus> GetAppointmentSummary(int doctorId);
        int AppointmentCount(int doctorId);
        int AppointmentCount(int doctorId, string status);
        bool CloseAppointment(int appointmentId);
        List<int> GetIdsAssociatedWithAppointment(int appointmentId);
        ICollection<Appointment> GetAllAppointmentsByDate(int VetId, DateTime FromDate, DateTime ToDate);
        ICollection<Appointment> GetAllAppointmentsByPetParentId(int PetParent, DateTime FromDate, DateTime ToDate);
        ICollection<Appointment> GetAllAppointmentsByVetId(int VetId, DateTime FromDate, DateTime ToDate);
        ICollection<Appointment> GetAllAppointments();
    }
}
