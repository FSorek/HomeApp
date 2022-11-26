using BookRecommendations.Entities;
using BookRecommendations.Repositories;
using MediatR;

namespace Application.Requests;

public class GetAllBooksRequestHandler : IRequestHandler<GetAllBooksRequest, IEnumerable<BookEntry>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksRequestHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public Task<IEnumerable<BookEntry>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        var books = _bookRepository.GetAllAsync();
        return books;
    }
}
public class GetAllBooksRequest : IRequest<IEnumerable<BookEntry>>
{
    
}