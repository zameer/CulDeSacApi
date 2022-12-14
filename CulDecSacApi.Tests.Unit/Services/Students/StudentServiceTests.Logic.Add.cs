using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.Students;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Tynamix.ObjectFiller;

namespace CulDecSacApi.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldAddStudentAsync()
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student inputStudent = randomStudent;
            Student insertedStudent = inputStudent;
            Student expectedStudent = insertedStudent.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(inputStudent))
                .ReturnsAsync(insertedStudent);

            //when
            Student actualStudent = await this.studentService
                .AddStudentAsync(inputStudent);

            //then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertStudentAsync(inputStudent), 
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}