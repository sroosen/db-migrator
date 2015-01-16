using CommandLine;
using MigrateDatabase.Helpers;
using System;
using System.Data.Entity.Migrations.Infrastructure;

namespace MigrateDatabase.Verbs
{
    public class Generate : IVerb
    {
        [Option('a', "Assembly", HelpText = "The assembly that contains the migrations.", Required = true)]
        public string Assembly { get; set; }

        [Option('s', "sourceMigration", HelpText = "The source migration.", Required = false, DefaultValue = null)]
        public string SourceMigration { get; set; }

        [Option('t', "TargetMigration", HelpText = "The target migration.", Required = false, DefaultValue = null)]
        public string TargetMigration { get; set; }

        public void Execute()
        {
            var dbMigrator = DbMigratorFactory.CreateDbMigrator(Assembly);

            var migratorScriptingDecorator = new MigratorScriptingDecorator(dbMigrator);
            var script = migratorScriptingDecorator.ScriptUpdate(SourceMigration, TargetMigration);

            Console.Write(script);
        }
    }
}
