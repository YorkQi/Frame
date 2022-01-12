using Frame.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Frame.AspNetCore
{
    public static class ServiceControllerExtentions
    {
        public static void AutoServiceCollection<TMoudle>(this IServiceCollection app)where TMoudle 
            : IModule, new()
        {
            Assembly? imp = Assembly.GetAssembly(typeof(TMoudle));
            if (imp != null)
            {
                Type[] types = imp.GetTypes();
                foreach (Type type in types)
                {
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Any(t => t.Equals(typeof(IModule))) && interfaces.Any(t => t.Equals(typeof(ITransientInstance))))
                    {
                        app.AddTransient(type);
                    }
                    else if (interfaces.Any(t => t.Equals(typeof(IModule))) && interfaces.Any(t => t.Equals(typeof(ISingletonInstance))))
                    {
                        app.AddSingleton(type);
                    }
                    else if (interfaces.Any(t => t.Equals(typeof(IModule))) && interfaces.Any(t => t.Equals(typeof(IScopedInstance))))
                    {
                        app.AddScoped(type);
                    }
                }
            }
            else
            {
                throw new ApplicationException("无自动注入对象");
            }

            #region Old

            //var types=typeof(TModule).GetInterfaces();
            //if (types != null)
            //{
            //    foreach (var item in types)
            //    {
            //        var interfaces = item.GetInterfaces();
            //        if (interfaces.Any(t => t.Equals(typeof(IModule))))
            //        {
            //            foreach (var impItem in types)
            //            {
            //                var impInterfaces = impItem.GetInterfaces();
            //                if (impInterfaces.Any(t => t.Equals(typeof(ITransientInstance))))
            //                {
            //                    app.AddTransient(item);
            //                }
            //                else if (impInterfaces.Any(t => t.Equals(typeof(ISingletonInstance))))
            //                {
            //                    app.AddSingleton(item);
            //                }
            //                else if (impInterfaces.Any(t => t.Equals(typeof(IScopedInstance))))
            //                {
            //                    app.AddScoped(item);
            //                }
            //            }
            //        }
            //    }
            //}

            #endregion
        }
    }
}
