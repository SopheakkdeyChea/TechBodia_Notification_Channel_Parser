using System.Text.RegularExpressions;

namespace NotiChannelParser;

public class Helper
{
    public static void InputChannels()
    {
        while (true)
        {
            Console.WriteLine("Enter notification channels (or type 'exit' to quit):");
            var title = Console.ReadLine();

            switch (title.ToLower())
            {
                case "exit":
                    return;

                default:
                    List<string> channels = ParseChannels(title);
                    if (channels.Any())
                    {
                        Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
                    }
                    else
                    {
                        Console.WriteLine("No relevant channels found.");
                    }
                    break;
            }

            Console.WriteLine(); // Add a blank line for readability
        }
    }
    static List<string> ParseChannels(string title)
    {
        List<string> ChannelTags = new List<string> { "BE", "FE", "QA", "Urgent" }; // Define notification channel tags
        var regex = new Regex(@"\[([^\]]+)\]"); // Extract relevant tags using regular expression
        var matches = regex.Matches(title);

        // Filter and list the notification channels
        return matches.Select(m => m.Groups[1].Value)
            .Where(tag => ChannelTags.Contains(tag))
            .ToList();
    }
}
