using Application.Dtos;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class ImageEndpoints
{
    public static void MapImageEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/images")
                       .WithTags("Images");

        group.MapPost("/create", async (ImageCreateDto dto, IImageService service) =>
        {
            var id = await service.CreateImageAsync(dto);
            return Results.Ok(new { ImageId = id });
        })
        .WithName("CreateImage");

        group.MapPost("/create-many", async (IEnumerable<ImageCreateDto> dtos, IImageService service) =>
        {
            await service.CreateImagesAsync(dtos);
            return Results.Ok(new { Message = "Images created successfully" });
        })
        .WithName("CreateImages");

        group.MapPut("/update", async (ImageUpdateDto dto, IImageService service) =>
        {
            await service.UpdateImageAsync(dto);
            return Results.Ok(new { Message = "Image updated successfully" });
        })
        .WithName("UpdateImage");

        group.MapDelete("/delete/{id:long}", async (long id, IImageService service) =>
        {
            await service.DeleteImageAsync(id);
            return Results.Ok(new { Message = "Image deleted successfully" });
        })
        .WithName("DeleteImage");

        group.MapDelete("/delete-by-home/{homeId:long}", async (long homeId, IImageService service) =>
        {
            await service.DeleteImagesByHomeIdAsync(homeId);
            return Results.Ok(new { Message = "Images deleted successfully by HomeId" });
        })
        .WithName("DeleteImagesByHomeId");

        group.MapGet("/get-by-id/{id:long}", async (long id, IImageService service) =>
        {
            var image = await service.GetImageByIdAsync(id);
            return image is null ? Results.NotFound() : Results.Ok(image);
        })
        .WithName("GetImageById");

        group.MapGet("/get-by-home/{homeId:long}", async (long homeId, IImageService service) =>
        {
            var images = await service.GetImagesByHomeIdAsync(homeId);
            return Results.Ok(images);
        })
        .WithName("GetImagesByHomeId");

        group.MapGet("/get-urls-by-home/{homeId:long}", async (long homeId, IImageService service) =>
        {
            var urls = await service.GetImageUrlsByHomeIdAsync(homeId);
            return Results.Ok(urls);
        })
        .WithName("GetImageUrlsByHomeId");
    }
}
