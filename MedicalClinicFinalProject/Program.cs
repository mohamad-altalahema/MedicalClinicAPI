using MedicalClinicFinalProject.Models.Repository;
using MedicalClinicFinalProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MedicalClinicFinalProject.Models;
using MedicalClinicFinalProject.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalClinicFinalProject", Version = "v1" });
});

// Dependency Injection for repository.
builder.Services.AddScoped<IRepository<Doctors>, dbDoctorsRepository>();
builder.Services.AddScoped<IRepository<Patients>, dbPatientsRepository>();
builder.Services.AddScoped<IRepository<Appointments>, dbAppointmentsRepository>();
builder.Services.AddScoped<IRepository<MedicalRecords>, dbMedicalRecordsRepository>();
builder.Services.AddScoped<IRepository<Billing>, dbBillingRepository>();
builder.Services.AddScoped<IRepository<Comments>, dbCommentsRepository>();
// Configure DbContext with SQL Server.
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalClinicFinalProject v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Map controllers to endpoints.
app.MapControllers();

app.Run();

