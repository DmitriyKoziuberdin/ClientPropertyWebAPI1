using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Services;
using ClientProperty.Domain;
using ClientProperty.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IPropertyRepository, CachedPropertyRepository>();
        builder.Services.AddScoped<PropertyRepository>();
        builder.Services.AddScoped<IUserRepository, CachedUserRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<IPropertyService, PropertyService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
        });
        builder.Services.AddMemoryCache();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>()!;
            dbContext.Database.Migrate();
        }

        app.Run();
    }
}