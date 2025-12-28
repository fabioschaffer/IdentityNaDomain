using Aplicacao.Interfaces;
using Domain;
using InfraEstrutura.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {


    public static IServiceCollection AdicionaRepositorio(
        this IServiceCollection services,
        IConfiguration configuration) {

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=IdentityNaDomain_Banco.db"));

        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) {

        services
            .AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
