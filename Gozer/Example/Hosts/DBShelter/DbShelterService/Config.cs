using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace DbShelterService
{

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShelterContext>
        {
            public ShelterContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<ShelterContext>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ShelterContext;Trusted_Connection=True;ConnectRetryCount=0";

            builder.UseSqlServer(connection);

                return new ShelterContext(builder.Options);
            }
    }
}
