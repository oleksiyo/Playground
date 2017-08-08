using System;
using System.Collections.Generic;
using System.Reflection;
using CQRSDemoApp.Command;
using CQRSDemoApp.Dtos;
using CQRSDemoApp.Query;
using SimpleInjector;

namespace CQRSDemoApp
{
    public class DependencyResolver : IDependencyResolver
    {
        private static readonly Container container;

        static DependencyResolver()
        {
            container = new Container();
        }
        public DependencyResolver()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            container.Register(typeof(ICommandHandler<>), assemblies);
            container.Register(typeof(IQueryHandler<,>), assemblies);
            container.Register(typeof(ICommandDispatcher), assemblies);

            container.Register<IRepository<Inventory>, MemoryRepository<Inventory>>();
          //  container.Register(typeof(IRepository<>), assemblies);
          // MemoryRepository
          // container.Register<IRepository<>, MemoryRepository<>>(Lifestyle.Singleton);
        //    container.Register(typeof(IRepository<>), typeof(MemoryRepository<>));
            // container.Register(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            // container.Register(typeof(IQueryHandler<,>), AppDomain.CurrentDomain.GetAssemblies());

            container.Verify();
        }
        public object GetService(Type serviceType)
        {
           return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }

    public interface IDependencyResolver
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
        T Resolve<T>() where T : class;
    }

    public class Resolver
    {
        public static Container Bootstrap()
        {
            var container = new Container();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //   container.Register(typeof(ICommandHandler<CreateInventory>), assemblies);
            //    container.Register<ICommandHandler<CreateInventory>, InventoryCommandHandler>();
            //      container.Register(typeof(ICommandHandler<>), assemblies);

              container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly });
            // container.Register(typeof(IQueryHandler<,>), assemblies);
          //  container.Register(typeof(IRepository<>), new[] {typeof(IRepository<>).Assembly});
            container.Register(typeof(IRepository<>), typeof(MemoryRepository<>));
            container.Register(typeof(IQueryHandler<,>), new[] { typeof(IQueryHandler<,>).Assembly });
            container.Register<IQueryDispatcher, QueryDispatcher>();
            container.Register<ICommandDispatcher, CommandDispatcher>();
            // var t = new[] { typeof(IRepository<>).Assembly };
            //  container.Register<IRepository<Inventory>, MemoryRepository<Inventory>>();
            //   container.Register(typeof(IRepository<>), new[] { typeof(IRepository<>).Assembly });

            //  container.Register(typeof(IRepository<>), assemblies);
            // MemoryRepository
            // container.Register<IRepository<>, MemoryRepository<>>(Lifestyle.Singleton);
            //    container.Register(typeof(IRepository<>), typeof(MemoryRepository<>));
            // container.Register(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            // container.Register(typeof(IQueryHandler<,>), AppDomain.CurrentDomain.GetAssemblies());

            container.Verify();
            return container;
        }
    }
}