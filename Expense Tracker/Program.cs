using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Expense
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string Purpose { get; set; }
}

class UserProfile
{
    public string Status { get; set; }
    public int Age { get; set; }
    public string Needs { get; set; }
}

class Program
{
    static List<Expense> expenses = new List<Expense>();

    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("**** Welcome to Expense Tracker ****");

        bool isRunning = true;

        while (isRunning)
        {
            isRunning = ShowNextAction();
        }

        Console.WriteLine("Thank you for using expense tracker.Goodbye!");

    }

    static bool ShowNextAction()
    {
        Console.WriteLine("What would you like to do next?");
        Console.WriteLine("Type one of the following options:");
        Console.WriteLine("- ' Enter expense ' to enter a new expense");
        Console.WriteLine("- ' View reports ' to see your expenses");
        Console.WriteLine("- ' Search expenses ' to search for specific expenses");
        Console.WriteLine("- ' Get advice ' to receive financial tips");
        Console.WriteLine("- ' Exit ' to close the application");

        string action = Console.ReadLine().Trim().ToLower();

        switch (action)
        {
            case "enter expense":
                EnterExpense();
                break;
            case "view reports":
                ViewExpenses();
                break;
            case "search expenses":
                SearchExpenses();
                break;
            case "get advice":
                RunFinancialAdvisor();
                break;
            case "exit":
                return false;
            default:
                Console.WriteLine("Sorry, I didn't understand that. Please try again.");
                break;
        }

        return true;
    }

    static void EnterExpense()
    {
        Console.Clear();
        Console.WriteLine("**** Enter Expense ****");

        decimal amount;
        while (true)
        {
            Console.Write("Enter the amount : ");
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
                break;
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }

        Console.Write("Enter the purpose (e.g., Home, Work, Leisure): ");
        string purpose = Console.ReadLine();

        Console.Write("Enter the description : ");
        string description = Console.ReadLine();

        Expense expense = new Expense();
        expense.Amount = amount;
        expense.Description = description;
        expense.Purpose = purpose;

        expenses.Add(expense);

        Console.WriteLine("Expense entered successfully.");
        Console.Clear();
    }

    static void ViewExpenses()
    {
        Console.Clear();
        Console.WriteLine("**** View Reports ****");

        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses found.");
            return;
        }

        Console.WriteLine("Expense List:");
        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Amount: {expenses[i].Amount}, Category: {expenses[i].Purpose}, Description: {expenses[i].Description}");
        }
    }

    static void SearchExpenses()
    {
        Console.Clear();
        Console.WriteLine("**** Search Expenses ****");
        Console.Write("Enter a keyword to search for (Amount, Purpose, or Description): ");
        string searchKeyword = Console.ReadLine().ToLower();

        bool found = false;

        Console.WriteLine("Search Results:");
        foreach (var expense in expenses)
        {
            if (expense.Amount.ToString().ToLower().Contains(searchKeyword) ||
                expense.Purpose.ToLower().Contains(searchKeyword) ||
                expense.Description.ToLower().Contains(searchKeyword))
            {
                Console.WriteLine($"Amount: {expense.Amount}, Purpose: {expense.Purpose}, Description: {expense.Description}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No expenses found matching your search.");
        }
    }

    static UserProfile GetUserProfile()
    {
        Console.Clear();
        Console.WriteLine("**** Create User Profile ****");

        UserProfile profile = new UserProfile();

        Console.Write("Enter your status (Student, Parent, Child): ");
        profile.Status = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter your age: ");
            if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
            {
                profile.Age = age;
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer for age.");
        }

        Console.Write("Enter your primary needs (e.g., Rent, Education, Leisure): ");
        profile.Needs = Console.ReadLine();

        return profile;
    }

    static void AdviserAI(UserProfile profile)
    {
        Console.Clear();
        Console.WriteLine("**** Adviser AI ****");
        Console.WriteLine("Let's assess your financial situation based on your profile.");
        Console.WriteLine(" ");

        switch (profile.Status.ToLower())
        {
            case "student":
                Console.WriteLine("As a student, it's crucial to manage your budget carefully and seek opportunities to save on educational expenses.");
                Console.WriteLine("Tip: Use student discounts and consider part-time work to boost your income.");
                break;
            case "parent":
                Console.WriteLine("As a parent, your focus should be on balancing household expenses with long-term savings goals.");
                Console.WriteLine("Tip: Prioritize creating an emergency fund and consider life insurance to protect your family's future.");
                break;
            case "child":
                Console.WriteLine("As a child, you're at a great stage to start building financial literacy.");
                Console.WriteLine("Tip: Save any allowances or gifts and learn about the basics of budgeting.");
                break;
            default:
                Console.WriteLine("Profile type not recognized. Please ensure your status is either Student, Parent, or Child.");
                break;
        }

        Console.WriteLine(" ");
        Console.WriteLine("**** Age-Based Financial Advice ****");

        if (profile.Age < 25)
        {
            Console.WriteLine("You're in a prime position to start investing in your future. Consider setting aside a portion of your income for long-term investments.");
        }
        else if (profile.Age >= 25 && profile.Age <= 40)
        {
            Console.WriteLine("Balance is key. Focus on paying off any debts while also building an investment portfolio.");
        }
        else
        {
            Console.WriteLine("It's essential to focus on retirement savings and ensure that your investments are aligned with your risk tolerance.");
        }

        Console.WriteLine(" ");
        Console.WriteLine($"Custom Recommendations based on your needs: {profile.Needs}");

        if (profile.Needs.ToLower().Contains("rent"))
        {
            Console.WriteLine("Consider ways to reduce housing costs, such as refinancing your mortgage or negotiating rent. You could also explore cheaper alternatives.");
        }
        else if (profile.Needs.ToLower().Contains("education"))
        {
            Console.WriteLine("Look into scholarships, grants, and affordable education options to minimize student debt. Explore part-time work to supplement your income.");
        }
        else if (profile.Needs.ToLower().Contains("leisure"))
        {
            Console.WriteLine("While leisure is important, ensure your spending is within your budget. Set a monthly cap on discretionary expenses and track your spending.");
        }
        else
        {
            Console.WriteLine("For your unique needs, consider consulting with a financial advisor to create a personalized financial plan.");
        }

        Console.WriteLine(" ");
        Console.WriteLine("Remember, every small step you take towards managing your finances today brings you closer to a secure and prosperous future. You've got this!");
        Console.WriteLine(" ");
    }


    static void RunFinancialAdvisor()
    {
        UserProfile profile = GetUserProfile();
        AdviserAI(profile);
    }
}


