using ExpenseAggregator.Aggregations;

namespace ExpenseAggregator.Models;

public record AggregatedGroup(IReadOnlyList<GroupLabel> Keys, IReadOnlyList<AggregationResult> Results);
