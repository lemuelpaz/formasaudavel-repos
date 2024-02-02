using API.Source.Base.Ioc;
using API.Source.Base.SQL;
using API.Source.Base.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Load Settings
AppSettings.LoadSettings(builder.Configuration);
//Carrega injeção de dependencia
Ioc.LoadInjectorDependencie(builder.Services);


//Conexao com banco
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(AppSettings.PostgreSQlConnection));

var app = builder.Build();

app.UseCors(x => x.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
        options.RoutePrefix = string.Empty;
    });
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
