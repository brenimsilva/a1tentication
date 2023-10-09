using a1tentication.Context;
using a1tentication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string conString = builder.Configuration.GetConnectionString("AuthConnection");
ServerVersion version = ServerVersion.AutoDetect(conString);
builder.Services.AddDbContext<AuthContext>(opts => opts.UseMySql(conString, version));
builder.Services.AddTransient<UserService, UserService>();
builder.Services.AddTransient<AuthService, AuthService>();

var app = builder.Build();
app.UseCors(e => e.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

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