using Microsoft.EntityFrameworkCore;
using ElectricGamesApiV1.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options => {
        options.AddPolicy("AllowAnyOrigin",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
        );
    }
);
// creates the context option for accessing the database
builder.Services.AddDbContext<GameContext>(
    options => options.UseSqlite("Data Source=ElectricGames.db")
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseCors("AllowAnyOrigin");
app.UseStaticFiles();

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