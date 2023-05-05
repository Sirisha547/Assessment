namespace final
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }



        public Transaction(string title, string description, double amount, DateTime date)
        {
            Title = title;
            Description = description;
            Amount = amount;
            Date = date;
        }



    }
    class Tracker
    {
        public List<Transaction> transactions = new List<Transaction>();



        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }



        public List<Transaction> ViewExpense()
        {
            return transactions.Where(t => t.Amount < 0).ToList();
        }



        public List<Transaction> ViewIncome()
        {
            return transactions.Where(t => t.Amount > 0).ToList();
        }



        public double CheckAvailableBalance()
        {
            return transactions.Sum(t => t.Amount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();



            while (true)
            {
                Console.WriteLine("Welcome to Expense Tracker App");



                Console.WriteLine("1. AddExpenses ");
                //Console.WriteLine();
                Console.WriteLine("2. ViewExpenses ");
                Console.WriteLine("3. ViewIncome ");
                Console.WriteLine("4. CheckAvailableBalance ");



                Console.WriteLine("Enter ur choice");
                int ch = Convert.ToInt32(Console.ReadLine());



                switch (ch)
                {
                    case 1:
                        {
                            Console.Write("Enter title: ");
                            string title = Convert.ToString(Console.ReadLine());



                            Console.Write("Enter description: ");
                            string description = Convert.ToString(Console.ReadLine());



                            Console.Write("Enter amount: ");
                            double amount = Convert.ToDouble(Console.ReadLine());



                            Console.Write("Enter date (yyyy-mm-dd): ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());



                            tracker.AddTransaction(new Transaction(title, description, amount, date));




                            Console.WriteLine("Transaction added successfully!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("View Expenses:");
                            Console.WriteLine("title\t\tdescription\t\tamount\t\tdate");
                            List<Transaction> expenses = tracker.ViewExpense();
                            foreach (Transaction expense in expenses)
                            {
                                Console.WriteLine($"Title: {expense.Title}, Description: {expense.Description}, Amount: {expense.Amount}, Date: {expense.Date.ToShortDateString()}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Incomes:");
                            Console.WriteLine("title\t\tdescription\t\tamount\t\tdate");
                            List<Transaction> incomes = tracker.ViewIncome();
                            foreach (Transaction income in incomes)
                            {
                                Console.WriteLine($"Title: {income.Title}, Description: {income.Description}, Amount: {income.Amount}, Date: {income.Date.ToShortDateString()}");
                            }
                            break;
                        }
                    case 4:
                        {
                            double availableBalance = tracker.CheckAvailableBalance();
                            Console.WriteLine($"Available Balance: {availableBalance}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("u entered the wrong choice");
                            break;
                        }
                }




            }
        }
    }
}
