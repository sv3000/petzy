using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Interfaces
{
    public interface ITestRepository
    {
        Test AddTestyAppId(Test TestToSave);
        Test UpdateTest(Test TestToUpdate);
        bool DeleteTest(int TestId);
        Test GetTestById(int testId);
        ICollection<Test> GetTestsByAppoointmentId(int appointmentId);
        ICollection<Test> GetAllTests();
    }
}
