using Frame.Scheduler;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScheduler();

var app = builder.Build();
List<SchedulerOption> options = new List<SchedulerOption>();

Assembly? assembly = Assembly.GetAssembly(typeof(Program));
if (assembly is null) throw new ArgumentNullException("程序集为空无法注入");
Type[] types = assembly.GetExportedTypes();
foreach (Type type in types)
{
    if (type.IsPublic || type.IsClass || type.IsAbstract)
    {
        var imps = type.GetInterfaces();
        if (imps.Any(t => t.Equals(typeof(ISchedulerJob))))
        {
            options.Add(new SchedulerOption() { SchedulerAssmbly = type.Name, SchedulerName = type.Name, SchedulerGroupName = "DEFULT" });
        }
    }
}
app.AddScheduler(options).SchedulerStart();

app.Run();
