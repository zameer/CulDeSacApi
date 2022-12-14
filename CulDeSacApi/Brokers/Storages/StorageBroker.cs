using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace CulDeSacApi.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate(); //this will automatically kick of db migration
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetStudentFeeReferences(modelBuilder);
            AddLibraryAccountsReferences(modelBuilder);
            AddLibraryCardsReferences(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString("PostgresConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
