using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FireInASkyscraper
{
    class SaveAndLoad
    {
        static Dictionary<string, int> gameElements = new Dictionary<string, int>()
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
            {"Gold Key", 0 },
        };
        public static bool Saved { get; set; } = false;
        public static void SaveDictionary()
        {
            try
            {
                using (StreamWriter inventory = new StreamWriter("Equipment.txt", Saved))
                {
                    Inventory.LoadCurrentInventory(inventory);
                }
                Console.WriteLine("Zapisano!");
                using (StreamWriter iventoryStats = new StreamWriter("EquipmentStats.txt", Saved))
                {
                    Inventory.ItemStats(iventoryStats);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No mordeczko coś poszło ewidentnie nie tak!" + ex.Message);
            }
            Saved = true;
        }
        public static void LoadDictionary()
        {
            try
            {
                List<int> substitute = new List<int>();
                using (StreamReader inventoryLoad = new StreamReader("EquipmentStats.txt", Saved))
                {
                    for (int i = 0; i < 12; i++)
                    {
                        substitute.Add(Int32.Parse(inventoryLoad.ReadLine()));
                        //Console.WriteLine(" ");
                        //Console.WriteLine(substitute[i]);
                    }
                    Inventory.LoadInventory(substitute);
                    //foreach (int digit in substitute)
                    //{
                    //    Console.WriteLine(digit);
                    //}
                }
                using (StreamReader inventory = new StreamReader("Equipment.txt"))
                {
                    Console.WriteLine("WCZYTANO EKWIPUNEK\n=====================");
                    Console.WriteLine(inventory.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No mordeczko nie wiem no..." + ex.Message);
            }
        }
    }
}
