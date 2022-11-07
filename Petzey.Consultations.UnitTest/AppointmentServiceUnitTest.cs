using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petzey.Bussiness.Consultations.Implementations;
using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.Consultations.API.Controllers;
using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Petzey.Consultations.UnitTest
{
    [TestClass]
    public class AppointmentServiceUnitTests
    {
        private Mock<IAppointmentRepository> appointmentMock;
        private Mock<IPrescriptionRepository> prescriptionMock;
        private Mock<ISymptomRepository> symptomMock;
        private Mock<ITestRepository> testMock;
        private Mock<IVitalRepository> vitalMock;
        private Mock<IAppointmentMappingService> serviceMock;


        public AppointmentServiceUnitTests()
        {
            appointmentMock = new Mock<IAppointmentRepository>();
            prescriptionMock = new Mock<IPrescriptionRepository>();
            symptomMock = new Mock<ISymptomRepository>();
            testMock = new Mock<ITestRepository>();
            vitalMock = new Mock<IVitalRepository>();
            serviceMock = new Mock<IAppointmentMappingService>();
        }

        AppointmentCreateFormDTO AppointmentCreateDto;
        Appointment AllDetails; 

        [TestInitialize]
        public void Initialize()
        {
             AllDetails = new Appointment
            {
                AppointmentDate = new DateTime(18 / 08 / 2022),
                AppointmentTime = TimeSpan.Parse("10:00"),
                VetDetails = new Vet
                {
                    Id = 1,
                    Name = "Kumar",
                    Speciality = "Navle",
                    PhoneNo = "99999",
                    VetId = 1
                },
                Status = AppointmentStatus.OPEN,
                Issue = "Hand Injury",
                PetParent = new PetParent { Id = 1,PetParentId = 1, Name = "Subham" },
             //   Comment = "Food Intake Need To be Monitored",
                Pet = new Pet()
                {
                    DOB = new DateTime(12 / 08 / 2022),
                    Gender = Gender.MALE,
                    PetId = 1,
                    Id  = 1,
                    PetName = "Doggo"
                },
                Reason = "Dog was sick from past 2 days",

            };

            //AppointmentDTO AppointmentDTO = new AppointmentDTO()
            //{
            //    AppointmentId = 0,
            //    Comment = "Food Intake Need To be Monitored",
            //    Symptom = "TestSymptom",AppointmentDate
            //}
            //AppointmentCardDTO dto = new AppointmentCardDTO()
            //{
            //      AppointmentId: 1027,
            //      PetId: 1,
            //      PetName: "string",
            //      Gender: "FEMALE",
            //      "OwnerName": "string",
            //      "AppointmentDate": "2022-08-20T00:00:00",
            //      "AppointmentTime": "10:00:00",
            //      "PetDOB": "2022-08-19T02:32:33.395Z",
            //      "VetId": 1,
            //      "VetName": "string",
            //      "VetSpeciality": "string" 
            //}

             AppointmentCreateDto = new AppointmentCreateFormDTO()//What we are passing
            {
                AppointmentDate = new DateTime(18 / 08 / 2022),
                AppointmentTime = TimeSpan.Parse("10:00"),
                Issue = "Hand Injury", Parent = new PetParentDTO { ParentID = 1 , ParentName  = "Subham"},
                Pet = new PetDTO()
                {
                    DOB = new DateTime(12 / 08 / 2022),
                    Gender = "Male",
                    PetId = 1,
                    PetName = "Doggo"
                },
                Reason = "Dog was sick from past 2 days",
                Vet = new VetDTO()
                {
                    PhoneNo = "99999", Speciality = "Navle", VetId = 1, VetName = "Kumar"
                }
            };


        }

        [TestCleanup]
        public void CleanUP()
        {
            AllDetails = null;
            AppointmentCreateDto = null;
        }
        //private ICollection<Appointment> AllAppointmentDetails()
        //{
        //    ICollection<Appointment> appointments = new List<Appointment>()
        //}

        private ICollection<Appointment> DummyAppointments()
        {
            ICollection<Appointment> appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = new DateTime(18 / 08 / 2022),
                    AppointmentTime = TimeSpan.Parse("10:00"),
                    VetDetails = new Vet
                    {
                        Id = 1,
                        Name = "Kumar",
                        Speciality = "Navle",
                        PhoneNo = "99999",
                        VetId = 1
                    },
                    Status = AppointmentStatus.OPEN,
                    Issue = "Hand Injury",
                    PetParent = new PetParent { Id = 1, PetParentId = 1, Name = "Subham" },
                    //   Comment = "Food Intake Need To be Monitored",
                    Pet = new Pet()
                    {
                        DOB = new DateTime(12 / 08 / 2022),
                        Gender = Gender.MALE,
                        PetId = 1,
                        Id = 1,
                        PetName = "Doggo"
                    },
                    Reason = "Dog was sick from past 2 days",
                },
                new Appointment()
                {
                    Id=2,
                    AppointmentDate = new DateTime(18 / 08 / 2022),
                    AppointmentTime = TimeSpan.Parse("10:00"),
                    VetDetails = new Vet
                    {
                        Id = 2,
                        Name = "Suraj",
                        Speciality = "Navle",
                        PhoneNo = "88888",
                        VetId = 2
                    },
                    Status = AppointmentStatus.OPEN,
                    Issue = "Hand Injury",
                    PetParent = new PetParent { Id = 2, PetParentId = 2, Name = "Sindhu" },
                    //   Comment = "Food Intake Need To be Monitored",
                    Pet = new Pet()
                    {
                        DOB = new DateTime(12 / 08 / 2022),
                        Gender = Gender.MALE,
                        PetId = 2,
                        Id = 2,
                        PetName = "Lizo"
                    },
                    Reason = "Test Reason",

                },
                new Appointment()
                {
                    Id=3,
                    AppointmentDate = new DateTime(18 / 08 / 2022),
                    AppointmentTime = TimeSpan.Parse("10:00"),
                    VetDetails = new Vet
                    {
                        Id = 1,
                        Name = "Vinod",
                        Speciality = "Navle",
                        PhoneNo = "77777",
                        VetId = 1
                    },
                    Status = AppointmentStatus.CLOSED,
                    Issue = "Hand Injury",
                    PetParent = new PetParent { Id = 3, PetParentId = 3, Name = "Vinod" },
                    //   Comment = "Food Intake Need To be Monitored",
                    Pet = new Pet()
                    {
                        DOB = new DateTime(12 / 08 / 2022),
                        Gender = Gender.MALE,
                        PetId = 3,
                        Id = 3,
                        PetName = "Mozo"
                    },
                    Reason = "Sick from 3 days",
                },
            };
            return appointments;
        }
             
        
        public void CreateAppointment_ShouldThrowAppointmentDateTimeException_OldDate()
        {
            //Arrange 

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(x => new Appointment()
                {
                    AppointmentDate = new DateTime(18 / 08 / 2022),
                    AppointmentTime = TimeSpan.Parse("10:00"),
                    VetDetails = new Vet
                    {
                        Id = 1,
                        Name = "Kumar",
                        Speciality = "Navle",
                        PhoneNo = "99999",
                        VetId = 1
                    },
                    Status = AppointmentStatus.OPEN,
                    Issue = "Hand Injury",
                    PetParent = new PetParent { Id = 1, PetParentId = 1, Name = "Subham" },
                    //   Comment = "Food Intake Need To be Monitored",
                    Pet = new Pet()
                    {
                        DOB = new DateTime(12 / 08 / 2022),
                        Gender = Gender.MALE,
                        PetId = 1,
                        Id = 1,
                        PetName = "Doggo"
                    },
                    Reason = "Dog was sick from past 2 days",
                });
        }

        [TestMethod]
        public void GetAllAppointments_ItemCountShouldBeEqualToCountAsked()
        {
            //Arrange
            appointmentMock.Setup(m => m.GetAllAppointments()).Returns(DummyAppointments());
            var appointmentservice = new AppointmentService(appointmentMock.Object,serviceMock.Object,prescriptionMock.Object, vitalMock.Object,testMock.Object,symptomMock.Object);

            //Act
            var expected = appointmentservice.GetAllAppointments();

            //Assert
            Assert.AreEqual(3,expected.Count());
        }

        [TestMethod]
        public void GetAllAppointmentsByVetid_ItemCountShouldBeEqualToCountAsked()
        {
            //Arrange 
            DateTime FromDate = DateTime.Now;
            DateTime ToDate = DateTime.Now;
            appointmentMock.Setup(m => m.GetAllAppointmentsByVetId(1, FromDate, ToDate)).Returns(DummyAppointments().Where(a=>a.VetDetails.VetId==1).ToList());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);

            //Act
            var expected = appointmentservice.GetAllAppointmentsByRoleId(1, "vet", FromDate, ToDate);

            //Assert
            Assert.AreEqual( 2 ,expected.Count());
        }

        //[TestMethod]
        //public void GetAppointmentByAppointmentId()
        //{
        //    //Arrange 
        //    appointmentMock.Setup(a => a.GetAppointment(1)).Returns(DummyAppointments().Where(a => a.Id == 1).First());
        //    var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);

        //    //Act
        //    var expected = appointmentservice.GetAppointmentById(1);

        //    //Assert
        //    Assert.AreEqual(1 ,expected.AppointmentId );
        //}

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeClosed()
        {
            DateTime fromdate = new DateTime(2022, 08, 12);
            DateTime todate = new DateTime(2022, 08, 18);
            appointmentMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CLOSED, fromdate, todate))
                .Returns(DummyAppointments().Where(x => x.Status == AppointmentStatus.CLOSED).ToList());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.GetAllAppointmentFiltered(1, AppointmentStatus.CLOSED.ToString(), fromdate, todate);

            Assert.AreEqual(expected.Count, 1);
            // Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "OPEN");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeOPEN()
        {
            DateTime fromdate = new DateTime(2022, 08, 12);
            DateTime todate = new DateTime(2022, 08, 18);
            appointmentMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.OPEN,fromdate,todate))
                .Returns(DummyAppointments().Where(x => x.Status == AppointmentStatus.OPEN).ToList());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.GetAllAppointmentFiltered(1, AppointmentStatus.OPEN.ToString(),fromdate,todate);

            Assert.AreEqual(expected.Count, 2);
           // Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "OPEN");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeCancelled ()
        {
            DateTime fromdate = new DateTime(2022, 08, 12);
            DateTime todate = new DateTime(2022, 08, 18);
            appointmentMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CANCELLED, fromdate, todate))
                .Returns(DummyAppointments().Where(x => x.Status == AppointmentStatus.CANCELLED).ToList());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.GetAllAppointmentFiltered(1, AppointmentStatus.CANCELLED.ToString(), fromdate, todate);

            Assert.AreEqual(expected.Count, 0);
            // Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "OPEN");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeConfirmed()
        {
            DateTime fromdate = new DateTime(2022, 08, 12);
            DateTime todate = new DateTime(2022, 08, 18);
            appointmentMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CONFIRMED, fromdate, todate))
                .Returns(DummyAppointments().Where(x => x.Status == AppointmentStatus.CONFIRMED).ToList());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.GetAllAppointmentFiltered(1, AppointmentStatus.CONFIRMED.ToString(), fromdate, todate);

            Assert.AreEqual(expected.Count, 0);
            // Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "OPEN");
        }

        [TestMethod]
        public void GetAllAppointments_ReturnedObjectShouldBeCollectionOfAppointmentBasicInfoDTO()
        {
            DateTime fromdate = new DateTime(2022, 08, 12);
            DateTime todate = new DateTime(2022, 08, 18);
            appointmentMock.Setup(m => m.GetAllAppointmentsByVetId(1,fromdate,todate))
                .Returns(DummyAppointments());
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.GetAllAppointmentsByRoleId(1,"vet",fromdate,todate);

            Assert.IsInstanceOfType(expected, typeof(ICollection<AppointmentCardDTO>));
        }

        

        [TestMethod]
        public void ChangeAppointmentStatus_StatusCONFIRMEDPassedAsParameter_ShouldReturnTrueAppointmentCofirmed()
        {
            appointmentMock.Setup(m => m.AcceptAppointment(1))
                .Returns(true);

            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);

            var expected = appointmentservice.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "confirmed"
            });

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void ChangeAppointmentStatus_StatusCANCELLEDPassedAsParameter_ShouldReturnTrueAppointmentCancelled()
        {
            appointmentMock.Setup(m => m.RejectApppointment(1))
                .Returns(true);

            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "CANCELLED"
            });

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void ChangeAppointmentStatus_StatusOPENPassedAsParameter_ShouldReturnFalse()
        {
            appointmentMock.Setup(m => m.RejectApppointment(1))
                .Returns(true);

            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "OPen"
            });

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void CloseAppointment_ShouldReturnTrue()
        {
            appointmentMock.Setup(m => m.CloseAppointment(1))
                .Returns(true);
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.CloseAppointment(1);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void CloseAppointment_ShouldReturnFalse()
        {
            appointmentMock.Setup(m => m.CloseAppointment(1))
                .Returns(false);
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var expected = appointmentservice.CloseAppointment(1);
            Assert.IsFalse(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoPetId()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",Parent = new PetParentDTO { ParentID = 1, ParentName = "TestParent"},Pet=new PetDTO { PetId = 0, PetName = "TestPet"}
                ,Vet = new VetDTO { VetId = 1, PhoneNo = "9999" ,VetName = "TestName"}
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1,Name = "TestVet"},
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent",Id = 1},
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoVetId()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "TestParent" },
                Pet = new PetDTO { PetId = 1, PetName = "TestPet" }
                ,
                Vet = new VetDTO { VetId = 0, PhoneNo = "9999", VetName = "TestName" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoPetParentName()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "" },
                Pet = new PetDTO { PetId = 1, PetName = "TestPet" }
                ,
                Vet = new VetDTO { VetId = 0, PhoneNo = "9999", VetName = "TestName" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoPetName()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "TestPet" },
                Pet = new PetDTO { PetId = 1, PetName = "" }
                ,
                Vet = new VetDTO { VetId = 0, PhoneNo = "9999", VetName = "TestName" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoVetName()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "TestPet" },
                Pet = new PetDTO { PetId = 1, PetName = "" }
                ,
                Vet = new VetDTO { VetId = 0, PhoneNo = "9999", VetName = "" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);
        }

        [TestMethod]
        [ExpectedException(typeof(AppointmentDatetimeException))]
        public void CreateAppointment_ShouldThrowAppointmentDatetimeException_OldDate()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = new DateTime(2022,07,12),
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "TestParent" },
                Pet = new PetDTO { PetId = 1, PetName = "TestPet" }
                ,
                Vet = new VetDTO { VetId = 1, PhoneNo = "9999", VetName = "TestName" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);

        }

        

        [TestMethod]
        [ExpectedException(typeof(AppointmentDatetimeException))]
        public void CreateAppointment_ShouldThrowAppointmentDatetimeException_CurrentDateButBackTime()
        {
            //Arrange

            var appointmentForm = new AppointmentCreateFormDTO()
            {
                AppointmentDate = new DateTime(2022, 08, 19),
                AppointmentTime = TimeSpan.Parse("12:10:00"),
                Issue = "TestIssue",
                Parent = new PetParentDTO { ParentID = 1, ParentName = "TestParent" },
                Pet = new PetDTO { PetId = 1, PetName = "TestPet" }
                ,
                Vet = new VetDTO { VetId = 1, PhoneNo = "9999", VetName = "TestName" }
            };

            appointmentMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00:00"),
                    VetDetails = new Vet { VetId = 1, Name = "TestVet" },
                    Pet = new Pet { PetName = "TestPet", PetId = 1, },
                    PetParent = new PetParent { Name = "TestPetParent", Id = 1 },
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }); ;
            var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);
            var confirmedAppointment = appointmentservice.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        public void GetAppointmentDetails_ShouldReturnsNotFound()
        {
            var mockRepository = new Mock<IAppointmentService>();
            var controller = new AppointmentController(mockRepository.Object);

            //Act
            IHttpActionResult actionResult = controller.GetAppointmentById(1);



            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }


     
        //[TestMethod]
        //public void GetAllAppointmentByDate_ReturnNoAppointmentFoundException_OldDate()
        //{
        //    DateTime FromDate = new DateTime(11, 07, 22);
        //    DateTime ToDate  = new DateTime(12,07,22);
        //    //Arrange
        //    appointmentMock.Setup(m => m.GetAllAppointmentsByDate(1, FromDate, ToDate));
        //    var appointmentservice = new AppointmentService(appointmentMock.Object, serviceMock.Object, prescriptionMock.Object, vitalMock.Object, testMock.Object, symptomMock.Object);

        //    //Act
        //    var expected = appointmentservice.GetAllAppointmentsByDate(1, FromDate, ToDate);

        //    //Assert
        //    Assert.AreEqual(, expected);
        //}



    }
}
