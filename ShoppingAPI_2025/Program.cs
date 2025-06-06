using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2025.DAL;
using ShoppingAPI_2025.Domain.Interfaces;
using ShoppingAPI_2025.Domain.Services;

var applicationBuilder = WebApplication.CreateBuilder(args);

applicationBuilder.Services.AddControllers();

applicationBuilder.Services.AddDbContext<DataBaseContext>(databaseOptions => 
    databaseOptions.UseSqlServer(applicationBuilder.Configuration.GetConnectionString("DefaultConnection")));

applicationBuilder.Services.AddScoped<ICountryService, CountryService>();
applicationBuilder.Services.AddScoped<IStateService, StateService>();
applicationBuilder.Services.AddTransient<SeederDB>();

applicationBuilder.Services.AddEndpointsApiExplorer();
applicationBuilder.Services.AddSwaggerGen();

var webApplication = applicationBuilder.Build();

InitializeDatabase();
void InitializeDatabase()
{
    var serviceScopeFactory = webApplication.Services.GetService<IServiceScopeFactory>();
    if (serviceScopeFactory != null)
    {
        using var serviceScope = serviceScopeFactory.CreateScope();
        var databaseSeeder = serviceScope.ServiceProvider.GetService<SeederDB>();
        databaseSeeder?.SeederAsync().Wait();
    }
}

if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI();
}

webApplication.UseHttpsRedirection();
webApplication.UseAuthorization();
webApplication.MapControllers();

webApplication.Run();
