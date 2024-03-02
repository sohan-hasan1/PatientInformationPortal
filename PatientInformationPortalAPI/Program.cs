using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientInformationPortalAPI.DAL.IRepository;
using PatientInformationPortalAPI.DAL.Repository;
using PatientInformationPortalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PatientInfoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PatientInformationDB")));
builder.Services.AddTransient<IPatientInfoRepository, PatientInfoRepository>();
builder.Services.AddTransient<IDiseaseInformationRepository, DiseaseInformationRepository>();
builder.Services.AddTransient<INCDRepository, NCDRepository>();
builder.Services.AddTransient<IAllergiesRepository, AllergiesRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
