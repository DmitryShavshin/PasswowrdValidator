string filePath = "Passwords.txt";
            try
            {
                string[] rows = File.ReadAllText(filePath).Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string row in rows)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
