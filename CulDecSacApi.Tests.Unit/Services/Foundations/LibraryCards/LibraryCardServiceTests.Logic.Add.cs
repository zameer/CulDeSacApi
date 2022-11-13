using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.LibraryCards;
using FluentAssertions;
using Force.DeepCloner;
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
        [Fact]
        public async Task ShouldAddLibraryCardAsync()
        {
            //given
            LibraryCard randomLibraryCard = 
                CreateRandomLibraryCard();

            LibraryCard inputLibraryCard =
                randomLibraryCard;

            LibraryCard insertedLibraryCard =
                inputLibraryCard;

            LibraryCard expectedLibraryCard =
                insertedLibraryCard.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLibraryCardAsync(inputLibraryCard))
                .ReturnsAsync(insertedLibraryCard);

            //when
            LibraryCard actualLibraryCard =
                await libraryCardService.AddLibraryCardAsync(inputLibraryCard);

            //then
            actualLibraryCard.Should().BeEquivalentTo(expectedLibraryCard);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLibraryCardAsync(inputLibraryCard),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
