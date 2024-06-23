using Application.Services;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IMusicaRepository, MusicaRepository>();
builder.Services.AddScoped<IBandaRepository, BandaRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

//Services
builder.Services.AddScoped<IBandaService, BandaService>();
builder.Services.AddScoped<IMusicaService, MusicaService>();


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
