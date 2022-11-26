using BookRecommendations.ValueObjects;

namespace BookRecommendations.Entities;

public class BookEntry
{
    public string GoogleBookId { get; set; }
    public string MyOpinion { get; set; }
    public double MyRating { get; set; }
    public BookDetails? BookDetails { get; set; }
}