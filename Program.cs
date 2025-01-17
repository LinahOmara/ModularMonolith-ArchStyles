using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Infrastructure.Repositories;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Application;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Domain.Contracts;
using ModularMonolith_DotNetGirlsGrp.AppointmentBooking.Internal.Infrastructure.Gateways;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Business;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Core.Ports;
using ModularMonolith_DotNetGirlsGrp.DoctorAppointmentManagement.Shell.Repositories;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Data;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Shared;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities;
using ModularMonolith_DotNetGirlsGrp.SharedUtilities.Data;
using ModularMonolith_DotNetGirlsGrp.AppointmentConfirmation.Application.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Event Buss
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddSingleton<EventAggregator>();

//builder.Services.AddSingleton<IEventHandler, EventHandler>();     
//DB
builder.Services.AddSingleton<DBContext>();

// repos
builder.Services.AddScoped<IDoctorAppointmentManagementRepo, DoctorAppointmentManagementRepo>();
builder.Services.AddScoped<IAppointmentBookingRepo, AppointmentBookingRepo>();
builder.Services.AddScoped<DoctorAvailabilityRepo>();
builder.Services.AddScoped<AppointementBookingHandler>();
// apis
builder.Services.AddScoped<IDoctorAvailabiltyApi, DoctorAvailabiltyApi>();

// gateways
builder.Services.AddScoped<DoctorAvailabiltiyGateway>();

// services
builder.Services.AddScoped<IDoctorAppointmentManagementService, DoctorAppointmentManagementService>();
builder.Services.AddScoped<IBookAppointmentService, BookAppointmentService>();



var app = builder.Build();

app.Services.GetRequiredService<EventAggregator>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
