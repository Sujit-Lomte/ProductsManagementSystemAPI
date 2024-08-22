using ProductsManagement.API.DataAccess;
using ProductsManagement.API.DataAccess.Repositories;
using ProductsManagement.API.Helpers;
using ProductsManagement.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddDbContext<DataContext>();

services.AddCors(options =>
{
    options.AddPolicy(name: "default",
           builder =>
           {
               builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
           });
});

services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IProductService, ProductService>();
services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
services.AddScoped(typeof(IJsonDataRespository<>), typeof(JsonDataRespository<>));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
