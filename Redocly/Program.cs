using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Swagger Demo Documentation",
            Version = "v1",
            Description = "This is a demo to see how documentation can easily be generated for ASP.NET Core Web APIs using Swagger and ReDoc.",
            Contact = new OpenApiContact
            {
                Name = "Christian Schou",
                Email = "someemail@somedomain.com"
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Swagger Demo Documentation v1"));

    app.UseReDoc(c =>
    {
        c.DocumentTitle = "Swagger Demo Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";

        c.IndexStream = () => Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Redocly.index.html"); 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();