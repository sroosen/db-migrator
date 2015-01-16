using System;
using MigrateDatabase.Verbs;

namespace MigrateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options,
                (verbName, subOptions) =>
                {
                    // if parsing succeeds the verb name and correct instance
                    // will be passed to onVerbCommand delegate (string,object)
                    
                }))
            {
                Console.Write(options.GetUsage());
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            var verb = (IVerb)options.ListVerb ?? 
                       (IVerb)options.GenerateVerb;

           verb.Execute();
        }
    }
}
