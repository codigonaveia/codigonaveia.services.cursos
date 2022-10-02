using codigonaveia.services.cursos.Data.Contexto;
using codigonaveia.services.cursos.Repositories.Interface;
using codigonaveia.services.cursos.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConnection = builder.Configuration.GetConnectionString("DefaulConnection");

builder.Services.AddDbContext<DataContexto>(option =>
{
    option.UseSqlServer(strConnection);
});


builder.Services.AddScoped<ICursosRepository, CursosRepository>();

builder.Services.AddControllers();
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
