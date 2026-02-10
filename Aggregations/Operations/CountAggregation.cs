using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations.Operations;

public class CountAggregation : IAggregation
{
    public string Label => "Transactions";

    public string Compute(IReadOnlyList<Expense> expenses)
    {
        var count = expenses.Count;
        var noun = count == 1 ? "transaction" : "transactions";
        return $"{count} {noun}";
    }
}
