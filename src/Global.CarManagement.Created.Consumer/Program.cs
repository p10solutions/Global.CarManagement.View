using Global.CarManagement.Created.Consumer;
using Global.CarManagement.Created.Consumer.Consumer;
using Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar;
using Global.CarManagement.View.Infraestructure.IoC;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var configuration = builder.Configuration;

builder.Services.AddTransient<ICreatedCarConsumer, CreatedCarConsumer>();
builder.Services.AddAutoMapper(typeof(CreatedCarEventMapper));
builder.Services.AddProviders(configuration);

var host = builder.Build();
host.Run();
