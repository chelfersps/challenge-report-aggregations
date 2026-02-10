using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations;

public class CategoryGroupingKey : IGroupingKey
{
    public string Name => "Category";
    public string GetKey(Expense expense) => expense.Category;
}
