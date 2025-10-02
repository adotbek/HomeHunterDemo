using Application.Dtos;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class HomeEndpoints
{
    public static void MapHomeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/homes")
                       .WithTags("Homes");

        group.MapPost("/create", async (HomeCreateDto dto, IHomeService service) =>
        {
            var id = await service.CreateHomeAsync(dto);
            return Results.Ok(new { HomeId = id });
        })
        .WithName("CreateHome");

        group.MapPut("/update", async (HomeUpdateDto dto, IHomeService service) =>
        {
            await service.UpdateHomeAsync(dto);
            return Results.Ok(new { Message = "Home updated successfully" });
        })
        .WithName("UpdateHome");

        group.MapDelete("/delete/{id:long}", async (long id, IHomeService service) =>
        {
            await service.DeleteHomeAsync(id);
            return Results.Ok(new { Message = "Home deleted successfully" });
        })
        .WithName("DeleteHome");

        group.MapGet("/get-by-id/{id:long}", async (long id, IHomeService service) =>
        {
            var home = await service.GetHomeByIdAsync(id);
            return home is null ? Results.NotFound() : Results.Ok(home);
        })
        .WithName("GetHomeById");

        group.MapGet("/get-paged", async (int pageNumber, int pageSize, string? sortBy, bool ascending, IHomeService service) =>
        {
            var homes = await service.GetPagedHomesAsync(pageNumber, pageSize, sortBy, ascending);
            return Results.Ok(homes);
        })
        .WithName("GetPagedHomes");

        group.MapGet("/by-location", async (IHomeService service) =>
        {
            var homes = await service.GetHomesByLocationAsync();
            return Results.Ok(homes);
        })
        .WithName("GetHomesByLocation");

        group.MapGet("/between", async (decimal minPrice, decimal maxPrice, IHomeService service) =>
        {
            var homes = await service.GetHomesBetweenAsync(minPrice, maxPrice);
            return Results.Ok(homes);
        })
        .WithName("GetHomesBetween");

        group.MapGet("/by-rooms", async (int minCount, int maxCount, IHomeService service) =>
        {
            var homes = await service.GetHomesByCountOfRoomsAsync(minCount, maxCount);
            return Results.Ok(homes);
        })
        .WithName("GetHomesByRooms");

        group.MapPost("/report", async (long homeId, string reason, IHomeService service) =>
        {
            await service.ReportHomeAsync(homeId, reason);
            return Results.Ok(new { Message = "Home reported successfully" });
        })
        .WithName("ReportHome");
    }
}
