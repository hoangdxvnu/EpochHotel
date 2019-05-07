using System.Web.Mvc;
using HAHotel.Repository;
using HAHotel.Repository.Common;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace HAHotel
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // e.g. container.RegisterType<ITestService, TestService>();   
            container.RegisterInstance<IDatabase>(new SqlServerDatabase(new SqlServerConfig
            {
                ConnectionString = "data source=112.78.2.94; database=epo67162_hotel;uid=epo67162_hotel;pwd=Dvg@xh22121991; pooling=true; max pool size=500; min pool size=10;",
                Timeout = "300"
            }));

            container.RegisterType<ILayoutRepository, LayoutRepository>(new TransientLifetimeManager());
            container.RegisterType<IRoomTypeRepository, RoomTypeRepository>(new TransientLifetimeManager());

            return container;
        }
    }
}