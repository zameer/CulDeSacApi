using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.LibraryAccounts;
using CulDeSacApi.Services.Foundations.LibraryAccounts;
using FluentAssertions;
using Force.DeepCloner;
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
        [Fact]
        public async Task ShouldAddLibraryAccount()
        {
            //given
            LibraryAccount randomLibraryAccount = 
                CreateRandomLibraryAccount();

            LibraryAccount inputLibraryAccount =
                randomLibraryAccount;

            LibraryAccount insertedLibraryAccount =
                inputLibraryAccount;

            LibraryAccount expectedLibraryAccount =
                insertedLibraryAccount.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLibraryAccountAsync(inputLibraryAccount))
                .ReturnsAsync(insertedLibraryAccount);

            //when
            LibraryAccount actualLibraryAccount =
                await libraryAccountService.AddLibraryAccountAsync(inputLibraryAccount);

            //then
            actualLibraryAccount.Should().BeEquivalentTo(expectedLibraryAccount);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLibraryAccountAsync(inputLibraryAccount),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
