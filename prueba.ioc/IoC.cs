using prueba.aplicacion;
using prueba.dominio;
using prueba.dominio.aplicacion;
using prueba.dominio.repositorio;
using prueba.dominio.servicio;
using prueba.repositorio;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace prueba.ioc
{
    public static class IoC
    {
        private static Container container = null;
        static IoC()
        {
            container = new Container();
        }
        public static void Start()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            var lifeStyle = Lifestyle.Singleton;

            container.Register<ITareaAplicacion, TareaAplicacion>(lifeStyle);
            container.Register<ITareaRepositorio, TareaRepositorio>(lifeStyle);
            container.Register<ITareaServicio, TareaServicio>(lifeStyle);

            container.Register<IUnitOfWork, UnitOfWork>(lifeStyle);
            container.Register<PruebaDbContext>(lifeStyle);

            container.Verify();
        }

        public static T GetInstance<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }
}
