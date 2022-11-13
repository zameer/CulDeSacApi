using CulDeSacApi.Models.Fees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CulDeSacApi.Brokers.Storages
{
    public partial class StorageBroker 
    {
        public DbSet<Fee> Fees { get; set; }

        public async ValueTask<Fee> InsertFeeAsync(Fee fee)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Fee> feeEntityEntry =
                broker.Fees.Add(fee);

            await broker.SaveChangesAsync();

            return feeEntityEntry.Entity;
        }
    }
}
