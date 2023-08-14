using System.Text.RegularExpressions;

string filePath = "Passwords.txt";
int conditionMatches = 0;

try
{
    string[] rows = File.ReadAllLines(filePath);
    

    foreach (string row in rows)
    {
        
        string[] parts = row.Split(':');
        if (parts.Length == 2)
        {
            string condition = parts[0].Trim();
            string password = parts[1].Trim();
            
            //  Console.WriteLine(ParseCondition(condition, password) 
            //     ? $"Password '{password}' meets the condition '{condition}'." 
            //     : $"Password '{password}' does not meet the condition '{condition}'.");
            
            if (ParseCondition(condition, password))
            {
                Console.WriteLine($"Password '{password}' meets the condition '{condition}'.");
                ++conditionMatches;   
            }
            else
            {
                Console.WriteLine($"Password '{password}' does not meet the condition '{condition}'.");
            }
            
        }
    }
        Console.WriteLine($"\nPasswords meets the condition '{conditionMatches}' times");
    
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

    
static bool ParseCondition(string condition, string password)
{
    string[] conditionParts = condition.Split(' ');

    if (conditionParts.Length != 2)
    {
        return false; 
    }

    char requiredCharacter = conditionParts[0][0];

    string[] rangeParts = conditionParts[1].Split('-');
    if (rangeParts.Length != 2 || !int.TryParse(rangeParts[0], out int minCount) || !int.TryParse(rangeParts[1], out int maxCount))
    {
        return false; 
    }

    int characterCount = 0;
    foreach (char c in password)
    {
        if (c == requiredCharacter)
        {
            characterCount++;
        }
    }

    return characterCount >= minCount && characterCount <= maxCount;
}