﻿using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InfoTehTestTask.Data
{
    public class DatabaseMigrator
    {
        private readonly AppDbContext appDbContext;

        public DatabaseMigrator(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task MigrateAsync()
        {
           await appDbContext.Database.MigrateAsync();


        }
    }
}
