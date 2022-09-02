namespace optimalDb.Console.CommandLineParsing;

public class CommandLineRoute
{
    public string Description { get; }
    public readonly string CommandlineDescription;
    private readonly Action<Dictionary<string, string>> _action;

    public CommandLineRoute(
        string description,
        string commandlineDescription,
        Action<Dictionary<string, string>> action)
    {
        Description = description;
        CommandlineDescription = commandlineDescription;
        _action = action;
    }

    public bool RunIfMatch(string[] args)
    {
        var commandLineParts = CommandlineDescription.Split(' ');
        if (commandLineParts.Length != args.Length)
            return false;
        var values = new Dictionary<string, string>();

        for (var i = 0; i < commandLineParts.Length; i++)
        {
            var part = commandLineParts[i];
            // Values
            if (part.StartsWith("$"))
            {
                values.Add(part, args[i]);
                continue;
            }

            if (part != args[i])
            {
                return false;
            }
        }

        _action(values);

        return true;
    }
}