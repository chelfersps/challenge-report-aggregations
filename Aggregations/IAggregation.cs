using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations;

public interface IAggregation
{
    string Label { get; }
    string Compute(IReadOnlyList<Expense> expenses);
}
