namespace ExpenseTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var commandLine = args[0];
            Console.WriteLine(commandLine);
            var expenseService = new ExpenseService();
            switch (commandLine)
            {
                case "add":
                    expenseService.AddExpense(
                        args[1],
                        decimal.Parse(args[2]),
                        DateTime.Parse(args[3]),
                        args[4]);
                    break;
                case "update":
                    expenseService.UpdateExpense(
                        int.Parse(args[1]),
                        args[2],
                        decimal.Parse(args[3]),
                        DateTime.Parse(args[4]),
                        args[5]);
                    break;
                    case "delete":
                        expenseService.DeleteExpense(int.Parse(args[1]));
                        break;
                    case "list":
                        expenseService.List();
                        break;
                    case "summary":
                        if (args.Length > 1)
                        {
                            expenseService.Summary(int.Parse(args[1]));
                        }
                        else
                        {
                            expenseService.Summary();
                        }
                        break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }

        }
    }
}
