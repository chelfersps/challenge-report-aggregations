using ExpenseAggregator.Models;

namespace ExpenseAggregator.Formatting;

public interface IReportFormatter<in T>
{
    string Format(IReadOnlyList<T> groups);
}
