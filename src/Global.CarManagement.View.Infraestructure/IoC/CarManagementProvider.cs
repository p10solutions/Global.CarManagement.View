using Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar;
using Global.CarManagement.View.Application.Features.Cars.Queries.GetCar;
using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using Global.CarManagement.View.Domain.Models.Data;
using Global.CarManagement.View.Infraestructure.Data.Repositories;
using Global.CarManagement.View.Infraestructure.Validation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Global.CarManagement.View.Infraestructure.IoC
{
    public static class CarManagementProvider
    {
        public static IServiceCollection AddProviders(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidator<,>));
            services.AddScoped<INotificationsHandler, NotificationHandler>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddAutoMapper(typeof(CreateCarMapper));
            services.AddAutoMapper(typeof(GetCarMapper));
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            return services;
        }
    }
}
