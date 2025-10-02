namespace Domain.Entities;

public class Image
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public long HomeId { get; set; }
    public Home Home { get; set; }

}
