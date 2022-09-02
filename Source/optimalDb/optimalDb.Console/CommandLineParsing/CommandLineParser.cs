namespace optimalDb.Console.CommandLineParsing;

public class CommandLineParser
{
    private readonly string[] _args;
    private readonly string _appName;
    private readonly List<CommandLineRoute> _routes = new(); 

    public CommandLineParser(string[] args, string appName)
    {
        _args = args;
        _appName = appName;
    }


    public void On(string description, string commandlineDescription, Action<Dictionary<string,string>> action)
    {
        _routes.Add(new CommandLineRoute(description, commandlineDescription, action));
    }

    public void Run()
    {
        foreach (var route in _routes)
        {
            if (route.RunIfMatch(_args))
                return;
        }

        System.Console.WriteLine(_appName);
        System.Console.WriteLine("");

        System.Console.WriteLine("Sorry, I did not find a matching command line route.");
        System.Console.WriteLine();
        System.Console.WriteLine("I know these commands:");

        foreach (var route in _routes)
        {
            System.Console.WriteLine("  - " + route.CommandlineDescription);
            System.Console.WriteLine("    " + route.Description);
        }
    }
}