using Countries.Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CountriesDb");

builder.Services.AddDbContext<CountryContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

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
