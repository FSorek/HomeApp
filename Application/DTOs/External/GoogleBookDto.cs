namespace Application.DTOs.External;

public class GoogleBookDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string ThumbnailUrl { get; set; }
    public string[] Authors { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
    public double? AverageRating { get; set; }
}