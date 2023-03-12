using DoctorCounseloing.Application.Common;
using DoctorCounseloing.Domain.Model;
using DoctorCounseloing.Infrastructure;
using DoctorCounseloing.Infrastructure.DatabaseIntilizer;
using DoctorCounseloing.Infrastructure.Interfaces;
using DoctorCounseloing.Infrastructure.Repositry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddApplication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" }));

builder.Services.AddScoped<IDoctorRepositry, DoctorRepositry>();
builder.Services.AddScoped<IPatientRepositry, PatientRepositry>();
builder.Services.AddScoped<IAppointmentRepositry, AppointmentRepositry>();
builder.Services.AddScoped<ISchduleSlotRepositry, SchduleSLotRepositry>();

builder.Services.AddDbContext<DoctorCounseloingContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DataEF"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Awesome API V1");
    });
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseItToSeedSqlServer(configuration);

app.MapControllers();

app.Run();
