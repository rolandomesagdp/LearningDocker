using Countries.Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CountryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CountriesDb")));

var app = builder.Build();

// Seeding the data
using (var scope = app.Services.CreateScope())
{
    var countryContext = scope.ServiceProvider.GetRequiredService<CountryContext>();
    countryContext.Database.EnsureCreated();
    countryContext.Seed();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
