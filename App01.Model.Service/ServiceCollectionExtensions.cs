using App01.Model.Domain;
using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;
using App01.Model.Infra.Data.Context.EF;
using App01.Model.Infra.Data.Repositories;
using App01.Model.Infra.Data.Repositories.EF;
using App01.Model.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace App01.Model.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }

        public static void RegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<DbContext, MyContext>();
            services.AddTransient<IEFUnitOfWork, EFUnitOfWork>();

            services.RegisterAllTypes<IUserRepository>(new[] { typeof(IUserRepository).Assembly, typeof(UserRepository).Assembly });
            services.RegisterAllTypes<IUserService>(new[] { typeof(ServiceCollectionExtensions).Assembly });

        }
    }
}
