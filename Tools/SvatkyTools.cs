using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace Info.Adresa.Svatky.Mcp.Tools;

[McpServerToolType]
public static class SvatkyTools
{
    [McpServerTool, Description("Get names for date.")]
    public static async Task<string> GetNames(
        HttpClient client,
        [Description("The date `ddMM` to get names for.")] string date)
    {
        return await RequestSvatky(
            client,
            $"/json?date={date}",
            "No names for this date.");
    }

    [McpServerTool, Description("Get dates for name.")]
    public static async Task<string> GetDates(
        HttpClient client,
        [Description("The name to get date `ddMM` for.")] string name)
    {
        return await RequestSvatky(
            client,
            $"/json?name={name}",
            "No dates for this name.");
    }

    private static async Task<string> RequestSvatky(
        HttpClient client,
        string requestUri,
        string errorMessage)
    {
        var jsonElement = await client.GetFromJsonAsync<JsonElement>(requestUri);
        var dateNames = jsonElement.EnumerateArray();

        if (!dateNames.Any())
        {
            return errorMessage;
        }

        return string.Join("\n--\n", dateNames.Select(dateName =>
        {
            return $"""
                    Date: {dateName.GetProperty("date").GetString()}
                    Name: {dateName.GetProperty("name").GetString()}
                    """;
        }));
    }
}
