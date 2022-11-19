using Books.Entities;
using Books.Repositories;
using MediatR;

namespace Application.Requests;

public class GetAllBooksRequestHandler : IRequestHandler<GetAllBooksRequest, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksRequestHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public Task<IEnumerable<Book>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        var books = _bookRepository.GetAllAsync();
        return books;
    }
}
public class GetAllBooksRequest : IRequest<IEnumerable<Book>>
{
    
}