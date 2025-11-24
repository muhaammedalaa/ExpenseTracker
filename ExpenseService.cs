using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace ExpenseTracker
{
    internal class ExpenseService
    {
        private readonly string filePath = "expenses.json";
        private List<Expense> Load ()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
                return new List<Expense>();
            }
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
        }
        private void Save (List<Expense> expenses)
        {
            var json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        public void AddExpense(string description, decimal amount, DateTime date, string category)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }
            var expenses = Load();
            var newExpense = new Expense
            {
                Id = expenses.Any() ? expenses.Max(e => e.Id) + 1 : 1,
                Description = description,
                Amount = amount,
                Date = date,
                Category = category
            };
            expenses.Add(newExpense);
            Save(expenses);
            Console.WriteLine($"Expense added successfully.");
        }
        public void UpdateExpense(int id, string description, decimal amount, DateTime date, string category)
        {
            var expenses = Load();
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expense.Description = description;
                expense.Amount = amount;
                expense.Date = date;
                expense.Category = category;
                Save(expenses);
                Console.WriteLine("Expense updated successfully");
            }
            else
            {
                Console.WriteLine("Expense not found");
            }
        }
        public void DeleteExpense(int id)
        {
            var expenses = Load();
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
                Save(expenses);
                Console.WriteLine("Expense deleted successfully");
            }
            else
            {
                Console.WriteLine("Expense not found");
            }
        } 
        public void List ()
        {
            var expenses = Load();
            foreach (var expense in expenses)
            {
                Console.WriteLine($"ID: {expense.Id}, Description: {expense.Description}, Amount: {expense.Amount}, Date: {expense.Date.ToShortDateString()}, Category: {expense.Category}");
            }
        }
        // Summary of all expenses
        public void Summary (int? month = null)
        {           
            var expenses = Load();
            var filteredExpenses = month.HasValue ? expenses.Where(e => e.Date.Month == month.Value) : expenses;
            var total = filteredExpenses.Sum(e => e.Amount);
            Console.WriteLine($"Total Expenses{(month.HasValue ? $" for month {month}" : "")}: {total}");
        }
    }
}
