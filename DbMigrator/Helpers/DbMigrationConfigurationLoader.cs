using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MigrateDatabase.Helpers
{
    internal static class DbMigrationConfigurationLoader
    {
        public static DbMigrationsConfiguration LoadConfiguration(string assemblyPath)
        {
            var absolutePath = Path.GetFullPath(assemblyPath);

            var assembly = Assembly.LoadFile(absolutePath);

            var configurationTypes = assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(DbMigrationsConfiguration)))
                .ToList();

            var configuration = (DbMigrationsConfiguration)Activator.CreateInstance(configurationTypes.Single());

            return configuration;
        }
    }
}
