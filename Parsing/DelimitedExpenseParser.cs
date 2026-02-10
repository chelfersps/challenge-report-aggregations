using System.Globalization;
using ExpenseAggregator.Models;

namespace ExpenseAggregator.Parsing;

/// <summary>
/// Purposefully built parser for challenge's input data format
/// </summary>
public class DelimitedExpenseParser : IExpenseParser
{
    public IReadOnlyList<Expense> Parse(string rawText)
    {
        var expenses = new List<Expense>();

        foreach (var line in rawText.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (TryParseLine(line, out var expense))
                expenses.Add(expense);
        }

        return expenses;
    }

    private static bool TryParseLine(string line, out Expense expense)
    {
        expense = default!;

        var fields = line.Split(',', StringSplitOptions.TrimEntries);
        if (fields.Length < 3)
            return false;

        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var field in fields)
        {
            var parts = field.Split(':', 2, StringSplitOptions.TrimEntries);
            if (parts.Length == 2)
                values[parts[0]] = parts[1];
        }

        if (!values.TryGetValue("id", out var idStr) || !int.TryParse(idStr, out var id))
            return false;

        if (!values.TryGetValue("category", out var category) || string.IsNullOrWhiteSpace(category))
            return false;

        if (!values.TryGetValue("amount", out var amountStr)
            || !decimal.TryParse(amountStr, NumberStyles.Number, CultureInfo.InvariantCulture, out var amount))
            return false;

        expense = new Expense(id, category, amount);
        return true;
    }
}
