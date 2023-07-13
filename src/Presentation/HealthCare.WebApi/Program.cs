using HealthCare.Core;
using HealthCare.Persistance;
using HealthCare.Infrastructure;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCoreConfigureServices();
builder.Services.AddPersistanceConfigureServices(builder.Configuration);
builder.Services.AddInfrastructureConfigureService();
builder.Logging.AddLoggingInfrastructureBuilder(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Ýç içe modeller ignore edilir. 
    options.JsonSerializerOptions.IgnoreNullValues = true; // Null deðerler ignore edilir.
                                                           //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

});
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
