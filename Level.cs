using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Level
    {
        public static int LevelValue { get; set; }
        public static int Experience { get; set; }
        public static void ExperienceUp(int points, Character character)
        {
            Experience += points;
            LevelUp(character);
        }
        private static void LevelUp(Character character)
        {
            switch (LevelValue)
            {
                case 0:
                    if (Experience >= 1000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "szy lvl!\n" +
                            "Zwiększono maksymalne hp o 10 punktów");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 10;
                        character.Health = Character.MaxHealth;
                        Experience -= 1000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/1000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 1:
                    if (Experience >= 2000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "gi lvl!\n" +
                            "Zwiększono maksymalne hp o 10 punktów");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 10;
                        character.Health = Character.MaxHealth;
                        Experience -= 2000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/2000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 2:
                    if (Experience >= 3000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ci lvl!\n" +
                            "Zwiększono maksymalne hp o 15 punktów");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 15;
                        character.Health = Character.MaxHealth;
                        Experience -= 3000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/3000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 3:
                    if (Experience >= 4000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 15 punktów");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 15;
                        character.Health = Character.MaxHealth;
                        Experience -= 4000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/4000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 4:
                    if (Experience >= 5000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 20 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 20;
                        character.Health = Character.MaxHealth;
                        Experience -= 5000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/5000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 5:
                    if (Experience >= 6000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 20 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 20;
                        character.Health = Character.MaxHealth;
                        Experience -= 6000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/6000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 6:
                    if (Experience >= 7000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 25 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 25;
                        character.Health = Character.MaxHealth;
                        Experience -= 7000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/7000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 7:
                    if (Experience >= 8000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 25 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 25;
                        character.Health = Character.MaxHealth;
                        Experience -= 8000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/8000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 8:
                    if (Experience >= 9000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś " + (LevelValue + 1) + "ty lvl!\n" +
                            "Zwiększono maksymalne hp o 30 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 30;
                        character.Health = Character.MaxHealth;
                        Experience -= 9000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/9000 exp");
                        Console.ResetColor();
                    }
                    break;
                case 9:
                    if (Experience >= 10000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uzyskałeś najwyższy: " + (LevelValue + 1) + "ty lvl!\n" +
                            "Gratulacje!!!\n" +
                            "Zwiększono maksymalne hp o 30 punktów"); 
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Character.MaxHealth += 30;
                        character.Health = Character.MaxHealth;
                        Experience -= 10000;
                        ++LevelValue;
                        character.SpreadingPoints(5);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Experience + "/10000 exp");
                        Console.ResetColor();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
