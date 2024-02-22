using System.Reflection;
using Guild.Application.Common.MappingsProfiles;
using Guild.Application.Interfaces;
using Guild.Application.Players.Commands.CreatePlayer;
using Guild.Application.Players.Commands.DeletePlayer;
using Guild.Application.Players.Commands.UpdatePlayer;
using Guild.Application.Players.Queries.GetAllPlayers;
using Guild.DAL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Get connection string
var connectionString = builder.Configuration.GetConnectionString("GuildPlayersDB");

//Initialising DbContext to DI
builder.Services.AddDbContext<PlayersDbContext>(
    options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IPlayersDbContext>(provider => provider.GetService<PlayersDbContext>());
//Injecting the MediatR to DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(UpdatePlayerCommandHandler).Assembly, typeof(CreatePlayerCommandHandler).Assembly));
//builder.Services.AddDbContext<IPlayersDbContext>(options => options.Use)

//Injecting the AutoMapper to DI
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// CORS policy AllowAll 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AlloAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
