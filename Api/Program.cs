using Business;
using Business.Business;
using Business.Utils;
using Dal;
using Dal.Persistences;
using Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICrypto, Crypto>();
builder.Services.AddScoped<IPersistence<User>, UserPersistence>(x => new UserPersistence(builder.Configuration["ConnectionStrings:implantdent"] ?? ""));
builder.Services.AddScoped<IPersistence<LogDb>, LogDbPersistence>(x => new LogDbPersistence(builder.Configuration["ConnectionStrings:implantdent"] ?? ""));
builder.Services.AddScoped<IBussinesUser, UserBusiness>();

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
