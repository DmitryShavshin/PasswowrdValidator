using System.Text.RegularExpressions;

string filePath = "Passwords.txt";
int successCount = 0;

try
{
    //string[] rows = File.ReadAllText(filePath).Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    string[] rows = File.ReadAllLines(filePath);
    

    foreach (string row in rows)
    {
        if (IsConditionMet(row))
        {
            successCount++;
            Console.WriteLine("Condition met for row:");
            Console.WriteLine(row);
            Console.WriteLine("------------------------");
           
        }
    }

    Console.WriteLine($"Total rows that meet the condition: {successCount}");
    
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
    
static bool IsConditionMet(string input)
{
    int countA = Regex.Matches(input, "a").Count;
    int countZ = Regex.Matches(input, "z").Count;
    int countB = Regex.Matches(input, "b").Count;

    return countA >= 1 && countA <= 5 ||
           countZ >= 2 && countZ <= 4 ||
           countB >= 3 && countB <= 6;
}