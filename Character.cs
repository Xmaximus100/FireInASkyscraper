using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Character
    {
        public Character(int a, int c, int d, int e)
        {
            Regeneration = a;
            Courage = c;
            Strenght = d;
            Luck = e;
        }
        public Character()
        {
            CreateCharacter();
        }
        public void CreateCharacter()
        {
            int initialSumOfPoints = 10;
            Console.WriteLine("Tworzenie postaci");
            Console.WriteLine("Wybierz imię dla swojego nieszczęśnika, którym będziesz musiał\n" +
                "wydostać się z tego płonącego budynku");
            bool question = true;
            while (question)
            {
                Console.WriteLine("Imię: ");
                Name = Console.ReadLine();
                if (Name == "Patryk" || Name == "patryk")
                {
                    Console.WriteLine("Nie no proszę cię nie będziesz chyba grał samym twórcą, przecież to oszustwo!" +
                        "\nNiech ta gra będzie jakimś wyzwaniem dla ciebie! :c");
                }
                Console.Write("Twoje imię to ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Name + '\n');
                Console.ResetColor();
                Console.WriteLine("Czy chcesz je zmienić?\nTak (Wciśnij y)/Nie (Wciśnij n)");
                char letter = Console.ReadKey(true).KeyChar;
                if (letter == 'y') question = true;
                else if (letter == 'n') question = false;
                else
                {
                    Console.WriteLine("Nie ma takiej opcji...");
                    question = true;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (Name == "Krzysiu" || Name == "Krzysztof" || Name == "krzysztof" || Name == "krzysiu")
            {
                Console.WriteLine("Jesteś niezwykłym programistą, dlatego dodałeś swojej postaci jakieś" +
                    " chore obrażenia!\n+100 do Siły!");
                Strenght = 100;
            }
            else if (Name == "Bartek" || Name == "Bartosz" || Name == "bartosz" || Name == "bartek")
            {
                Console.WriteLine("Czy to ten słynny player Bartosz, postrach ciemnych uliczek!\n" +
                    "+50 do Odwagi!");
                Courage = 50;
            }
            else if (Name == "Olek" || Name == "Aleksander" || Name == "aleksander" || Name == "olek")
            {
                Console.WriteLine("Czy to ten słynny Olek co miał zawojować uczelnią? Niech teraz zawojuje" +
                    "budynkiem w płomieniach!\n+10 do maxHp!");
                MaxHealth += 10;
            }
            else if (Name == "Przemek" || Name == "Przemysław" || Name == "przemysław" || Name == "przemek")
            {
                Console.WriteLine("Czy to ten słynny Przemysław zbawca szpitali i klinik?" +
                    "Ciekawe czy również będzie postrachem budynku w płomieniach!\n+10 do maxHp!");
                MaxHealth += 10;
            }
            else if (Name == "Tomek" || Name == "Tomasz" || Name == "tomasz" || Name == "tomek")
            {
                Console.WriteLine("Czy to ten słynny Tomasz wielbiciel niesłuchalnej muzyki?" +
                    "W ręce dzierży wielgachnego JBL BoomBoxa! Wszyscy spieprzają przed nim aż się kurzy" +
                    "\n+20 do Szczęścia!");
                Luck += 20;
            }
            else if (Name == "Patryk" || Name == "patryk")
            {
                Console.WriteLine("No fajnie teraz jesteś niepokonany, gratuluje... JUHU ALE FRAJDA...");
                MaxHealth = 10000;
                Courage = 10000;
                Strenght = 10000;
                Regeneration = 10000;
                Health = MaxHealth;
            }
            Console.ResetColor();
            if (Name == "Patryk" || Name == "patryk") Console.WriteLine("\nUdanej ucieczki...\n\n\n");
            else 
            {
                Console.WriteLine("Teraz przydziel punkty umiejętności do swojego bohatera.\n" +
                "Umiejętności do wyboru to:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Regeneracja, Odwaga, Obrażenia, Szczęście");
                Console.ResetColor();
                SpreadingPoints(initialSumOfPoints);
                Console.WriteLine("\nUdanej ucieczki!\n\n\n");
            }
            //Console.WriteLine(Regeneration);
            //Console.WriteLine(Courage);
            //Console.WriteLine(Strenght);
            //Console.WriteLine(Luck);
        }
        public void SpreadingPoints(int amountOfPoints)
        {
            Console.WriteLine("Ilość punktów do rozdania jest równa " + amountOfPoints);
            int sumOfPoints = 0;
            while (sumOfPoints != amountOfPoints)
            {
                sumOfPoints = 0;
                Console.WriteLine("Regeneracja: ");
                int regeneration = InputGenerator();
                Console.WriteLine(" ");
                if (regeneration < 0)
                {
                    Console.WriteLine("Punkty nie mogą być ujemne oraz nie mogą być znakami");
                    sumOfPoints = -10;
                    continue;
                }
                Regeneration += regeneration;
                sumOfPoints += regeneration;
                Console.WriteLine("Zostało: " + (amountOfPoints - sumOfPoints) + " punktów do rozdania");
                Console.WriteLine("Odwaga: ");
                int courage = InputGenerator();
                Console.WriteLine(" ");
                if (courage < 0)
                {
                    Console.WriteLine("Punkty nie mogą być ujemne oraz nie mogą być znakami");
                    sumOfPoints = -10;
                    continue;
                }
                Courage += courage;
                sumOfPoints += courage;
                Console.WriteLine("Zostało: " + (amountOfPoints - sumOfPoints) + " punktów do rozdania");
                Console.WriteLine("Obrażenia: ");
                int damage = InputGenerator();
                Console.WriteLine(" ");
                if (damage < 0)
                {
                    Console.WriteLine("Punkty nie mogą być ujemne oraz nie mogą być znakami");
                    sumOfPoints = -10;
                    continue;
                }
                Strenght += damage;
                sumOfPoints += damage;
                Console.WriteLine("Zostało: " + (amountOfPoints - sumOfPoints) + " punktów do rozdania");
                Console.WriteLine("Szczęście: ");
                int luck = InputGenerator();
                Console.WriteLine(" ");
                if (luck < 0)
                {
                    Console.WriteLine("Punkty nie mogą być ujemne oraz nie mogą być znakami");
                    sumOfPoints = -10;
                    continue;
                }
                Luck += luck;
                sumOfPoints += luck;
                if (sumOfPoints != amountOfPoints)
                {
                    Console.WriteLine("Źle rozdałeś punkty!");
                    sumOfPoints = 0;
                }
                else if (sumOfPoints == amountOfPoints) Console.WriteLine("Rozdałeś poprawnie wszystkie punkty.");
                Health = MaxHealth;
            }
        }
        public int InputGenerator()
        {
            char key = Console.ReadKey().KeyChar;
            if (key == '0') return 0;
            else if (key == '1') return 1;
            else if (key == '2') return 2;
            else if (key == '3') return 3;
            else if (key == '4') return 4;
            else if (key == '5') return 5;
            else if (key == '6') return 6;
            else if (key == '7') return 7;
            else if (key == '8') return 8;
            else if (key == '9') return 9;
            else return -1;
        }
        public int Regeneration { get; set; } = 0;
        public int Courage { get; set; } = 15;
        public int Health { get; set; } = MaxHealth;
        public static int MaxHealth { get; set; } = 100;
        public int Strenght { get; set; } = 0;
        public int Luck { get; set; } = 0;
        public int Oxygen { get; set; } = 500;
        public string Name { get; set; }
        public void ShowStats()
        {
            Console.WriteLine("\nTWOJE STATY:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Name);
            Console.ResetColor();
            Console.WriteLine("=====================\nUMIEJĘTNOŚCI: ");
            Console.WriteLine("Max hp: " + MaxHealth);
            Console.WriteLine("Regeneracja: " + Regeneration);
            Console.WriteLine("Siła: " + Strenght);
            Console.WriteLine("Szczęście: " + Luck);
            Console.WriteLine("=====================\nSTATYSTYKI FIZJOLOGICZNE: ");
            Console.Write("Hp: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Health);
            Console.ResetColor();
            Console.Write("\nTlen: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Oxygen);
            Console.ResetColor();
            Console.Write("\nOdwaga: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Courage);
            Console.ResetColor();
        }
    }
}
