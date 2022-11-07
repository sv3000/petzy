using Petzey.Bussiness.Consultations.Implementations;
using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.Bussiness.Consultations.MappingService;
using Petzey.Bussiness.Consultations.MappingService.Implementations;
using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.Repository.Consultations;
using Petzey.Repository.Consultations.Implementations;
using Petzey.Repository.Consultations.Interfaces;
using System;

using Unity;

namespace Petzey.Consultations.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<IPrescriptionRepository, PrescriptionRepository>();
            container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            container.RegisterType<IVitalRepository, VitalRepository>();
            container.RegisterType<ISymptomRepository, SymptomRepository>();
            container.RegisterType<ITestRepository, TestRepository>();

            container.RegisterType<IAppointmentMappingService, AppointmentMappingService>();
            container.RegisterType<IPrescriptionMappingService, PrescriptionMappingService>();
            container.RegisterType<IPrescriptionService, PrescriptionService>();
            


        }
    }
}