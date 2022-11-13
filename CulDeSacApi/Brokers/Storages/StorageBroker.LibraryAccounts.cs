using CulDeSacApi.Models.LibraryAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CulDeSacApi.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<LibraryAccount> LibraryAccounts { get; set; }
        public async ValueTask<LibraryAccount> InsertLibraryAccountAsync(LibraryAccount libraryAccount)
        {
            using var broker = new StorageBroker(this.configuration);
            EntityEntry<LibraryAccount> libraryAccountEntityEntry =
                broker.LibraryAccounts.Add(libraryAccount);

            await broker.SaveChangesAsync();

            return libraryAccountEntityEntry.Entity;
        }
    }
}
