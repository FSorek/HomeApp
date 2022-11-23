using Application.DTOs.External;
using Application.Services;
using Google.Apis.Books.v1;
using Google.Apis.Json;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class GoogleBooksClient : IGoogleBooksClient
{
    private readonly string _apiKey;

    public GoogleBooksClient(IConfiguration configuration)
    {
        _apiKey = configuration["Google:BooksApiKey"];
    }
    public async Task<GoogleBookDto> GetBook(string id)
    {
        var service = new BooksService(new BaseClientService.Initializer()
        {
            ApplicationName = "HomeApp",
            ApiKey = _apiKey,
            Serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings(){ }),
        });
        var book = await service.Volumes.Get(id).ExecuteAsync();
        return new GoogleBookDto()
        {
            Id = id,
            Title = book.VolumeInfo.Title,
            Description = book.VolumeInfo.Description,
            Authors = book.VolumeInfo.Authors.ToArray(),
            Publisher = book.VolumeInfo.Publisher,
            AverageRating = book.VolumeInfo.AverageRating,
            ThumbnailUrl = book.VolumeInfo.ImageLinks.Thumbnail
        };
    }
}