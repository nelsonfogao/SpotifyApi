using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polly.Registry;
using SpotifyLike.API;
using SpotifyLike.Application.Conta;
using SpotifyLike.Repository;
using SpotifyLike.Repository.Conta;
using SpotifyLike.Repository.Streaming;
using SpotifyLike.Repository.Transacao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddHttpClient("musicaApiServer", client =>
{
    client.BaseAddress = new Uri("https://localhost:7102");
}).AddPolicyHandler(RetryPolicyConfiguration.GetRetryPolicy());


//Configurando banco de dados
builder.Services.AddDbContext<SpotifyContext>(c =>
{
    c.UseInMemoryDatabase("SpotifyLike");
});


//Adicionando inje��o de dependencia Repository
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<BandaRepository>();
builder.Services.AddScoped<PlanoRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();


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


