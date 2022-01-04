using EFCore.Mysql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            AppSetting.Init(services);
            ServicePack.Pack(services);
            RepositoryPack.Pack(services);
        }
    }
}
