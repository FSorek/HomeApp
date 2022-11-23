using Application.DTOs.External;

namespace Application.Services;

public interface IGoogleBooksClient
{
    Task<GoogleBookDto> GetBook(string id);
}