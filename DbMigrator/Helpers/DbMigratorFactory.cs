
using System.Data.Entity.Migrations;

namespace MigrateDatabase.Helpers
{
    public static class DbMigratorFactory
    {
        public static DbMigrator CreateDbMigrator(string assemblyPath)
        {
            var configuration = DbMigrationConfigurationLoader.LoadConfiguration(assemblyPath);

            return new DbMigrator(configuration);
        }

    }
}
