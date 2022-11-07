using Petzey.DTO.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.Interfaces
{
    public interface IAppointmentService
    {
        AppointmentCardDTO CreateAppointment(AppointmentCreateFormDTO appointmentDTO);
        ICollection<AppointmentCardDTO> GetAllAppointmentsByRoleId(int roleId , string role, DateTime FromDate, DateTime ToDate);
        ICollection<AppointmentCardDTO> GetAllAppointmentFiltered(int doctorId, string status, DateTime FromDate, DateTime ToDate);
        ICollection<AppointmentCardDTO> GetAllAppointments();
        bool ChangeAppointmentStatus(AppointmentStatusDTO statusDTO);
        bool CloseAppointment(int appointmentId);
        int GetAppointmentCount(int doctorId);
        int GetAppointmentCountBasedOnStatus(int doctorId, string status);
        ICollection<AppointmentCardDTO> GetAllAppointmentsByDate(int VetId, DateTime FromDate, DateTime ToDate);
        AppointmentDTO GetAppointmentById(int AppointmentId);
        VitalDTO AddVital(VitalDTO vital);
        VitalDTO EditVital(VitalDTO vital);
        VitalDTO GetVitalByAppointmentId(int AppointmentId);
        VitalDTO GetVital(int VitalId);
        TestDTO AddTest(TestDTO test);
        TestDTO UpdateTest(TestDTO test);
        ICollection<TestDTO> GetAllTest();
        SymptomDTO AddSymptom(SymptomDTO symptom);
        SymptomDTO UpdateSymptom(SymptomDTO symptom);
        ICollection<SymptomDTO> GetAllSymptoms();

    }
}
