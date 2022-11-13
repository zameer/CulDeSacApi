using CulDeSacApi.Models.LibraryCards;

namespace CulDeSacApi.Services.Foundations.LibraryCards
{
    public interface ILibraryCardService
    {
        ValueTask<LibraryCard> AddLibraryCardAsync(LibraryCard libraryCard);
    }
}
