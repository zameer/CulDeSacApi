﻿using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Models.LibraryAccounts;

namespace CulDeSacApi.Services.Foundations.LibraryAccounts
{
    public class LibraryAccountService : ILibraryAccountService
    {
        private readonly IStorageBroker storageBroker;

        public LibraryAccountService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<LibraryAccount> AddLibraryAccountAsync(LibraryAccount libraryAccount) =>
            await this.storageBroker.InsertLibraryAccountAsync(libraryAccount);
    }
}
