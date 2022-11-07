using Petzey.Model.Consultations;
using System;
using System.Data.Entity;
using System.Linq;

namespace Petzey.Repository.Consultations
{
    public class ConsultationContext : DbContext
    {
        // Your context has been configured to use a 'ConsultationContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Petzey.Repository.Consultations.ConsultationContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ConsultationContext' 
        // connection string in the application configuration file.
        public ConsultationContext()
            : base("name=ConsultationContext")
        {
        }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Vital> Vitals { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}