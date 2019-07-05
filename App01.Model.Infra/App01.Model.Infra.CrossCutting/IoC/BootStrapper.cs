using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;
using App01.Model.Infra.Data.Context.EF;
using App01.Model.Infra.Data.Repositories;
using App01.Model.Infra.Data.Repositories.EF;
using App01.Model.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using MediatR;
using System;
using AutoMapper;

namespace App01.Model.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {


        public static void RegisterServices(IServiceCollection services)
        {
      
            services.AddMediatR(typeof(BootStrapper));
            services.AddAutoMapper(typeof(BootStrapper));

            services.AddSingleton<DbContext, MyContext>();
            services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

            services.RegisterAllTypes<IUserRepository>(new[] { typeof(IUserRepository).Assembly, typeof(UserRepository).Assembly });
            services.RegisterAllTypes<IUserService>(new[] { typeof(UserService).Assembly });
            services.AddScoped<NotificationContext>();
        }

        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }

    }
}