using CulDeSacApi.Models.Fees;
using CulDeSacApi.Models.LibraryAccounts;
using System.Text.Json.Serialization;

namespace CulDeSacApi.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Fee> Fees { get; set; }

        public LibraryAccount LibraryAccount { get; set; }
    }
}
