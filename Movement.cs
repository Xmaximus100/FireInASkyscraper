using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Movement
    {
        public static bool WentLeft { get; set; } = false;
        public static bool WentRight { get; set; } = false;
        public static bool WentUp { get; set; } = false;
        public static bool WentDown { get; set; } = false;
        public static bool[] VisitedRooms { get; set; } = new bool[199];
        public static bool[] EnemyInRoom { get; set; } = new bool[199];
        public static void GoUp(Character character, Rooms nextRoom)
        {
            if (Fight.RunSucceded == true && WentUp == true)
            {
                GameRules.Room -= 3;
                character.Oxygen -= 3;
                Console.WriteLine("Ucieczka się powiodła!");
                WentDown = false;
                WentUp = false;
                WentLeft = false;
                WentRight = false;
            }
            else if (Fight.RunSucceded == false)
            {
                if (nextRoom.Lock == false)
                {
                    GameRules.Room += 3;
                    character.Oxygen -= 3;
                    Console.WriteLine("Idziesz górę");
                    WentLeft = false;
                    WentRight = false;
                    WentUp = true;
                    WentDown = false;
                    GameRules.OxygenCheck(character);
                }
                else if (nextRoom.Lock == true && Inventory.KeyPossesion() == true)
                {
                    Console.WriteLine("Pokój był zamknięty, ale otworzyłeś go kluczykiem");
                    GameRules.Room += 3;
                    character.Oxygen -= 3;
                    Console.WriteLine("Idziesz w górę");
                    WentLeft = false;
                    WentRight = false;
                    WentUp = true;
                    WentDown = false;
                    GameRules.OxygenCheck(character);
                }
                else
                {
                    Console.WriteLine("Pokój " + (GameRules.Room + 3) + " jest zamknięty");
                }
            }
        }
        public static void GoDown(Character character, Rooms nextRoom)
        {
            if (Fight.RunSucceded == true && WentDown == true)
            {
                GameRules.Room += 3;
                character.Oxygen -= 3;
                Console.WriteLine("Ucieczka się powiodła!");
                WentDown = false;
                WentUp = false;
                WentLeft = false;
                WentRight = false;
            }
            else if (Fight.RunSucceded == false)
            {
                if (nextRoom.Lock == false)
                {
                    GameRules.Room -= 3;
                    character.Oxygen -= 3;
                    Console.WriteLine("Idziesz w dół");
                    WentLeft = false;
                    WentRight = false;
                    WentUp = false;
                    WentDown = true;
                    GameRules.OxygenCheck(character);
                }
                else if (nextRoom.Lock == true && Inventory.KeyPossesion() == true)
                {
                    Console.WriteLine("Pokój był zamknięty, ale otworzyłeś go kluczykiem");
                    GameRules.Room -= 3;
                    character.Oxygen -= 3;
                    Console.WriteLine("Idziesz w dół");
                    WentLeft = false;
                    WentRight = false;
                    WentUp = false;
                    WentDown = true;
                    GameRules.OxygenCheck(character);
                }
                else
                {
                    Console.WriteLine("Pokój " + (GameRules.Room - 3) + " jest zamknięty");
                }
            }
        }
        public static void GoRight(Character character, Rooms nextRoom)
        {
            if (Fight.RunSucceded == true && WentRight == true)
            {
                GameRules.Room += 1;
                character.Oxygen -= 1;
                Console.WriteLine("Ucieczka się powiodła!");
                WentDown = false;
                WentUp = false;
                WentLeft = false;
                WentRight = false;
            }
            else if (Fight.RunSucceded == false)
            {
                if (nextRoom.Lock == false)
                {
                    GameRules.Room -= 1;
                    character.Oxygen -= 1;
                    Console.WriteLine("Idziesz w prawo");
                    GameRules.OxygenCheck(character);
                    WentLeft = false;
                    WentRight = true;
                    WentUp = false;
                    WentDown = false;
                }
                else if (nextRoom.Lock == true && Inventory.KeyPossesion() == true)
                {
                    Console.WriteLine("Pokój był zamknięty, ale otworzyłeś go kluczykiem");
                    GameRules.Room -= 1;
                    character.Oxygen -= 1;
                    Console.WriteLine("Idziesz w prawo");
                    GameRules.OxygenCheck(character);
                    WentLeft = false;
                    WentRight = true;
                    WentUp = false;
                    WentDown = false;
                }
                else
                {
                    Console.WriteLine("Pokój " + (GameRules.Room - 1) + " jest zamknięty");
                }
            }
        }
        public static void GoLeft(Character character, Rooms nextRoom)
        {
            if (Fight.RunSucceded == true && WentLeft == true)
            {
                GameRules.Room -= 1;
                character.Oxygen -= 1;
                Console.WriteLine("Ucieczka się powiodła!");
                WentDown = false;
                WentUp = false;
                WentLeft = false;
                WentRight = false;
            }
            else if (Fight.RunSucceded == false)
            {
                if (nextRoom.Lock == false)
                {
                    GameRules.Room += 1;
                    character.Oxygen -= 1;
                    Console.WriteLine("Idziesz w lewo");
                    WentLeft = true;
                    WentRight = false;
                    WentUp = false;
                    WentDown = false;
                    GameRules.OxygenCheck(character);
                }
                else if (nextRoom.Lock == true && Inventory.KeyPossesion() == true)
                {
                    Console.WriteLine("Pokój był zamknięty, ale otworzyłeś go kluczykiem");
                    GameRules.Room += 1;
                    character.Oxygen -= 1;
                    Console.WriteLine("Idziesz w lewo");
                    WentLeft = true;
                    WentRight = false;
                    WentUp = false;
                    WentDown = false;
                    GameRules.OxygenCheck(character);
                }
                else
                {
                    Console.WriteLine("Pokój " + (GameRules.Room + 1) + " jest zamknięty");
                }
            }
        }
        public static void Cheat(Character character)
        {
            GameRules.Room = 0;
        }
        public static void CreateTabOfRooms()
        {
            for (int i = 0; i < 199; i++)
            {
                VisitedRooms[i] = false;
                EnemyInRoom[i] = false;
            }
        }
        public static void Map(int roomNumber)
        {
            VisitedRooms[roomNumber] = true;
        }
        public static void ShowMap(int roomNumber)
        {
            bool map = true;
            int i = 198;
            Console.WriteLine("\nMAPA:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Twoja lokalizacja  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Przeciwnik");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n=====================\n   WIEŻOWIEC PŁOMYK\n=====================\n");
            Console.ResetColor();
            while (map)
            {
                if (EnemyInRoom[i] == true) Console.ForegroundColor = ConsoleColor.Yellow;
                if (i == roomNumber) Console.ForegroundColor = ConsoleColor.Red;
                if (i % 3 == 0 && VisitedRooms[i] == false && VisitedRooms[i - 1] == false & VisitedRooms[i - 2] == false)
                {
                    Console.WriteLine("---------------------\n");
                    map = false;
                }
                if (i % 3 == 0 && VisitedRooms[i] == true) Console.Write("  " + i);
                else if (i % 3 == 0 && VisitedRooms[i] == false) Console.Write("     ");
                else if (i % 3 == 2 && VisitedRooms[i] == true) Console.Write("    " + i);
                else if (i % 3 == 2 && VisitedRooms[i] == false) Console.Write("     ");
                else if (i % 3 == 1 && VisitedRooms[i] == true) Console.Write("    " + i + "\n\n");
                else if (i % 3 == 1 && VisitedRooms[i] == false) Console.Write("     \n\n");
                i--;
                Console.ResetColor();
            }
        }
    }
}
