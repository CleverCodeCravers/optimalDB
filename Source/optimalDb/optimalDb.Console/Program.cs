using optimalDb.BL.ConfigurationFileFormats;
using optimalDb.BL.TestViewPerformances;
using optimalDb.Console.CommandLineParsing;
using optimalDb.Infrastructure;

var parser = new CommandLineParser(
    args,
    "optimalDb Console Application v");


parser.On(
    "Test the performance of all available views in the database",
    "viewperformance --config $configurationFilename --connection $connectionName",
    parsedArgs =>
    {
        var configFilename = parsedArgs["$configurationFilename"];
        var connectionName = parsedArgs["$connectionName"];

        var allFileFormats = ConfigurationFileFormatFactory.GetAllFileFormats();
        var format = allFileFormats.GetMatchingFormatFor(parsedArgs["$configurationFilename"]);
        if (format == null)
        {
            Console.WriteLine("I do not know the format of this configuration file.");
            return;
        }

        var configuration = format.Load(configFilename);
        var connection = configuration?.Where(x => x.Name == connectionName).FirstOrDefault();
        if (connection == null)
        {
            Console.WriteLine($"The configuration file does not contain a definition for {connectionName}");
            return;
        }

        var databaseAccessor = new DatabaseAccessor(connection.ConnectionString);
        var databaseSchemaRepository = new DatabaseSchemaRepository(databaseAccessor);
        //var viewPerformanceTest = new ViewPerformanceTestProcess(databaseSchemaRepository, databaseAccessor);

        //viewPerformanceTest.GenerateProcessSteps();
        //viewPerformanceTest.Run(
        //    (text, percent) => Console.WriteLine($"  - {percent} % - {text}..."),
        //    () => false);

        //var results = viewPerformanceTest.Results;

        //if (results == null)
        //{
        //    Console.WriteLine("No results available");
        //    return;
        //}

        //foreach (var result in results)
        //{
        //    if (result.DurationInSeconds == null)
        //    {
        //        Console.WriteLine($" - {result.ViewName}: {result.ExceptionMessage}");
        //        continue;
        //    }

        //    Console.WriteLine($" - {result.ViewName}, {result.DurationInSeconds?.ToString("N2")}s ");
        //}
    });

parser.Run();