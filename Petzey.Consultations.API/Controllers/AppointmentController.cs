using Petzey.Bussiness.Consultations.Exceptions;
using Petzey.Bussiness.Consultations.Implementations;
using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.DTO.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Petzey.Consultations.API.Controllers
{
    [RoutePrefix("api/appointments")]
    public class AppointmentController : ApiController
    {
        private IAppointmentService service;
        public AppointmentController(IAppointmentService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("create")]
        [ResponseType(typeof(AppointmentCardDTO))]
        public IHttpActionResult AddAppointment(AppointmentCreateFormDTO jsonData)
        {
            AppointmentCardDTO result;
            try
            {
                result = service.CreateAppointment(jsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created($"api/appointment/{result.AppointmentId}", result);
        }

        /// <summary>
        /// Changes status from open to either closed or confirmed
        /// </summary>
        /// <param name="appointmentStatusDTO"></param>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("changestatus")]
        public IHttpActionResult ChangeStatus( AppointmentStatusDTO appointmentStatusDTO)
        {
            var result = service.ChangeAppointmentStatus(appointmentStatusDTO);
            var response = Request.CreateResponse(result ? HttpStatusCode.NoContent : HttpStatusCode.PreconditionFailed);
            return ResponseMessage(response);
        }

        /// <summary>
        /// Closes a appointment and create a feeback form
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        //[HttpPatch]
        //[Route("close")]
        //public IHttpActionResult CloseAppointment(int appointmentId)
        //{
        //    var res = service.CloseAppointment(appointmentId);
        //    if (!res)
        //    {
        //        return BadRequest();
        //    }
        //    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //}


        /// <summary>
        /// Gets appointment data(paginated)
        /// </summary>
        /// <param name="vetId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{doctorId}")]
        //[ResponseType(typeof(AppointmentBasicDetailsDTO))]
        //public IHttpActionResult GetAllAppointment(int doctorId)
        //{
        //    ICollection<AppointmentBasicDetailsDTO> appointments = service.GetAllAppointmentByDoctorId(doctorId);

        //    if (appointments.Count() == 0)
        //    {
        //        return Ok("No appointment");
        //    }
        //    var totalAppointmentCount = service.GetAppointmentCount(doctorId);
        //    var response = Request.CreateResponse(HttpStatusCode.OK, appointments);
        //    return ResponseMessage(response);
        //}

        /// <summary>
        /// Gets appointments data with a particular status
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="status"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAppointmentsByStatus/{vetId}/{status}/{FromDate}/{ToDate}")]
        [ResponseType(typeof(AppointmentCardDTO))]
        public IHttpActionResult GetAllAppointmentBasedOnStatus(int vetId, string status, DateTime FromDate, DateTime ToDate)
        {
            ICollection<AppointmentCardDTO> appointments = service.GetAllAppointmentFiltered(vetId, status, FromDate, ToDate);

            if (appointments.Count() == 0)
            {
                return NotFound();
            }
            var totalAppointmentCount = service.GetAppointmentCountBasedOnStatus(vetId, status);
            var response = Request.CreateResponse(HttpStatusCode.OK, appointments);
            return ResponseMessage(response);
        }

        /// <summary>
        /// Throws System.Exception. (Elmah Testing)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        //[HttpGet]
        //[Route("throwexception/elmah")]
        //public IHttpActionResult Throw()
        //{
        //    throw new System.Exception();
        //}

        [HttpGet]
        [Route("{vetId}/{FromDate}/{ToDate}")]
        [ResponseType(typeof(AppointmentCardDTO))]
        public IHttpActionResult GetAllAppointmentsByDate(int vetId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                ICollection<AppointmentCardDTO> appointmentCardDTOs = service.GetAllAppointmentsByDate(vetId, FromDate, ToDate);
                return Ok(appointmentCardDTOs);
            }
            catch (NoAppointmentFoundException nx)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getappointments/{roleId}/{role}/{FromDate}/{ToDate}")]
        [ResponseType(typeof(AppointmentCardDTO))]
        public IHttpActionResult GetAllAppointmentcardByRole(int roleId, string role, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                ICollection<AppointmentCardDTO> appointmentCardDTOs = service.GetAllAppointmentsByRoleId(roleId, role, FromDate, ToDate);
                return Ok(appointmentCardDTOs);
            }
            catch (NoAppointmentFoundException nx)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllAppointments")]
        public IHttpActionResult GetAllAppointments()
        {
            try
            {
                ICollection<AppointmentCardDTO> appointmentCardDTOs = service.GetAllAppointments();
                return Ok(appointmentCardDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getallDetails/{appointmentId}")]
        public IHttpActionResult GetAppointmentById(int appointmentId)
        {
            try
            {
                AppointmentDTO appointmentDTO = service.GetAppointmentById(appointmentId);
                if (appointmentDTO == null) return NotFound();
                return Ok(appointmentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addTest")]
        public IHttpActionResult AddTest([FromBody] TestDTO testDTO)
        {
            try
            {
                TestDTO result;
                result = service.AddTest(testDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Route("editTest")]
        //public IHttpActionResult UpdateTest(TestDTO Test)
        //{
        //    try
        //    {
        //        TestDTO result;
        //        result = service.UpdateTest(Test);
        //        return Ok(result);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("getAllTests")]
        public IHttpActionResult GetAllTests()
        {
            try
            {
                var result = service.GetAllTest();
                if(result == null|| result.Count==0) return NotFound();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AddSymptom")]
        public IHttpActionResult AddSymptom(SymptomDTO symptom)
        {
            try
            {
                SymptomDTO symptomDTO = service.AddSymptom(symptom);
                return Ok(symptomDTO);
            }
            catch(NotFoundException NotFound)
            {
                return BadRequest(NotFound.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Route("updateSymptom")]
        //public IHttpActionResult UpdateSymptom(SymptomDTO symptom)
        //{
        //    try
        //    {
        //        SymptomDTO symptomDTO = service.UpdateSymptom(symptom);
        //        return Ok(symptomDTO);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("getAllSymptom")]
        public IHttpActionResult GetAllSymptoms()
        {
            try
            {
                var result = service.GetAllSymptoms();
                if (result == null || result.Count == 0)
                {
                    return NotFound();
                }
                return Ok(result);  
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PostVital")]
        public IHttpActionResult AddVital(VitalDTO vitalDTO)
        {
            try
            {
                VitalDTO vitalDTO1 = service.AddVital(vitalDTO);
                return Ok(vitalDTO1);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Route("UpdateVitals")]
        //public IHttpActionResult UpdateVitals (VitalDTO vitalDTO)
        //{
        //    try
        //    {
        //        VitalDTO vital = service.EditVital(vitalDTO);
        //        return Ok(vital);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("GetVitals/{vitalId}")]
        public IHttpActionResult GetVitals(int vitalId)
        {
            try
            {
                VitalDTO vital = service.GetVital(vitalId);
                if (vital == null) return NotFound();
                return Ok(vital);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //[HttpGet]
        //[Route("GetallVitals/{appointmentId}")]
        //public IHttpActionResult GetVitalsByAppoinmentId(int appointmentId)
        //{
        //    try
        //    {
        //        VitalDTO vital = service.GetVitalByAppointmentId(appointmentId);
        //        if (vital == null) return NotFound();
        //        return Ok(vital);
        //    }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

    }
}
