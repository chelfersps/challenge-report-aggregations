using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations;

public interface IGroupingKey
{
    string Name { get; }
    string GetKey(Expense expense);
}
