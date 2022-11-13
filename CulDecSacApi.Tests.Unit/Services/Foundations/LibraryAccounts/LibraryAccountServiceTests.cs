using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.LibraryAccounts;
using CulDeSacApi.Services.Foundations.LibraryAccounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace CulDecSacApi.Tests.Unit.Services.Foundations.LibraryAccounts
{
    public partial class LibraryAccountServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ILibraryAccountService libraryAccountService;

        public LibraryAccountServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.libraryAccountService = new LibraryAccountService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static LibraryAccount CreateRandomLibraryAccount() =>
            CreateLibraryAccountFiller().Create();

        private static Filler<LibraryAccount> CreateLibraryAccountFiller() =>
            new Filler<LibraryAccount>();
    }
}
