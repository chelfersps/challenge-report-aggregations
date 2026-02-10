1. The Scenario
You have been given a raw string of text representing a series of company expenses. Your task is to parse this string, process the data, and print a simple text-based summary report.

2. The Input Data
```
id:1, category:Travel, amount:50.00
id:2, category:Food, amount:120.50
id:3, category:Travel, amount:200.00
id:4, category:Office, amount:45.00
id:5, category:Food, amount:15.00
id:6, category:Hardware, amount:1100.00
id:7, category:Travel, amount:XX.XX
```

3. The Requirements

- Write a function/script that performs the following steps:
Parse: Convert the raw string into a structured format (objects, dictionaries, etc.).
- Clean: Filter out any transaction where the amount is not a valid number (see id:7)
- Aggregate: Implement a function that can group the expenses based on one or more data fields a person may choose (e.g., category, id) and calculate one or more aggregate functions (e.g., total spent, count of transactions). For the required output, group the expenses by category and calculate the total spent and count of transactions.

Format: Return or Print a summary that looks like the output below.
```
Category: Food - Total: $135.50 (2 transactions)
Category: Hardware - Total: $1100.00 (1 transaction)
Category: Office - Total: $45.00 (1 transaction)
Category: Travel - Total: $250.00 (2 transactions)
```