using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FireInASkyscraper
{
    class Inventory
    {
        static Dictionary<string, int> inventory = new Dictionary<string, int>()
        {
            {"Health Potion", 0 },
            {"Bandage", 0 },
            {"Medical Kit", 0 },
            {"Extinguisher", 0 },
            {"Revolver", 0 },
            {"Sword", 0 },
            {"Knife", 0 },
            {"Bat", 0 },
            {"Flash Light", 0 },
            {"Parachute", 0 },
            {"Key", 0 },
            {"Gold Key", 0 }
        };
        public static void ShowInventoryEng()
        {
            Console.WriteLine(" ");
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }
            }
        }
        public static void LoadCurrentInventory(StreamWriter sw)
        {
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                sw.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
        }
        public static void ItemStats(StreamWriter sw)
        {
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                sw.WriteLine("{0}", kvp.Value);
            }
        }
        public static void LoadInventory(List <int> stats)
        {
            inventory["Health Potion"] = stats[0];
            Console.WriteLine(inventory["Health Potion"]);
            inventory["Bandage"] = stats[1];
            Console.WriteLine(inventory["Bandage"]);
            inventory["Medical Kit"] = stats[2];
            Console.WriteLine(inventory["Medical Kit"]);
            inventory["Extinguisher"] = stats[3];
            Console.WriteLine(inventory["Extinguisher"]);
            inventory["Revolver"] = stats[4];
            inventory["Sword"] = stats[5];
            inventory["Knife"] = stats[6];
            inventory["Bat"] = stats[7];
            inventory["Flash Light"] = stats[8];
            inventory["Parachute"] = stats[9];
            inventory["Key"] = stats[10];
            inventory["Gold Key"] = stats[11];
        }
        public static void ShowInventory()
        {
            Console.WriteLine("\nTWOJE EQ:\n=====================\nLECZENIE:");
            if (inventory["Health Potion"] > 0) Console.WriteLine("Potiony: " + inventory["Health Potion"]);
            if (inventory["Bandage"] > 0) Console.WriteLine("Badaże: " + inventory["Bandage"]);
            if (inventory["Medical Kit"] > 0) Console.WriteLine("Apteczki: " + inventory["Medical Kit"]);
            Console.WriteLine("=====================\nPRZEDMIOTY DO UŻYCIA:");
            if (inventory["Extinguisher"] > 0) Console.WriteLine("Gaśnice: " + inventory["Extinguisher"]);
            if (inventory["Flash Light"] > 0) Console.WriteLine("Latarki: " + inventory["Flash Light"]);
            if (inventory["Parachute"] > 0) Console.WriteLine("Spadochron: " + inventory["Parachute"]);
            if (inventory["Key"] > 0) Console.WriteLine("Klucze: " + inventory["Key"]);
            if (inventory["Gold Key"] > 0) Console.WriteLine("Złoty klucz: " + inventory["Gold Key"]);
            Console.WriteLine("=====================\nBRONIE:");
            if (inventory["Bat"] > 0) Console.WriteLine("Drewniana pałka: " + inventory["Bat"]);
            if (inventory["Knife"] > 0) Console.WriteLine("Nóż: " + inventory["Knife"]);
            if (inventory["Sword"] > 0) Console.WriteLine("Miecz: " + inventory["Sword"]);
            if (inventory["Revolver"] > 0) Console.WriteLine("Rewolwer: " + inventory["Revolver"]);
            Console.WriteLine("=====================\nBROŃ W UŻYCIU:");
            if (inventory["Revolver"] > 0) Console.WriteLine("Dzierżysz w ręce piękny rewolwer niczym Clint Eastwood");
            if (inventory["Sword"] > 0 && inventory["Revolver"] == 0) 
                Console.WriteLine("W dłoniach zaciśnięty masz wielki stalowy miecz");
            if (inventory["Knife"] > 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0) 
                Console.WriteLine("W ręce trzymasz 20-centymetrowy nóż, można tym zrobić krzywdę");
            if (inventory["Bat"] > 0 && inventory["Knife"] == 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0)
                Console.WriteLine("W ręce masz zwykłą drewnianą pałke, może wybijesz nią niektórym głupotę z głowy");
            if (inventory["Bat"] == 0 && inventory["Knife"] == 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0) 
                Console.WriteLine("Nie posiadasz niczego do walki, jedynie twoje szorstkie, poparzone, gołe pięści");
        }
        public static void PickingUpHealing()
        {
            int chance = GameRules.randomNumber(0, 100);
            if (chance > 80)
            {
                PickUpMedicalKit();
            }
            else if (chance <= 80 && chance > 45)
            {
                PickUpBandage();
            }
            else PickUpHealthPotion();
        }
        public static void PickUpHealthPotion()
        {
            ++inventory["Health Potion"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Podnosisz potke na hpeki>");
            Console.WriteLine("Potki w eq: " + inventory["Health Potion"]);
            Console.ResetColor();
        }
        public static void PickUpBandage()
        {
            ++inventory["Bandage"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Podnosisz bandaż>");
            Console.WriteLine("Bandaże w eq: " + inventory["Bandage"]);
            Console.ResetColor();
        }
        public static void PickUpMedicalKit()
        {
            ++inventory["Medical Kit"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Podnosisz apteczke>");
            Console.WriteLine("Apteczki w eq: " + inventory["Medical Kit"]);
            Console.ResetColor();
        }
        public static void PickUpExtinguisher()
        {
            ++inventory["Extinguisher"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Podnosisz gaśnicę>\nMasz ich: " + inventory["Extinguisher"] + " w eq");
            Console.ResetColor();
        }
        public static void PickUpRevolver(Character character)
        {
            if (inventory["Revolver"] == 0)
            {
                ++inventory["Revolver"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz rewolwer>\nZadajesz teraz " + (RevolverPossesion() + character.Strenght) + " obrażeń");
                Console.ResetColor();
            }
        }
        public static int RevolverPossesion()
        {
            if (inventory["Revolver"] > 0) return 100;
            else return 0;
        }
        public static void PickUpSword(Character character)
        {
            if (inventory["Sword"] == 0 && inventory["Revolver"] == 0)
            {
                ++inventory["Sword"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz miecz>\nZadajesz teraz " + (SwordPossesion() + character.Strenght) + " obrażeń");
                Console.ResetColor();
            }
        }
        public static int SwordPossesion()
        {
            if (inventory["Sword"] > 0 && inventory["Revolver"] == 0) return 40;
            else return 0;
        }
        public static void PickUpKnife(Character character)
        {
            if (inventory["Knife"] == 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0)
            {
                ++inventory["Knife"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz nóż>\nZadajesz teraz " + (KnifePossesion() + character.Strenght) + " obrażeń");
                Console.ResetColor();
            }
        }
        public static int KnifePossesion()
        {
            if (inventory["Knife"] > 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0) return 15;
            else return 0;
        }
        public static void PickUpBat(Character character)
        {
            if (inventory["Bat"] == 0 && inventory["Knife"] == 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0)
            {
                ++inventory["Bat"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz drewnianą pałkę>\nZadajesz teraz " + (BatPossesion() + character.Strenght) + " obrażeń");
                Console.ResetColor();
            }
        }
        public static int BatPossesion()
        {
            if (inventory["Bat"] > 0 && inventory["Knife"] == 0 && inventory["Sword"] == 0 && inventory["Revolver"] == 0) return 8;
            else return 0;
        }
        public static void PickUpFlashLight()
        {
            ++inventory["Flash Light"];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Podnosisz latarkę>\nMasz ich: " + inventory["Flash Light"] + " w eq");
            Console.ResetColor();
        }
        public static void PickUpParachute()
        {
            if (inventory["Parachute"] == 0)
            {
                ++inventory["Parachute"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz spadochron>\nTeraz wystarczy tylko okno do wolności!\n" +
                    "Pssst!\nUważaj tylko na buchające płomienie...");
                Console.ResetColor();
            }
        }
        public static bool ParachutePossesion()
        {
            if (inventory["Parachute"] > 0) return true;
            else return false;
        }
        public static void PickUpKey()
        {
            int chance = GameRules.randomNumber(0, 100);
            if (chance < 95 && inventory["Gold Key"] == 0)
            {
                ++inventory["Key"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz kluczyk>\nMasz ich: " + inventory["Key"] + " w eq\n" +
                    "Niestety każdy pasuje tylko do jednej dziurki... Chyba, że jest on złoty! Powodzenia!");
                Console.ResetColor();
            }
            else if (chance < 95 && inventory["Gold Key"] > 0)
            {
                ++inventory["Key"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Podnosisz kluczyk>\nMasz ich: " + inventory["Key"] + " w eq\n" +
                    "Ale kogo to obchodzi! Ty masz złoty klucz! Żadna dziurka ci nie straszna!");
                Console.ResetColor();
            }
            else if (chance <= 95 && inventory["Gold Key"] == 0)
            {
                ++inventory["Gold Key"];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<PODNOSISZ ZŁOTY KLUCZYK>\n" +
                    "Od teraz jesteś Panem i Władcą wszystkich wrot!\n" +
                    "Liczę, że wydostaniesz się z tego piekła jak najszybciej!");
                Console.ResetColor();
            }
        }
        public static void UseHealthPotion(Character character)
        {
            if (inventory["Health Potion"] > 0)
            {
                --inventory["Health Potion"];
                Console.WriteLine("<Wykorzystano potkę>");
                if (character.Health < Character.MaxHealth && character.Health > (Character.MaxHealth - 25))
                {
                    character.Health = Character.MaxHealth;
                    Console.WriteLine("Wyleczono hpeki do pełna");
                }
                else if (character.Health <= (Character.MaxHealth - 25))
                {
                    character.Health += 25;
                    Console.Write("Masz: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(character.Health + " hp\n");
                    Console.ResetColor();
                }
                else Console.WriteLine("Masz full full");
            }
            else Console.WriteLine("Nie masz żadnych potionek");
        }
        public static bool HealthPotionPossesion()
        {
            if (inventory["Health Potion"] > 0) return true;
            else return false;
        }
        public static void UseBandage(Character character)
        {
            if (inventory["Bandage"] > 0)
            {
                --inventory["Bandage"];
                Console.WriteLine("<Wykorzystano bandaż>");
                if (character.Health < Character.MaxHealth && character.Health > (Character.MaxHealth - 50))
                {
                    character.Health = Character.MaxHealth;
                    Console.WriteLine("Wyleczono hpeki do pełna");
                }
                else if (character.Health <= (Character.MaxHealth - 50))
                {
                    character.Health += 50;
                    Console.Write("Masz: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(character.Health + " hp\n");
                    Console.ResetColor();
                }
                else Console.WriteLine("Masz full hp");
            }
            else Console.WriteLine("Nie masz żadnych bandaży");
        }
        public static bool BandagePossesion()
        {
            if (inventory["Bandage"] > 0) return true;
            else return false;
        }
        public static void UseMedicalKit(Character character)
        {
            if (inventory["Medical Kit"] > 0)
            {
                --inventory["Medical Kit"];
                Console.WriteLine("<Wykorzystano apteczkę>");
                if (character.Health < Character.MaxHealth && character.Health > (Character.MaxHealth - 75))
                {
                    character.Health = Character.MaxHealth;
                    Console.WriteLine("Wyleczono hpeki do pełna");
                }
                else if (character.Health <= (Character.MaxHealth - 75))
                {
                    character.Health += 75;
                    Console.Write("Masz: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(character.Health + " hp\n");
                    Console.ResetColor();
                }
                else Console.WriteLine("Masz full hp");
            }
            else Console.WriteLine("Nie masz żadnych apteczek");
        }
        public static bool MedicalKitPossesion()
        {
            if (inventory["Medical Kit"] > 0) return true;
            else return false;
        }
        public static bool Darkness(Character character)
        {
            if (inventory["Flash Light"] > 0)
            {
                --inventory["Flash Light"];
                Console.WriteLine("<Wykorzystano latarkę>\n" +
                    "Pozostało: " + inventory["Flash Light"]);
                return true;
            }
            else if (inventory["Flash Light"] == 0)
            {
                GameRules.CourageCheck(character);
                --character.Courage;
                Console.WriteLine("Nie masz latarki! Obniżono odwagę o kolejny punkt\n" +
                    "Punkty odwagi: " + character.Courage);
                return false;
            }
            else return false;
        }
        public static bool Flame(Character character)
        {
            if (inventory["Extinguisher"] > 0)
            {
                --inventory["Extinguisher"];
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("<Wykorzystano gaśnicę>\n" +
                    "Pozostało: " + inventory["Extinguisher"]);
                Console.ResetColor();
                return false;
            }
            else if (inventory["Extinguisher"] == 0)
            {
                character.Health -= 10;
                GameRules.HealthCheck(character);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nie masz gaśnicy! Tracisz 10hp\n" +
                    "Twoje zdrowie: " + character.Health + " hp");
                Console.ResetColor();
                return true;
            }
            else return true;
        }
        public static void JumpWithParachute(Character character, int roomNumber)
        {
            int chance = GameRules.randomNumber(0, 300) - roomNumber;  
            if (inventory["Parachute"] > 0 && character.Oxygen > 500)
            {
                --inventory["Parachute"];
                Console.WriteLine("<Użyto spadochronu>");
                if (chance > 100)
                {
                    GameRules.Room = 0;
                    GameRules.EndByParachute();
                }
                else
                {
                    Console.WriteLine("<Buchający płomień zdmuchnął cię z powierzchni ziemi...\n" +
                        "Ostrzegałem!");
                    GameRules.GameOver();
                }
            }
            else if (inventory["Parachute"] == 0)
            {
                Console.WriteLine("Wychylasz się przez okno, gotów do popisowego skoku...");
                Console.WriteLine("UPS!");
                Console.WriteLine("Zapomniałeś, że nie masz spadochronu, a latać też nie potrafisz...\n" +
                    "Wielka to strata...");
                character.Health = 0;
                GameRules.HealthCheck(character);
            }
        }
        public static bool UseKey(Character character)
        {
            int chance = GameRules.randomNumber(0, 100);
            if (inventory["Key"] > 0 && inventory["Gold Key"] == 0)
            {
                --inventory["Key"];
                Console.WriteLine("<Wykorzystano klucz>\n" +
                    "Pozostało: " + inventory["Key"]);
                Level.ExperienceUp(100, character);
                return true;
            }
            else if (inventory["Gold Key"] > 0)
            {
                if (chance < 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Z kunsztem otwierasz nieszczęsne wrota!");
                    Console.ResetColor();
                    Level.ExperienceUp(300, character);
                    return true;
                }
                else if (chance >= 30 && chance < 60)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Z blaskiem otwierasz otwierasz kolejne bramy tego piekła!");
                    Console.ResetColor();
                    Level.ExperienceUp(300, character);
                    return true;
                }
                else if (chance >= 60 && chance <= 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Żadne drzwi nie są przeszkodą dla Złotego Klucza! Także i te! Akyszzzz!");
                    Console.ResetColor();
                    Level.ExperienceUp(300, character);
                    return true;
                }
                else return true;
            }
            else return false;
        }
        public static bool KeyPossesion()
        {
            return (inventory["Key"] > 0);
        }
    }
}
