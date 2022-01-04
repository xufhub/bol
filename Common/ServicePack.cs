using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ServicePack
    {
        public static void Pack(IServiceCollection services)
        {
            string[] filters = new string[8]
           {
                "mscorlib",
                "netstandard",
                "dotnet",
                "api-ms-win-core",
                "runtime.",
                "System",
                "Microsoft",
                "Window"
           };
            var list = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly).ToList();
            var assemblys = list.Where((string file) => filters.All(delegate (string token)
            {
                string? fileName = Path.GetFileName(file);
                return fileName == null || !fileName!.StartsWith(token);
            })).Select(Assembly.LoadFrom).ToArray();

            var tt = assemblys.SelectMany(a => a.GetTypes().Where(t => typeof(IBolDependency).IsAssignableFrom(t)))
                .ToArray();

            //var assemblys = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(a => a.GetTypes().Where(t => typeof(IBolDependency).IsAssignableFrom(t)))
            //    .ToArray();

            var typeClassList = tt.Where(a => a.IsClass && !a.IsAbstract && !a.IsInterface).ToList();
            typeClassList.ForEach(t =>
            {
                var interfaceType = tt.FirstOrDefault(a => a.Name == $"I{t.Name}" && a.IsInterface);
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, t);
                }
            });
        }
    }
}
