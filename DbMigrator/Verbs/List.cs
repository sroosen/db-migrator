using CommandLine;
using MigrateDatabase.Helpers;
using System;

namespace MigrateDatabase.Verbs
{
    public class List : IVerb
    {
        [Option('a', "Assembly", HelpText = "The assembly that contains the migrations.", Required = true)]
        public string Assembly { get; set; }

        public void Execute()
        {
            var dbMigrator = DbMigratorFactory.CreateDbMigrator(Assembly);

            var localMigrations = dbMigrator.GetLocalMigrations();

            foreach (var localMigration in localMigrations)
            {
                Console.WriteLine(localMigration);
            }
        }
    }
}
