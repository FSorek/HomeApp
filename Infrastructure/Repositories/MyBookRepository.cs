using BookRecommendations.Entities;
using BookRecommendations.Repositories;

namespace Infrastructure.Repositories;

public class MyBookRepository : IBookRepository
{
    private IEnumerable<BookEntry> _myBooks = new[]
    {
        new BookEntry()
        {
            GoogleBookId = "OHclhBVv-X4C",
            MyOpinion = "Amazing!!",
            MyRating = 5d
        },
        new BookEntry()
        {
            GoogleBookId = "kYjqAQAAQBAJ",
            MyOpinion = "I love it!!!",
            MyRating = 5d
        },
        new BookEntry()
        {
            GoogleBookId = "VsT3DQAAQBAJ",
            MyOpinion = "Must read!",
            MyRating = 5d
        },
        new BookEntry()
        {
            GoogleBookId = "jZAUqunfcZkC",
            MyOpinion = "WOW!",
            MyRating = 4.9d
        },
        new BookEntry()
        {
            GoogleBookId = "ABD0xgEACAAJ",
            MyOpinion = "Fantastic!!!",
            MyRating = 4.8d
        },
    };
    public Task<IEnumerable<BookEntry>> GetAllAsync()
    {
        return Task.FromResult(_myBooks);
    }
}