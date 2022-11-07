using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.MappingService.Interfaces
{
    public interface IAppointmentMappingService
    {
        Appointment ConvertToAppointment(AppointmentCreateFormDTO dto);
        AppointmentBasicDetailsDTO ConvertToAppointmentBasicInfoDTO(Appointment model);
        AppointmentCardDTO ConvertToCardDTO(Appointment appointment);
        AppointmentDTO ConvertToAppointmentDTO(Appointment appointment);
        SymptomDTO ConvertTOSymptomDTO(Symptom symptom);
        ICollection<SymptomDTO> ConvertToListSymptomDTO(ICollection<Symptom> symptoms);
        VetDTO ConvertToVetDTO(Vet vet);
        ICollection<TestDTO> ConvertToListTestDTO(ICollection<Test> tests);
        TestDTO ConvertTotestDTO(Test test);
        VitalDTO ConvertToVitalDTO(Vital vital);
        Vital ConvertToVital(VitalDTO vitaldto);
        Test ConvertToTest(TestDTO test);
        Symptom ConvertToSymptom(SymptomDTO symptom);


    }
}
