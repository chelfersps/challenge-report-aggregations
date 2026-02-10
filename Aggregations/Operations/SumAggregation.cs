using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations.Operations;

public class SumAggregation : IAggregation
{
    public string Label => "Total";

    public string Compute(IReadOnlyList<Expense> expenses) =>
        $"${expenses.Sum(e => e.Amount):F2}";
}
