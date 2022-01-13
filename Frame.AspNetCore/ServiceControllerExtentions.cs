using Frame.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Frame.AspNetCore
{
    public static class ServiceControllerExtentions
    {
        public static IServiceCollection AutoServiceCollection<TMoudle>(this IServiceCollection app)
            where TMoudle : AutoModule, new()
        {
            var module = new TMoudle();
            module.Load();
            foreach (var item in AutoModule._Modules)
            {
                Assembly? assembly = Assembly.GetAssembly(item);
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
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
                else
                {
                    throw new WebException("无自动注入对象");
                }
            }

            return app;
        }
    }
}
