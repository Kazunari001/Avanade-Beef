﻿using Beef.Database;
using Beef.Database.SqlServer;
using Beef.Demo.Api;
using Beef.Demo.Business;
using DbEx;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using UnitTestEx;

namespace Beef.Demo.Test
{
    [SetUpFixture]
    public class FixtureSetUp
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSetUp.Default.RegisterAutoSetUp(async (count, _, ct) =>
            {
                using var test = ApiTester.Create<Startup>();
                var settings = test.Services.GetRequiredService<DemoSettings>();

                var args = Database.Program.ConfigureMigrationArgs(new MigrationArgs(count == 0 ? MigrationCommand.ResetAndDatabase : MigrationCommand.ResetAndData, settings.DatabaseConnectionString))
                    .AddAssembly<FixtureSetUp>()
                    .AddAssembly<Abc.Database.Scripts>()
                    .AddSchemaOrder("Test");

                return await new SqlServerMigration(args).MigrateAndLogAsync(ct).ConfigureAwait(false);
            });
        }
    }
}