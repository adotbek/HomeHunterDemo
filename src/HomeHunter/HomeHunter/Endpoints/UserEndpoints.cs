using Application.Dtos;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/users")
                       .WithTags("Users");

        
        //group.MapPost("/create", async (UserCreateDto dto, IUserService service) =>
        //{
        //    var id = await service.CreateAsync(dto);
        //    return Results.Ok(new { UserId = id });
        //})
        //.WithName("CreateUser");

        
        //group.MapPut("/update/{id:long}", async (long id, UserCreateDto dto, IUserService service) =>
        //{
        //    await service.UpdateAsync(id, dto);
        //    return Results.Ok(new { Message = "User updated successfully" });
        //})
        //.WithName("UpdateUser");

   


        group.MapGet("/get-by-id/{id:long}", async (long id, IUserService service) =>
        {
            var user = await service.GetByIdAsync(id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserById");
      
        group.MapGet("/get-by-name", async (string userName, IUserService service) =>
        {
            var user = await service.GetByNameAsync(userName);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserByName");


       
        // Login
        //group.MapPost("/login", async (UserLoginDto dto, IUserService service) =>
        //{
        //    var user = await service.LoginAsync(dto);
        //    return user is null
        //        ? Results.Unauthorized()
        //        : Results.Ok(user);
        //})
        //.WithName("LoginUser");
    }
}
