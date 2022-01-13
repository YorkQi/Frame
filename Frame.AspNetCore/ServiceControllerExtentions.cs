using Frame.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Frame.AspNetCore
{
    public static class ServiceControllerExtentions
    {
        /// <summary>
        /// 根据模组自动注入对应模组
        /// </summary>
        /// <typeparam name="TMoudle"></typeparam>
        /// <param name="app"></param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        public static IServiceCollection AutoModuleServiceCollection<TMoudle>(this IServiceCollection app)
            where TMoudle : IModule, new()
        {
            Assembly? assembly = Assembly.GetAssembly(typeof(TMoudle));

            if (assembly is null) throw new ArgumentNullException(nameof(assembly));

            AutoDependencyInjection(assembly);

            //自动注入
            void AutoDependencyInjection(Assembly? assembly)
            {
                if (assembly is null) throw new ArgumentNullException(nameof(assembly));

                Type[] types = assembly.GetExportedTypes();
                foreach (Type type in types)
                {
                    if (type.IsPublic || type.IsClass || type.IsAbstract)
                    {
                        var imps = type.GetInterfaces();
                        if (imps.Any(t => t.Equals(typeof(ITransientInstance))))
                        {
                            app.AddTransient(type);
                        }
                        else if (imps.Any(t => t.Equals(typeof(ISingletonInstance))))
                        {
                            app.AddSingleton(type);
                        }
                        else if (imps.Any(t => t.Equals(typeof(IScopedInstance))))
                        {
                            app.AddScoped(type);
                        }
                    }
                }
            }

            return app;
        }


        /// <summary>
        /// 遍历所有的程序集注入
        /// 【此方式性能不好，遍历了所有的引用程序集】
        /// </summary>
        /// <typeparam name="TMoudle"></typeparam>
        /// <param name="app"></param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        public static IServiceCollection AutoServiceCollection<TMoudle>(this IServiceCollection app)
            where TMoudle : IModule, new()
        {
            Assembly? assembly = Assembly.GetAssembly(typeof(TMoudle));

            if (assembly is null) throw new ArgumentNullException(nameof(assembly));

            AutoDependencyInjection(assembly);

            var referencedAssemblies = assembly.GetReferencedAssemblies();
            foreach (var item in referencedAssemblies)
            {
                Assembly? itemAssembly = Assembly.Load(item);
                AutoDependencyInjection(itemAssembly);
            }

            //自动注入
            void AutoDependencyInjection(Assembly? assembly)
            {
                if (assembly is null) throw new ArgumentNullException(nameof(assembly));

                Type[] types = assembly.GetExportedTypes();
                foreach (Type type in types)
                {
                    var imps = type.GetInterfaces();
                    if (imps.Any(t => t.Equals(typeof(ITransientInstance))))
                    {
                        app.AddTransient(type);
                    }
                    else if (imps.Any(t => t.Equals(typeof(ISingletonInstance))))
                    {
                        app.AddSingleton(type);
                    }
                    else if (imps.Any(t => t.Equals(typeof(IScopedInstance))))
                    {
                        app.AddScoped(type);
                    }
                }
            }


            return app;
        }
    }
}
