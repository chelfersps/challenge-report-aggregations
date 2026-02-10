using ExpenseAggregator.Models;

namespace ExpenseAggregator.Parsing;

public interface IExpenseParser
{
    IReadOnlyList<Expense> Parse(string rawText);
}
