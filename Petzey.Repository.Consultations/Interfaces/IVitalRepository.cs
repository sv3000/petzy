using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Interfaces
{
    public interface IVitalRepository
    {
        Vital AddVitalByAppId(Vital VitalToSave);
        Vital UpdateVital(Vital VitalToUpdate);
        bool DeleteVital(int vitalId);
        Vital GetVitalById(int vitalId);
        Vital GetVitalByAppointmentId(int appointmentId);
    }
}