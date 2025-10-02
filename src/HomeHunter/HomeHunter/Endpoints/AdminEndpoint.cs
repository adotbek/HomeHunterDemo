using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class AdminEndpoint
{
    public static void MapAdminEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/api/admin")
               .WithTags("Admins");
       

        group.MapGet("/get-by-role/{roleId:long}", async (long roleId, IUserService service) =>
        {
            var users = await service.GetByRoleIdAsync(roleId);
            return Results.Ok(users);
        })
        .WithName("GetUsersByRoleId");


        group.MapDelete("/delete/{id:long}", async (long id, IUserService service) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok(new { Message = "User deleted successfully" });
        })
        .WithName("DeleteUser");

        group.MapGet("/get-all", async (IUserService service) =>
        {
            var users = await service.GetAllAsync();
            return Results.Ok(users);
        })
        .WithName("GetAllUsers");


        group.MapGet("/get-by-email", async (string email, IUserService service) =>
        {
            var user = await service.GetByEmailAsync(email);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserByEmail");


        group.MapPost("/create", async (string name, ICategoryService service) =>
            {
                var id = await service.AddCategoryAsync(name);
                return Results.Ok(new
                {
                    CategoryId = id
                });
            })
            .WithName("CreateCategory");



        group.MapPut("/update", async (CategoryDto dto, ICategoryService service) =>
        {
            await service.UpdateCategoryAsync(dto);
            return Results.Ok(new { Message = "Category updated successfully" });
        })
        .WithName("UpdateCategory");

        
        group.MapDelete("/delete/category", async (long id, ICategoryService service) =>
        {
            await service.DeleteCategoryAsync(id);
            return Results.Ok(new { Message = "Category deleted successfully" });
        })
        .WithName("DeleteCategory");
    }
}
