using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Implementations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations
{
    public class TestRepository:ITestRepository
    {
        public Test AddTestyAppId(Test TestToSave)
        {
            using (var db = new ConsultationContext())
            {
                db.Tests.Add(TestToSave);
                db.SaveChanges();
                return TestToSave;
            }
        }

        public Test UpdateTest(Test TestToUpdate)
        {
            using (var db = new ConsultationContext())
            {
                var Test = db.Tests.Find(TestToUpdate.Id);
                if (TestToUpdate == null) throw new NotFoundException();
                db.Entry(TestToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return TestToUpdate;
            }
        }

        public bool DeleteTest(int TestId)
        {
            using (var db = new ConsultationContext())
            {
                var Test = db.Tests.Find(TestId);
                db.Tests.Remove(Test);
                return db.SaveChanges() > 0;
            }
        }

        public Test GetTestById(int testId)
        {
            using (var db = new ConsultationContext())
            {
                var Test = db.Tests.Find(testId);
                return Test;
            }
        }

        public ICollection<Test> GetTestsByAppoointmentId(int appointmentId)
        {
            using (var db = new ConsultationContext())
            {
                var appointment = db.Appointments.Find(appointmentId);
                return appointment.Test.ToList();
            }
        }

        public ICollection<Test> GetAllTests()
        {
            using (var db = new ConsultationContext())
            {
                var tests = db.Tests.ToList();
                return tests;
            }
        }
    }
}
