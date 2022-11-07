using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.DTO.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Petzey.Consultations.API.Controllers
{
    [RoutePrefix("api/prescription")]
    public class PrescriptionController : ApiController
    {
        IPrescriptionService service;
        public PrescriptionController(IPrescriptionService service)
        {
            this.service = service;
        }

        //[HttpPatch]
        //[Route("AddPrescription/{appointmentId}")]
        //public IHttpActionResult AddPrescription(PrescriptionDTO prescription ,int appointmentId)
        //{
        //    try
        //    {
        //        PrescriptionDTO dto =  service.AddPrescription(prescription, appointmentId);
        //        if (!ModelState.IsValid) return BadRequest();
        //        return Created("", dto);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("addmedicine")]
        public IHttpActionResult AddMedicine([FromBody] AddMedicineDTO medicineDTO )
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                AddMedicineDTO dto = service.AddMedicine(medicineDTO );
                return Created($"api/prescription/GetMedicine/{dto.MedicineId}", dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Route("editPrescription")]
        //public IHttpActionResult EditPrescription(PrescriptionDTO prescription)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest();
        //        else
        //        {
        //            PrescriptionDTO dto = service.EditPrescription(prescription);
        //            return Ok(dto);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("GetMedicine/{id}")]
        public IHttpActionResult GetMedicine(int Id)
        {
            try
            {
                AddMedicineDTO dto = service.GetMedicine(Id);
                if(dto == null) return NotFound();
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllmedicines/{prescriptionId}")]
        public IHttpActionResult GetAllMedicinesByPrescriptionId(int prescriptionId)
        {
            try
            {
                ICollection<AddMedicineDTO> dto = service.GetAllMedicinesByPrescription(prescriptionId);
                if(dto==null||dto.Count==0) return NotFound();
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
