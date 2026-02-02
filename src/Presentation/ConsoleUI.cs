using Application;
using Core.Entities;
using Application.Services;
using Core.Entities;

namespace DailyCodeGrind.Presentation;

public class ConsoleUI
{
    private readonly ProblemService _problemService;

    public ConsoleUI(ProblemService problemService)
    {
        _problemService = problemService;
    }

    public void Run()
    {
        while (true)
        {
            var problems = _problemService.GetSolvedProblems().ToList();
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        🧠 Solved DSA Problems");
            Console.WriteLine("========================================\n");

            if (!problems.Any())
            {
                Console.WriteLine("No problems found.\nCheck your files and paths.");
                Console.WriteLine("[Press any key to exit]");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < problems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {problems[i].Title} ({problems[i].Difficulty})");
            }

            Console.WriteLine("0. Exit\n");
            Console.Write("[Please select a problem]: ");
            var input = Console.ReadLine();

            if (input == "0") break;

            if (int.TryParse(input, out int index) &&
                index >= 1 && index <= problems.Count)
            {
                ShowProblemDetails(problems[index - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key...");
                Console.ReadKey();
            }
        }
    }

    private void ShowProblemDetails(ProblemMetadata problem)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"📌 {problem.Title}");
        Console.WriteLine("========================================");
        Console.WriteLine($"📊 Difficulty : {problem.Difficulty}");
        Console.WriteLine($"📅 Solved At  : {problem.SolvedAt:d}");
        Console.WriteLine($"🔗 URL        : {problem.Url}");
        Console.WriteLine($"🧠 Big-O      : {problem.Complexity ?? "N/A"}\n");

        Console.WriteLine("📝 Description:");
        Console.WriteLine(string.IsNullOrWhiteSpace(problem.Description) ? "No description provided." : problem.Description);

        Console.WriteLine("\n💡 Solution:");
        if (!string.IsNullOrEmpty(problem.FilePath) && File.Exists(problem.FilePath))
        {
            Console.WriteLine(File.ReadAllText(problem.FilePath));
        }
        else
        {
            Console.WriteLine("[Solution file not found]");
        }

        Console.WriteLine("\n[Press any key to return to menu...]");
        Console.ReadKey();
    }
}
