using CommandLine;
using CommandLine.Text;
using MigrateDatabase.Verbs;

namespace MigrateDatabase
{
    public class Options
    {
        [VerbOption("list", HelpText = "Lists all known migrations")]
        public List ListVerb { get; set; }

        [VerbOption("generate", HelpText = "Generates a migration script")]
        public Generate GenerateVerb { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
