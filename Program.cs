using EventApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

var ConStr = builder.Configuration.GetConnectionString("ConStr");


builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(ConStr)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
                      builder =>
                       {
                       builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
              }));

  var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
