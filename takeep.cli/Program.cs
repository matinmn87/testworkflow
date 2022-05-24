using System.CommandLine.NamingConventionBinder;
using System.CommandLine;

internal class Program
{
    private static async Task Main (string[] args)
    {
        var rootCommand = new RootCommand { };

        var getCommand = new Command ("get")
        {
            new Option<string> (
                "me",
                description: "Gets the name of a takeep & shows its text.")
        };

        var setCommand = new Command ("set")
        {
            new Option<string> (
                "the",
                description: "Sets a takeep by name & text.")
        };

        getCommand.Handler = CommandHandler.Create<string> ((me) =>
        {
            Console.WriteLine ($"Build Version: {me}");
        });

        setCommand.Handler = CommandHandler.Create<string> ((set) =>
        {
            Console.WriteLine ($"Build Version: {set}");
        });

        rootCommand.Add (getCommand);
        rootCommand.Add (setCommand);

        await rootCommand.InvokeAsync (args);
    }
}