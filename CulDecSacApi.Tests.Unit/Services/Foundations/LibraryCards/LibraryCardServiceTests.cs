using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.LibraryAccounts;
using CulDeSacApi.Models.LibraryCards;
using CulDeSacApi.Services.Foundations.LibraryCards;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace CulDecSacApi.Tests.Unit.Services.Foundations.LibraryCards
{
    public partial class LibraryCardServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ILibraryCardService libraryCardService;

        public LibraryCardServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.libraryCardService = new LibraryCardService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static LibraryCard CreateRandomLibraryCard() =>
            CreateLibraryCardFiller().Create();

        private static Filler<LibraryCard> CreateLibraryCardFiller() =>
            new Filler<LibraryCard>();
    }
}
