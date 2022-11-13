// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using CulDeSacApi.Models.Fees;
using Microsoft.EntityFrameworkCore;

namespace CulDeSacApi.Brokers.Storages
{
    public partial class StorageBroker
    {
        private static void SetStudentFeeReferences(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fee>()
                .HasOne(fee => fee.Student)
                .WithMany(studentFee => studentFee.Fees)
                .HasForeignKey(studentFee => studentFee.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
