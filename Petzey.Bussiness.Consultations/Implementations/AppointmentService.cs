using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.Bussiness.Consultations.MappingService;
using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.Implementations
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository repo;
        private readonly IAppointmentMappingService service;
        private readonly IPrescriptionRepository presrepo;
        private readonly IVitalRepository vitalRepository;
        private readonly ITestRepository testRepository;
        private readonly ISymptomRepository symptomRepository;
        

        public AppointmentService(
            IAppointmentRepository repo, 
            IAppointmentMappingService service, 
            IPrescriptionRepository presrepo,
            IVitalRepository vitalRepository,
            ITestRepository testRepository,
            ISymptomRepository symptomRepository
            )
        {
            this.repo = repo;
            this.service = service;
            this.presrepo = presrepo;
            this.symptomRepository = symptomRepository;
            this.vitalRepository = vitalRepository;
            this.testRepository = testRepository;
        }

        public AppointmentCardDTO CreateAppointment(AppointmentCreateFormDTO appointmentDTO)
        {
            if (DateTime.Compare(appointmentDTO.AppointmentDate, DateTime.Now.Date) < 0)
                throw new AppointmentDatetimeException("Appointment Date time is not Valid");
            if (DateTime.Compare(DateTime.Now.Date, appointmentDTO.AppointmentDate) == 0 && TimeSpan.Compare(appointmentDTO.AppointmentTime, DateTime.Now.TimeOfDay) < 0)
            {
                throw new AppointmentDatetimeException("Appointment Date time is not Valid");
            }
            if (appointmentDTO.Pet.PetId == 0 || appointmentDTO.Vet.VetId ==0|| appointmentDTO.Issue == "" || appointmentDTO.Vet.VetName == "" || appointmentDTO.Pet.PetName == "")
            {
                throw new MissingDetailException();
            }

            var appointment = service.ConvertToAppointment(appointmentDTO);

            AppointmentCardDTO result = service.ConvertToCardDTO(repo.CreateAppointment(appointment));

            return result;
        }

        //public ICollection<AppointmentBasicDetailsDTO> GetAllAppointmentByDoctorId(int doctorId)
        //{
        //    ICollection<Appointment> appointments = repo.GetAllAppointmentsByVetId(doctorId);
        //    ICollection<AppointmentBasicDetailsDTO> result = new List<AppointmentBasicDetailsDTO>();
        //    foreach (var appointment in appointments)
        //    {
        //        result.Add(service.ConvertToAppointmentBasicInfoDTO(appointment));
        //    }
        //    return result;
        //}

        public ICollection<AppointmentCardDTO> GetAllAppointmentFiltered(int doctorId, string status, DateTime FromDate, DateTime ToDate)
        {
            AppointmentStatus appStatus = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), status.ToUpper());
            var appointments = repo.GetAllAppointmentFilterWithStatus(doctorId, appStatus, FromDate, ToDate).ToList();
            ICollection<AppointmentCardDTO> result = new List<AppointmentCardDTO>();
            foreach (var appointment in appointments)
            {
                result.Add(service.ConvertToCardDTO(appointment));
            }
            return result;
        }

        public bool ChangeAppointmentStatus(AppointmentStatusDTO statusDTO)
        {
            var status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), statusDTO.Status.ToUpper());
            var result = false;
            if (status == AppointmentStatus.CONFIRMED)
            {
                result = repo.AcceptAppointment(statusDTO.AppointmentId);
            }
            else if (status == AppointmentStatus.CANCELLED)
            {
                result = repo.RejectApppointment(statusDTO.AppointmentId);
            }
            else
            {
                result = repo.CloseAppointment(statusDTO.AppointmentId);
            }
            return result;
        }

        public ICollection<AppointmentCardDTO> GetAllAppointmentsByRoleId(int roleId, string role, DateTime FromDate, DateTime ToDate)
        {
            ICollection<Appointment> appointments = new List<Appointment>();
            ICollection<AppointmentCardDTO> appointmentDTOs = new List<AppointmentCardDTO>();
            switch (role.ToLower())
            {
                case "petparent":
                    appointments = repo.GetAllAppointmentsByPetParentId(roleId, FromDate, ToDate);
                    break;
                case "vet":
                    appointments = repo.GetAllAppointmentsByVetId(roleId, FromDate, ToDate);
                    break;
                case "receptionist":
                    appointments = repo.GetAllAppointmentsByVetId(roleId, FromDate, ToDate);
                    break;
                default:
                    throw new InvalidRolesException("Role is Invalid!");
            }
            if(appointments.Count == 0||appointments == null)
            {
                throw new NoAppointmentFoundException("No Appointments Found");
            }
            foreach (var appointment in appointments)
            {
                appointmentDTOs.Add(service.ConvertToCardDTO(appointment));
            }
            return appointmentDTOs;
        }

        public bool CloseAppointment(int appointmentId)
        {
            var success = repo.CloseAppointment(appointmentId);
            return success;
        }


        public int GetAppointmentCount(int doctorId)
        {
            return repo.AppointmentCount(doctorId);
        }

        public int GetAppointmentCountBasedOnStatus(int doctorId, string status)
        {
            return repo.AppointmentCount(doctorId, status);
        }

        public ICollection<AppointmentCardDTO> GetAllAppointmentsByDate(int VetId , DateTime FromDate, DateTime ToDate)
        {
            ICollection<AppointmentCardDTO> appointmentCardDTOs = new List<AppointmentCardDTO>();
            var appointments = repo.GetAllAppointmentsByDate(VetId, FromDate, ToDate);
            if (appointments.Count() == 0 || appointments == null)
            {
                throw new NoAppointmentFoundException("No Appointments in given date slot");
            }
            foreach (var appointment in appointments)
            {
                appointmentCardDTOs.Add(service.ConvertToCardDTO(appointment));
            }
            return appointmentCardDTOs;
        }

        public ICollection<AppointmentCardDTO> GetAllAppointments()
        {
            ICollection<AppointmentCardDTO> appointmentCardDTOs = new List<AppointmentCardDTO>();
            var appointments = repo.GetAllAppointments();
            if (appointments == null || appointments.Count == 0) throw new NoAppointmentFoundException("No Appointments Found");
            foreach(var appointment in appointments)
            {
                appointmentCardDTOs.Add(service.ConvertToCardDTO(appointment));
            }
            return appointmentCardDTOs;
        }
        
        public AppointmentDTO GetAppointmentById(int AppointmentId)
        {
            var appointment = repo.GetAppointment(AppointmentId);
            AppointmentDTO dto = service.ConvertToAppointmentDTO(appointment);
            return dto;
        }

        public VitalDTO AddVital(VitalDTO vital)
        {
            
            var p = service.ConvertToVital(vital);
            vitalRepository.AddVitalByAppId(p);
            return service.ConvertToVitalDTO(p);
        }

        public VitalDTO EditVital(VitalDTO vital)
        {
            var vitals = service.ConvertToVital(vital);
            vitalRepository.UpdateVital(vitals);
            return service.ConvertToVitalDTO(vitals);
        }

        public VitalDTO GetVital(int VitalId)
        {
            var v = vitalRepository.GetVitalById(VitalId);
            return service.ConvertToVitalDTO(v);
        }

        public VitalDTO GetVitalByAppointmentId(int AppointmentId)
        {
            var v = vitalRepository.GetVitalByAppointmentId(AppointmentId);
            return service.ConvertToVitalDTO(v);
        }

        public TestDTO AddTest(TestDTO test)
        { 
            var t  = service.ConvertToTest(test);
            var Test1=  testRepository.AddTestyAppId(t);
            return service.ConvertTotestDTO(Test1);
        }
        
        public TestDTO UpdateTest(TestDTO test)
        {
            var t = service.ConvertToTest(test);
            var Test1 = testRepository.UpdateTest(t);
            return service.ConvertTotestDTO(Test1); 
        }

        public ICollection<TestDTO> GetAllTest()
        {
            var Tests = testRepository.GetAllTests();
            ICollection<TestDTO> TestDTO = new List<TestDTO>();
            foreach(var test in Tests)
            {
                TestDTO.Add(service.ConvertTotestDTO(test));
            }
            return TestDTO;
        }
        public SymptomDTO AddSymptom(SymptomDTO symptom )
        {
            var symptom1 = service.ConvertToSymptom(symptom);
            symptomRepository.AddSymptomByAppId(symptom1);
            return service.ConvertTOSymptomDTO(symptom1);
        }

        public SymptomDTO UpdateSymptom(SymptomDTO symptom)
        {
            var symptom1 = service.ConvertToSymptom(symptom);
            symptomRepository.UpdateSymptom(symptom1);
            return service.ConvertTOSymptomDTO(symptom1);   
        }

        public ICollection<SymptomDTO> GetAllSymptoms()
        {
            var symptoms = symptomRepository.GetAllSymptoms();
            return service.ConvertToListSymptomDTO(symptoms);
        }

    }
}