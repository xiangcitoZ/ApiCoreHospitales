using ApiCoreHospitales.Data;
using ApiCoreHospitales.Repositorie;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conectionString =
    builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryHospitales>();
builder.Services.AddDbContext<HospitalesContext>
    (options  => options.UseSqlServer(conectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api BBDD Hospitales Juernes",
        Description = "Estamos realizando un Api con BBDD en Azure",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Xiang",
            Email = "xiang.zhou@tajamar365.com"
        }
    });
}
    );

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1");
    options.RoutePrefix = "";
}
    );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
