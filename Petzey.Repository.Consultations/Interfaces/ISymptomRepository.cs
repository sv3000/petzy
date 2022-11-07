using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Interfaces
{
    public interface ISymptomRepository
    {
        bool UpdateSymptom(Symptom symptom);
        Symptom AddSymptomByAppId(Symptom symptomToSave);
        ICollection<Symptom> GetSymptomsByAppoointmentId(int appointmentId);
        Symptom GetSymptomById(int symptomId);
        bool DeleteSymptom(int symptomId);
        ICollection<Symptom> GetAllSymptoms();
       
    }
}
