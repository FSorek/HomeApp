namespace Application.DTOs.External;

public class GoogleBookDto
{
    public string Id { get; set; }
    public string ThumbnailUrl { get; set; }
    public string[] Authors { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
    public int AverageRating { get; set; }
}