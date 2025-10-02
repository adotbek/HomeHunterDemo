using Application.Dtos;
using Application.FluentValidations;
using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using FluentValidation;
using Infrastructure.Repositories;

namespace HomeHunter.Configurations;

public static class DependecyInjectionsConfiguration
{
    public static void ConfigureDependecies  (this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IReportService,ReportService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IHomeRepository, HomeRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IValidator<CategoryDto>, CategoryCreateDtoValidator>();
        services.AddScoped<IValidator<HomeCreateDto>, HomeCreateDtoValidator>();
        services.AddScoped<IValidator<ImageCreateDto>, ImageCreateDtoValidator >();
        services.AddScoped<IValidator<LocationCreateDto>, LocationCreateDtoValidator>();
        services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
        services.AddScoped<IValidator<UserGetDto>, UserUpdateDtoValidator>();
        services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();



    }
}
