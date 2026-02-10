using ExpenseAggregator.Aggregations;
using ExpenseAggregator.Aggregations.Operations;
using ExpenseAggregator.Formatting;
using ExpenseAggregator.Parsing;

var rawData = """
    id:1, category: Travel, amount: 50.00
    id:2, category:Food, amount:120.50
    id:3, category:Travel, amount:200.00
    id:4, category: Office, amount: 45.00
    id:5, category:Food, amount:15.00
    id:6, category:Hardware, amount:1100.00
    id:7, category: Travel, amount:XX.XX
    """;

var parser = new DelimitedExpenseParser();
var expenses = parser.Parse(rawData);

var aggregator = new ExpenseGroupAggregator(
    groupingKeys: [new CategoryGroupingKey()],
    aggregations: [new SumAggregation(), new CountAggregation()]
);
var groups = aggregator.Aggregate(expenses);

var formatter = new PlainTextReportFormatter();
Console.WriteLine(formatter.Format(groups));
