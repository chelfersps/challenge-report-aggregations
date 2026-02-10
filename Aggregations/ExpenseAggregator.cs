using ExpenseAggregator.Models;

namespace ExpenseAggregator.Aggregations;

public class ExpenseGroupAggregator(IReadOnlyList<IGroupingKey> groupingKeys, IReadOnlyList<IAggregation> aggregations)
{
    public IReadOnlyList<AggregatedGroup> Aggregate(IReadOnlyList<Expense> expenses)
    {
        var groups = expenses
            .GroupBy(e => BuildCompositeKey(e))
            .OrderBy(g => g.Key)
            .Select(g =>
            {
                var items = g.ToList();
                var keyLabels = groupingKeys
                    .Select(k => new GroupLabel(k.Name, k.GetKey(items[0])))
                    .ToList();

                var results = aggregations
                    .Select(a => new AggregationResult(a.Label, a.Compute(items)))
                    .ToList();

                return new AggregatedGroup(keyLabels, results);
            })
            .ToList();

        return groups;
    }

    private string BuildCompositeKey(Expense expense) =>
        string.Join(":", groupingKeys.Select(k => k.GetKey(expense)));
}

public record GroupLabel(string Name, string Value);
public record AggregationResult(string Label, string Value);
