using System.Text;
using ExpenseAggregator.Models;

namespace ExpenseAggregator.Formatting;

/// <summary>
/// Purposefully built formatter for challenge's required output format
/// </summary>
public class PlainTextReportFormatter : IReportFormatter<AggregatedGroup>
{
    public string Format(IReadOnlyList<AggregatedGroup> groups)
    {
        var sb = new StringBuilder();

        foreach (var group in groups)
        {
            var keyPart = string.Join(", ", group.Keys.Select(k => $"{k.Name}: {k.Value}"));

            var parts = new List<string>();
            for (var i = 0; i < group.Results.Count; i++)
            {
                var r = group.Results[i];
                if (i == 0)
                    parts.Add($"{r.Label}: {r.Value}");
                else
                    parts.Add($"({r.Value})");
            }

            sb.AppendLine($"{keyPart} - {string.Join(" ", parts)}");
        }

        return sb.ToString().TrimEnd();
    }
}
