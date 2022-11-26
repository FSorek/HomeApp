using BookRecommendations.ValueObjects;

namespace BookRecommendations.Entities;

public class BookRecommendation
{
    public string GoogleBookId { get; set; }
    public BookDetails BookDetails { get; set; }
    public string Comment { get; set; }
}