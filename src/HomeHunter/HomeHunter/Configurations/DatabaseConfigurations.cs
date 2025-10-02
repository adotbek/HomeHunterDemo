using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HomeHunter.Configurations;

public static class DatabaseConfigurations
{
    public static void ConfigureDataBase(this WebApplicationBuilder builder)
    {
        var connectionStringMs = builder.Configuration.GetConnectionString("DatabaseConnectionMS");

        builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionStringMs));
    }
}
