using CulDeSacApi.Models.Fees;

namespace CulDeSacApi.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Fee> InsertFeeAsync(Fee fee);
    }
}
