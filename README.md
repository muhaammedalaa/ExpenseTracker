Expense Tracker CLI (C#) 
A simple command-line application to manage and track your expenses. You can add, update, delete, list expenses, and view summaries for all expenses or by month. 
Project Features :
Add an expense with description, amount, date, and category. 
Update an existing expense.
Delete an expense.
List all expenses.
View a summary of all expenses.
View a summary of expenses for a specific month.
How to Run

Open terminal in the project directory.

Use the following commands:
# Add a new expense
dotnet run -- add "Lunch" 20 2025-11-24 Food

# Update an expense
dotnet run -- update 1 "Dinner" 25 2025-11-24 Food

# Delete an expense
dotnet run -- delete 1

# List all expenses
dotnet run -- list

# Show summary of all expenses
dotnet run -- summary

# Show summary for a specific month (e.g., November)
dotnet run -- summary 11
Project Structure :
ExpenseTracker/
│── Program.cs
│── ExpenseService.cs
│── ExpenseItem.cs
│── expenses.json
│── ExpenseTracker.csproj
│── README.md
Project URL : https://roadmap.sh/projects/expense-tracker
