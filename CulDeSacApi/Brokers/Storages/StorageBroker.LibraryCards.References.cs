using CulDeSacApi.Models.LibraryAccounts;
using CulDeSacApi.Models.LibraryCards;
using Microsoft.EntityFrameworkCore;

namespace CulDeSacApi.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void AddLibraryCardsReferences(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryCard>()
                .HasOne(libraryCard => libraryCard.LibraryAccount)
                .WithMany(libraryAccount => libraryAccount.LibraryCards)
                .HasForeignKey(LibraryCard => LibraryCard.LibraryAccountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
