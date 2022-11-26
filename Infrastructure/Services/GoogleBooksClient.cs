using System.Diagnostics;
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
    private readonly BooksService _service;

    public GoogleBooksClient(IConfiguration configuration)
    {
        _apiKey = configuration["Google:BooksApiKey"];
        _service = new BooksService(new BaseClientService.Initializer()
        {
            ApplicationName = "HomeApp",
            ApiKey = _apiKey,
            GZipEnabled = false,
            Serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings(){ }),
        });
    }
    public async Task<GoogleBookDto> GetBook(string id)
    {
        var book = await _service.Volumes.Get(id).ExecuteAsync();
        return new GoogleBookDto()
        {
            Id = id,
            Title = book.VolumeInfo.Title,
            Subtitle = book.VolumeInfo.Subtitle,
            Description = book.VolumeInfo.Description,
            Authors = book.VolumeInfo.Authors.ToArray(),
            Publisher = book.VolumeInfo.Publisher,
            AverageRating = book.VolumeInfo.AverageRating,
            ThumbnailUrl = book.VolumeInfo.ImageLinks.Thumbnail
        };
    }

    public async Task<IEnumerable<GoogleBookDto>> GetBooksByTitle(string inputTitle, CancellationToken token)
    {
        Debug.WriteLine(inputTitle);
        var books = await _service.Volumes.List(inputTitle).ExecuteAsync(token);
        return books.Items.Take(5).Select(book => new GoogleBookDto()
        {
            Id = book.Id,
            Title = book.VolumeInfo.Title,
            Subtitle = book.VolumeInfo.Subtitle,
            Description = book.VolumeInfo.Description,
            Authors = book.VolumeInfo.Authors.ToArray(),
            Publisher = book.VolumeInfo.Publisher,
            AverageRating = book.VolumeInfo.AverageRating,
            ThumbnailUrl = book.VolumeInfo.ImageLinks.Thumbnail
        }).ToArray();
    }
}