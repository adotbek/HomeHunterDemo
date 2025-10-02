using Application.Dtos;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class LocationEndpoints
{
    public static void MapLocationEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/locations")
                       .WithTags("Locations");

        group.MapPost("/create", async (LocationCreateDto dto, ILocationService service) =>
        {
            var id = await service.CreateLocationAsync(dto);
            return Results.Ok(new { LocationId = id });
        })
        .WithName("CreateLocation");

        group.MapPut("/update", async (LocationUpdateDto dto, ILocationService service) =>
        {
            await service.UpdateLocationAsync(dto);
            return Results.Ok(new { Message = "Location updated successfully" });
        })
        .WithName("UpdateLocation");

        group.MapDelete("/delete/{id:long}", async (long id, ILocationService service) =>
        {
            await service.DeleteLocationAsync(id);
            return Results.Ok(new { Message = "Location deleted successfully" });
        })
        .WithName("DeleteLocation");

        group.MapGet("/get-by-id/{id:long}", async (long id, ILocationService service) =>
        {
            var location = await service.GetByIdAsync(id);
            return location is null ? Results.NotFound() : Results.Ok(location);
        })
        .WithName("GetLocationById");

        group.MapGet("/get-all", async (ILocationService service) =>
        {
            var locations = await service.GetAllAsync();
            return Results.Ok(locations);
        })
        .WithName("GetAllLocations");

        group.MapGet("/by-city", async (string city, ILocationService service) =>
        {
            var locations = await service.GetByCityAsync(city);
            return Results.Ok(locations);
        })
        .WithName("GetLocationsByCity");

        group.MapGet("/by-country", async (string country, ILocationService service) =>
        {
            var locations = await service.GetByCountryAsync(country);
            return Results.Ok(locations);
        })
        .WithName("GetLocationsByCountry");

        group.MapGet("/by-zipcode", async (string zipCode, ILocationService service) =>
        {
            var locations = await service.GetByZipCodeAsync(zipCode);
            return Results.Ok(locations);
        })
        .WithName("GetLocationsByZipCode");
    }
}
