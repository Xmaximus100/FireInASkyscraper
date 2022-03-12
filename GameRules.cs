using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class GameRules
    {
        public static int Room { get; set; } = 198;
        public static bool ChoosingStage { get; set; } = true;
        public static bool IsGameOn { get; set; } = true;
        private static Random random = new Random();
        public static int randomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        public static void GameOver()
        {
            IsGameOn = false;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("COŚ TY NAROBIŁ NAJLEPSZEGO! NIE ŻYJESZ! CZEMU JA W OGÓLE DO CIEBIE GADAM...\n" +
                "Może przy kolejnym podejściu ci się uda...");
            Console.ResetColor();
        }
        public static void End()
        {
            IsGameOn = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("UDAŁO CI SIĘ! Jesteś na dole, wyszedłeś bezpiecznie z budynku, chociaż po niemałych przejściach\n" +
                "Teraz możesz poszukać jakiegoś nowego mieszkania :D");
            Console.ResetColor();
        }
        public static void EndByParachute()
        {
            if (Inventory.ParachutePossesion() == true)
            {
                IsGameOn = false;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("NIEWIARYGODNE!!!\nUdało ci się przeżyć skok z okna pomimo buhających płomieni!!!\n" +
                    "Jesteś wolny, już nic ci nie grozi, możesz spokojnie poszukać sobie nowego mieszkania...\n" +
                    "W AGHowskich akademikach jest sporo miejsca :D\nZapraszam na kielona, za skok w takim stylu trzeba" +
                    "wznieść toast!");
                Console.ResetColor();
            }
            else
            {
                IsGameOn = false;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("NIE WIERZE!!!\nTy naprawdę wyskoczyłeś z okna bez spadochronu, z palącego budynku!?\n" +
                    "Jeszcze udało ci się przeżyć!? Ej naprawdę gratki, chociaż mogłeś zrobic jakies salto w locie...\n" +
                    "Ale no cóż zapraszam do poszukiwań nowego mieszkania, do ówczesnego nie ma co już wracać, sam popiół...\n" +
                    "W AGHowskich akademikach jest sporo miejsca :D\nZapraszam na kielona, za skok w takim stylu trzeba" +
                    "wznieść toast!");
                Console.ResetColor();
            }
        }
        public static void CourageCheck(Character character)
        {
            if (character.Courage <= 0)
            {
                Console.WriteLine("Brakuje ci jaj! Zadajesz 3-krotnie mniejsze obrażenia...\n" +
                    "Twój poziom odwagi wynosi:" + character.Courage + " pktów");
                character.Strenght /= 3;
            }
            else Console.WriteLine("Twój poziom odwagi wynosi: " + character.Courage + " pktów");
        }
        public static void HealthCheck(Character character)
        {
            if (character.Health <= 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Koniec Gry... Nie żyjesz...");
                GameOver();
            }
        }
        public static void OxygenCheck(Character character)
        {
            if (character.Oxygen <= 0)
            {
                character.Health -= 10;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak zapasu tlenu!!!");
                Console.WriteLine("Masz " + character.Health + " hp");
                Console.ResetColor();
                HealthCheck(character);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Poziom tlenu: " + character.Oxygen + '\n');
                Console.ResetColor();
            }
        }
        public static void RoomCheck()
        {
            if (Room == 0)
            {
                End();
            }
        }
        public static void Start()
        {
            Console.WriteLine("Witam w grze pod tytułem \"Pożar w budynku\", w której ku zaskoczeniu\n" +
                "moim jak i zapewnie twoim, znajdziesz się w budynku dotkniętym pożarem i to nie byle jakim budynku!\n" +
                "Czeka cię 198 pomieszczeń pełnych losowości i zaskoczeń.\nW pomieszczeniach zmagac się będziesz" +
                "z płomieniami, ciemnościami oraz nieznośnymi przeciwnikami!\nJesteś skazany tylko na siebie...\n" +
                "Musisz uciec stąd jak najsprawniej, inaczej skończy ci się poziom tlenu!!!" +
                "\nPSSSST!\nPolecam grać postacią ze swoim imieniem ;)\n\n\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
