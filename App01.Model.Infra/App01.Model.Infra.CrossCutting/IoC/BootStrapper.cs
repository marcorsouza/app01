using System;
using System.Linq;
using System.Reflection;
using App01.Model.Domain;
using App01.Model.Domain.Repositories;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features;
using App01.Model.Infra.CrossCutting.Features.UserFeatures;
using App01.Model.Infra.CrossCutting.Notifications;
using App01.Model.Infra.Data.Context.EF;
using App01.Model.Infra.Data.Repositories;
using App01.Model.Infra.Data.Repositories.EF;
using App01.Model.Service.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App01.Model.Infra.CrossCutting.IoC {
    public static class BootStrapper {

        public static void RegisterServices (IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(typeof(BootStrapper));
            services.AddAutoMapper(typeof(BootStrapper));

            _efConfig(services, configuration);

            services.AddScoped<IUnitOfWork>((provider) =>
            {
                var factory = provider.GetService<IUnitOfWorkFactory>();
                return factory.Create();
            });

            services.RegisterAllTypes<IUserRepository>(new[] { typeof(IUserRepository).Assembly, typeof(UserRepository).Assembly });
            services.RegisterAllTypes<IUserService>(new[] { typeof(UserService).Assembly });

            services.AddScoped<NotificationContext>();
        }
        
        private static void _efConfig(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWorkFactory, EFUnitOfWorkFactory>();
        }

        public static void RegisterAllTypes<T> (this IServiceCollection services, Assembly[] assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient) {
            var typesFromAssemblies = assemblies.SelectMany (a => a.DefinedTypes.Where (x => x.GetInterfaces ().Contains (typeof (T))));
            foreach (var type in typesFromAssemblies)
                services.Add (new ServiceDescriptor (typeof (T), type, lifetime));
        }

    }
}