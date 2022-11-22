using Application.DTOs.External;
using MediatR;

namespace Application.Requests;
public class GetGoogleBookRequestHandler : IRequestHandler<GetGoogleBookRequest, GoogleBookDto>
{
    public Task<GoogleBookDto> Handle(GetGoogleBookRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GoogleBookDto()
        {
            Id = "TEST",
            Description = "NEW DESCRIPTION",
            Authors = new[]{"Big Meme"},
            Publisher = "Biggest Meme",
            AverageRating = 5,
            ThumbnailUrl = @"http://books.google.com/books/content?id=ABD0xgEACAAJ&printsec=frontcover&img=1&zoom=1&imgtk=AFLRE73nFPviQdF6Zgmx8XqCZ7p-84-McPrtnU980uY26K5oPk036hV_4PnrqTDkksDK8rJ0hwwj3NE0EHdoROc7TsK27bt9Dpm1oWHC8-6nppX2_LkAJAPswgcDkrr73b-1EeKi5IJx&source=gbs_api"
        });
    }
}

public class GetGoogleBookRequest : IRequest<GoogleBookDto>
{
    public GetGoogleBookRequest(string id)
    {
        Id = id;
    }

    public string Id { get; }
}