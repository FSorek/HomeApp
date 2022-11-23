using Books.Entities;
using Books.Repositories;

namespace Infrastructure.Repositories;

public class MyBookRepository : IBookRepository
{
    private IEnumerable<Book> _myBooks = new[]
    {
        new Book()
        {
            GoogleBookId = "OHclhBVv-X4C",
            MyOpinion = "Amazing!!",
            MyRating = 5d
        },
        new Book()
        {
            GoogleBookId = "kYjqAQAAQBAJ",
            MyOpinion = "I love it!!!",
            MyRating = 5d
        },
        new Book()
        {
            GoogleBookId = "VsT3DQAAQBAJ",
            MyOpinion = "Must read!",
            MyRating = 5d
        },
        new Book()
        {
            GoogleBookId = "jZAUqunfcZkC",
            MyOpinion = "WOW!",
            MyRating = 4.9d
        },
        new Book()
        {
            GoogleBookId = "ABD0xgEACAAJ",
            MyOpinion = "Fantastic!!!",
            MyRating = 4.8d
        },
    };
    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return Task.FromResult(_myBooks);
    }
}