using System;

namespace FireInASkyscraper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRules.Start();
            Character poorGuy = new Character();
            Movement.CreateTabOfRooms();
            Rooms[] room = new Rooms[199];
            for (int i = 0; i < 199; i++)
            {
                room[i] = new Rooms(i);
                Movement.EnemyInRoom[i] = room[i].Enemy;
            }
            room[GameRules.Room].CasualRoom(poorGuy);
            char choice;
            bool pass = true;
            while (pass)
            {
                choice = Console.ReadKey(true).KeyChar;
                if (choice == '1')
                {
                    Movement.GoRight(poorGuy, room[GameRules.Room - 1]);
                    pass = false;
                }
                else if (choice == 'p')
                {
                    Console.Clear();
                    Rooms.Options();
                    bool options = true;
                    while (options)
                    {
                        choice = Console.ReadKey(true).KeyChar;
                        if (choice == 't')
                        {
                            Console.WriteLine("Zapis...");
                            SaveAndLoad.SaveDictionary();
                        }
                        else if (choice == 'r')
                        {
                            Console.WriteLine("Wczytywanie...");
                            SaveAndLoad.LoadDictionary();
                        }
                        else if (choice == 'e')
                        {
                            Inventory.ShowInventory();
                        }
                        else if (choice == 'w')
                        {
                            poorGuy.ShowStats();
                        }
                        else if (choice == 'm')
                        {
                            Movement.ShowMap(GameRules.Room);
                        }
                        else if (choice == 'b')
                        {
                            options = false;
                        }
                        else if (choice == 'q')
                        {
                            Console.WriteLine("Wychodzisz z gry");
                            options = false;
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Wybrałeś złą opcję");
                            Console.ResetColor();
                        }
                    }
                    room[GameRules.Room].RoomCompletion(poorGuy, GameRules.Room);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wybrałeś złą opcję");
                    Console.ResetColor();
                }
                Movement.Map(GameRules.Room);
            }
            Console.Clear();
            while (GameRules.IsGameOn)
            {
                
                GameRules.ChoosingStage = true;
                if (room[GameRules.Room].Enemy == true && poorGuy.Health > 0)
                {
                    room[GameRules.Room].FightInRoom(poorGuy, GameRules.Room);
                    while (Fight.IsFightOn(poorGuy, room[GameRules.Room].Burglar))
                    {
                        Console.WriteLine("Atak (Wciśnij q)\nBlok (Wciśnij w)\nUcieczka (Wciśnij e)");
                        choice = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                        if (choice == 'q') Fight.AttackBurglar(poorGuy, room[GameRules.Room].Burglar);
                        else if (choice == 'w')
                        {
                            Fight.BlockBurglar(poorGuy, room[GameRules.Room].Burglar);
                        }
                        else if (choice == 'e')
                        {
                            Fight.RunBurglar(poorGuy, room[GameRules.Room].Burglar, room[GameRules.Room]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Nie ma takiej opcji");
                            Console.ResetColor();
                        }
                        room[GameRules.Room].DefeatingAnEnemy(poorGuy);
                    }
                }
                if (GameRules.IsGameOn == true)
                {
                    room[GameRules.Room].RoomGenerator(poorGuy, GameRules.Room);
                    while (GameRules.ChoosingStage)
                    {
                        choice = Console.ReadKey(true).KeyChar;
                        if ((GameRules.Room % 3 == 0 || GameRules.Room % 3 == 2) && choice == '1')
                        {
                            Console.Clear();
                            Movement.GoRight(poorGuy, room[GameRules.Room - 1]);
                            GameRules.ChoosingStage = false;
                        }
                        else if ((GameRules.Room % 3 == 1 || GameRules.Room % 3 == 2) && choice == '3')
                        {
                            Console.Clear();
                            Movement.GoLeft(poorGuy, room[GameRules.Room + 1]);
                            GameRules.ChoosingStage = false;
                        }
                        else if (GameRules.Room % 3 == 2 && choice == '2')
                        {
                            Console.Clear();
                            Movement.GoDown(poorGuy, room[GameRules.Room - 3]);
                            GameRules.ChoosingStage = false;
                        }
                        else if (GameRules.Room % 3 == 2 && GameRules.Room < 195 && choice == '4')
                        {
                            Console.Clear();
                            Movement.GoUp(poorGuy, room[GameRules.Room + 3]);
                            GameRules.ChoosingStage = false;
                        }
                        else if (choice == '`')
                        {
                            Console.Clear();
                            Movement.Cheat(poorGuy);
                            GameRules.ChoosingStage = false;
                        }
                        else if (room[GameRules.Room].Window == true && choice == 'j')
                        {
                            Console.Clear();
                            Inventory.JumpWithParachute(poorGuy, GameRules.Room);
                            GameRules.ChoosingStage = false;
                        }
                        else if (choice == 'z')
                        {
                            Inventory.UseHealthPotion(poorGuy);
                        }
                        else if (choice == 'x')
                        {
                            Inventory.UseBandage(poorGuy);
                        }
                        else if (choice == 'c')
                        {
                            Inventory.UseMedicalKit(poorGuy);
                        }
                        else if (choice == 'p')
                        {
                            Console.Clear();
                            Rooms.Options();
                            bool options = true;
                            while (options)
                            {
                                choice = Console.ReadKey(true).KeyChar;
                                if (choice == 't')
                                {
                                    Console.WriteLine("Zapis...");
                                    SaveAndLoad.SaveDictionary();
                                }
                                else if (choice == 'r')
                                {
                                    Console.WriteLine("Wczytywanie...");
                                    SaveAndLoad.LoadDictionary();
                                }
                                else if (choice == 'e') 
                                {
                                    Inventory.ShowInventory();
                                }
                                else if (choice == 'w')
                                {
                                    poorGuy.ShowStats();
                                }
                                else if (choice == 'm')
                                {
                                    Movement.ShowMap(GameRules.Room);
                                }
                                else if (choice == 'b')
                                {
                                    options = false;
                                }
                                else if (choice == 'q')
                                {
                                    Console.WriteLine("Wychodzisz z gry...");
                                    options = false;
                                    Environment.Exit(1);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Wybrałeś złą opcję");
                                    Console.ResetColor();
                                }
                            }
                            room[GameRules.Room].RoomCompletion(poorGuy, GameRules.Room);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Wybrałeś złą opcję");
                            Console.ResetColor();
                        }
                        GameRules.RoomCheck();
                        Movement.Map(GameRules.Room);
                        Movement.EnemyInRoom[GameRules.Room] = room[GameRules.Room].Enemy;
                    }
                }
            }
            Console.WriteLine("PRESS ANY KEY TO EXIT...");
            Console.ReadKey(true);
        }
    }
}
