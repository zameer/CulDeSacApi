using CulDeSacApi.Models.Students;

namespace CulDeSacApi.Models.Fees
{
    public class Fee
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
