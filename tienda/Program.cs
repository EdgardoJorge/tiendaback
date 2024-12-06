using Microsoft.EntityFrameworkCore;
using TiendaData.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
string con = "data Source=IHR80PAC35; Inicial Catalog=Tienda;Integrate Security=true;";
builder.Services.AddDbContext<TiendaDbContext>(
    conf => conf.UseSqlServer(
        con,

        b => b.MigrationsAssembly("tienda"))
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
