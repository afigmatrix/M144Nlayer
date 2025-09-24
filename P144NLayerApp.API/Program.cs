using P144NLayerApp.API.GlobalException;
using Serilog;
using static P144NLayerApp.DAL.DALServiceInjection;
using static P144NLayerApp.BusinessLayer.BusinessLayerServiceInjection;

var builder = WebApplication.CreateBuilder(args);
//Service start
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs.Log-.txt")
    .WriteTo.Debug()
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddExceptionHandler<ExceptionHandling>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.InjectDAL();
builder.Services.InjectBusinessLayer();
builder.Services.AddMemoryCache();

//BusinessLayer service injection
//Service end

//App start
var app = builder.Build();
//App end

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwaggerUI(o =>
{
    o.SwaggerEndpoint("/openapi/v1.json", "My app v1");
    o.RoutePrefix = "swagger";
});

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
