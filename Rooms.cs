using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Rooms
    {
        public Rooms(int roomNumber)
        {
            if (roomNumber == 198)
            {
                Fire = false;
                Lock = false;
                Window = false;
                Knife = false;
                Bat = false;
                Extinguisher = false;
                Light = true;
                Enemy = false;
                Key = false;
                Meds = false;
                FlashLight = true;
            }
            else if (roomNumber == 197)
            {
                Fire = false;
                Lock = false;
                Window = false;
                Knife = false;
                Bat = false;
                Extinguisher = true;
                Light = true;
                Enemy = false;
                Key = true;
                Meds = false;
                FlashLight = false;
            }
            else if (roomNumber == 196)
            {
                Fire = false;
                Lock = false;
                Window = false;
                Knife = false;
                Bat = false;
                Extinguisher = true;
                Light = false;
                Enemy = true;
                Burglar = EnemyGenerator(roomNumber);
                Key = false;
                Meds = true;
                FlashLight = true;
            }
            else if (roomNumber == 0)
            {
                Fire = false;
                Lock = false;
                Window = false;
                Knife = false;
                Bat = false;
                Extinguisher = false;
                Light = true;
                Enemy = false;
                Key = false;
                Meds = false;
                FlashLight = false;
            }
            else RoomRandomizer(roomNumber);

        }
        public Burglar Burglar { get; set; }
        public bool Fire { get; set; }
        public bool Lock { get; set; }
        public bool Window { get; set; }
        public bool Knife { get; set; }
        public bool Bat { get; set; }
        public bool Sword { get; set; }
        public bool Revolver { get; set; }
        public bool Extinguisher { get; set; }
        public bool Light { get; set; }
        public bool Enemy { get; set; }
        public bool Key { get; set; }
        public bool Parachute { get; set; }
        public bool Completed { get; set; } = false;
        public bool Completed2 { get; set; } = false;
        public bool Meds { get; set; }
        public bool FlashLight { get; set; }
        public int Exp { get; set; }
        public void CasualRoom(Character character)
        {
            Console.WriteLine("Jesteś w pokoju startowym nr");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("198");
            Console.ResetColor();
            RoomLoop(character, 198);
        }
        public void RoomWithKey(Character character)
        {
            Fire = false;
            Lock = false;
            Window = false;
            Knife = false;
            Bat = false;
            Extinguisher = false;
            Light = false;
            Enemy = false;
            Key = true;
            FlashLight = true;
            Inventory.Darkness(character);
        }
        public void RoomWithEnemy(Character character)
        {
            Fire = false;
            Lock = false;
            Window = false;
            Knife = false;
            Bat = false;
            Extinguisher = false;
            Light = false;
            Enemy = false;
            Key = true;
            FlashLight = true;
            Inventory.Darkness(character);
        }
        public void RoomWithExtinguisher(Character character)
        {
            Fire = false;
            Lock = false;
            Window = false;
            Knife = false;
            Bat = false;
            Extinguisher = true;
            Light = false;
            Enemy = false;
            Key = false;
            Inventory.Darkness(character);
        }
        public Burglar EnemyGenerator(int roomNumber)
        {
            int chance = GameRules.randomNumber(0, 100);
            if (chance > 20)
            {
                if (roomNumber > 100)
                {
                    Burglar burglar = new Burglar(10, 100);
                    return burglar;
                }
                else if (roomNumber > 50 && roomNumber <= 100)
                {
                    Burglar burglar = new Burglar(20, 200);
                    return burglar;
                }
                else
                {
                    Burglar burglar = new Burglar(40, 500);
                    return burglar;
                }
            }
            else if (chance <= 20 && chance > 5)
            {
                if (roomNumber > 100)
                {
                    Burglar burglar = new Burglar(10, 140);
                    return burglar;
                }
                else if (roomNumber > 50 && roomNumber <= 100)
                {
                    Burglar burglar = new Burglar(25, 300);
                    return burglar;
                }
                else
                {
                    Burglar burglar = new Burglar(60, 600);
                    return burglar;
                }
            }
            else
            {
                if (roomNumber > 100)
                {
                    Burglar burglar = new Burglar(15, 150);
                    return burglar;
                }
                else if (roomNumber > 50 && roomNumber <= 100)
                {
                    Burglar burglar = new Burglar(40, 350);
                    return burglar;
                }
                else
                {
                    Burglar burglar = new Burglar(80, 700);
                    return burglar;
                }
            }
        }
        public void RoomRandomizer(int roomNumber)
        {
            for (int random = 0; random < 14; random++)
            {
                switch (random)
                {
                    case 0:
                        if (roomNumber > 100)
                        {
                            if (GameRules.randomNumber(0, 100) < 30) Fire = true;
                            else Fire = false;
                        }
                        else
                        {
                            if (GameRules.randomNumber(0, 100) < 40) Fire = true;
                            else Fire = false;
                        }
                        break;
                    case 1:
                        if (GameRules.randomNumber(0, 100) < 10) Lock = true;
                        else Lock = false;
                        break;
                    case 2:
                        if (GameRules.randomNumber(0, 100) < 20) Window = true;
                        else Window = false;
                        break;
                    case 3:
                        if (roomNumber < 150)
                        {
                            if (GameRules.randomNumber(0, 100) < 30) Knife = true;
                            else Knife = false;
                            break;
                        }
                        else
                        {
                            if (GameRules.randomNumber(0, 100) < 5) Knife = true;
                            else Knife = false;
                            break;
                        }
                    case 4:
                        if (GameRules.randomNumber(0, 100) < 15) Bat = true;
                        else Bat = false;
                        break;
                    case 5:
                        if (GameRules.randomNumber(0, 100) < 35) Extinguisher = true;
                        else Extinguisher = false;
                        break;
                    case 6:
                        if (GameRules.randomNumber(0, 100) < 90) Light = false;
                        else Light = true;
                        break;
                    case 7:
                        if (GameRules.randomNumber(0, 100) < 35)
                        {
                            Enemy = true;
                            Burglar = EnemyGenerator(roomNumber);
                        }
                        else Enemy = false;
                        break;
                    case 8:
                        if (GameRules.randomNumber(0, 100) < 20) Key = true;
                        else Key = false;
                        break;
                    case 9:
                        if (GameRules.randomNumber(0, 100) < 5) Parachute = true;
                        else Parachute = false;
                        break;
                    case 10:
                        if (GameRules.randomNumber(0, 100) < 30) Meds = true;
                        else Meds = false;
                        break;
                    case 11:
                        if (GameRules.randomNumber(0, 100) < 70) FlashLight = true;
                        else FlashLight = false;
                        break;
                    case 12:
                        if (roomNumber < 100)
                        {
                            if (GameRules.randomNumber(0, 100) < 15) Sword = true;
                            else Sword = false;
                        }
                        else
                        {
                            if (GameRules.randomNumber(0, 100) < 2) Sword = true;
                            else Sword = false;
                        }
                        break;
                    case 13:
                        if (roomNumber < 50)
                        {
                            if (GameRules.randomNumber(0, 1000) < 125) Revolver = true;
                            else Revolver = false;
                        }
                        else 
                        {
                            if (GameRules.randomNumber(0, 1000) < 2) Revolver = true;
                            else Revolver = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void DefeatingAnEnemy(Character character)
        {
            if (Burglar is null) Console.WriteLine('\n');
            else if (Burglar.Health <= 0 && Enemy == true)
            {
                Console.WriteLine("Pokonałeś napastnika");
                Level.ExperienceUp(Exp, character);
                Enemy = false;
            }
            else Console.WriteLine(" ");
        }
        public void FightInRoom(Character character, int roomNumber)
        {
            Console.WriteLine("Jestes w pokoju nr");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(roomNumber);
            Console.ResetColor();
            if (Lock == true)
            {
                bool enable = Inventory.UseKey(character);
                if (enable == true)
                {
                    Fight.NewEnemy();
                    if (Burglar.Health == 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("BUUU!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Chłop macha tym scyzorykiem jak opętany!");
                        Console.ResetColor();
                        Exp = 400;
                    }
                    else if (Burglar.Health == 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("<Słychać jakby ktoś klepał w klawiaturę jak opętany>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Czekaj, czekaj, czy to PAN FRANKOWSKI! Pod pachą dzierży wielką klawiaturę mechaniczną!\n" +
                            "Ja bym na niego uważał, po tylu sesjach z Among Us, może mieć jakieś podstępne sztuczki w zanadrzu...");
                        Console.ResetColor();
                        if (character.Name == "Krzysiu" || character.Name == "Krzysztof" || character.Name == "krzysztof" || character.Name == "krzysiu")
                        {
                            Console.WriteLine("Na szczęście jestes Panem Grochotem, Markowski gniew Ci nie groźny");
                            Burglar.Health = 0;
                            Level.ExperienceUp(3000, character);
                        }
                        else Exp = 500;
                    }
                    else if (Burglar.Health == 140)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("BUUU!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Chłop macha tym nożykiem jak opętany!");
                        Console.ResetColor();
                        Exp = 1000;
                    }
                    else if (Burglar.Health == 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("WRRRR!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga\n" +
                            "Ten wściekły pies może być problemem, uważaj bo słyszałem, że potrafią zjeść w całości!");
                        Console.ResetColor();
                        Exp = 700;
                    }
                    else if (Burglar.Health == 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("WRRRR!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga w obroży pełnej kolcy\n" +
                            "Chyba jest po jakiejś tresurze, uważaj bo słyszałem, że potrafią skakać do szyji!!");
                        Console.ResetColor();
                        Exp = 1500;
                    }
                    else if (Burglar.Health == 350)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("WRRRR!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga w pełnej zbroji!\n" +
                            "Ja bym brał nogi za pas! Jak on skoczy ci do szyji to biada tobie panie!!");
                        Console.ResetColor();
                        Exp = 3000;
                    }
                    else if (Burglar.Health == 500)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("AAAAA!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Rycerza!\nCzekaj rycerza!? Biedak w tej zbroji sie ugotuje w tym" +
                            " budynku!\n Ale nie o to bym się martwił, gościu ma wielki miecz!\n" +
                            "Ja bym sie chyba odwrócił na pięcie, na pewno nie ma co szukać w tym pokoju...");
                        Console.ResetColor();
                        Exp = 1500;
                    }
                    else if (Burglar.Health == 600)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("AAAAA!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Wiedźmina!\nCzekaj wiedźmina!!? Jakiś spod znaku niedźwiedzia to chyba twardy koleś\n" +
                            "Ale czekaj, on ma tylko jeden miecz, to jeszcze nie ma tragedii!\n" +
                            "Ja bym na pewno dał mu radę, ale siedzę za monitorem to niestety innym razem, ale powodzenia!");
                        Console.ResetColor();
                        Exp = 2500;
                    }
                    else if (Burglar.Health == 700)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("AAAAA!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Wiedźmina!\nCzekaj wiedźmina!!? Czekaj, czekaj, TO GERALT O RANY!!!\n" +
                            "Bierz nogi w troki i lepiej zmiataj stąd, ON MA 2 MIECZE! I KUSZE!\n" +
                            "Ja bym na pewno dał mu radę, ale siedzę za monitorem to niestety innym razem, ale powodzenia!");
                        Console.ResetColor();
                        Exp = 20000;
                    }
                }
                else
                {
                    Completed = false;
                }
            }
            else
            {
                if (Enemy == true)
                {
                    Fight.NewEnemy();
                    if (Burglar.Health == 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("W środku czai się przeciwnik...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Chłop macha tym scyzorykiem jak opętany!");
                        Console.ResetColor();
                        Exp = 400;
                    }
                    else if (Burglar.Health == 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("W środku czai się przeciwnik...");
                        Console.WriteLine("<Słychać jakby ktoś klepał w klawiaturę jak opętany>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Czekaj, czekaj, czy to PAN FRANKOWSKI! Pod pachą dzierży wielką klawiaturę mechaniczną!\n" +
                            "Ja bym na niego uważał, po tylu sesjach z Among Us, może mieć jakieś podstępne sztuczki w zanadrzu...");
                        Console.ResetColor();
                        if (character.Name == "Krzysiu" || character.Name == "Krzysztof" || character.Name == "krzysztof" || character.Name == "krzysiu")
                        {
                            Console.WriteLine("Na szczęście jestes Panem Grochotem, Markowski gniew Ci nie groźny");
                            Burglar.Health = 0;
                            Level.ExperienceUp(3000, character);
                        }
                        else Exp = 500;
                    }
                    else if (Burglar.Health == 140)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Uważaj, w środku ktoś jest!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez drobnego ziezimieszka\n" +
                            "Chłop macha tym nożykiem jak opętany!");
                        Console.ResetColor();
                        Exp = 1000;
                    }
                    else if (Burglar.Health == 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Jakaś kulka czai sie za drzwiami...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga\n" +
                            "Ten wściekły pies może być problemem, uważaj bo słyszałem, że potrafią zjeść w całości!");
                        Console.ResetColor();
                        Exp = 700;
                    }
                    else if (Burglar.Health == 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Jakaś niewinna istota jest w środku...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga w obroży pełnej kolcy\n" +
                            "Chyba jest po jakiejś tresurze, uważaj bo słyszałem, że potrafią skakać do szyji!!");
                        Console.ResetColor();
                        Exp = 1500;
                    }
                    else if (Burglar.Health == 350)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Ojoj co to się tam chowa...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Buldoga w pełnej zbroji!\n" +
                            "Ja bym brał nogi za pas! Jak on skoczy ci do szyji to biada tobie panie!!");
                        Console.ResetColor();
                        Exp = 3000;
                    }
                    else if (Burglar.Health == 500)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Jakiś wielkolud jest w środku!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Rycerza!\nCzekaj rycerza!? Biedak w tej zbroji sie ugotuje w tym" +
                            " budynku!\n Ale nie o to bym się martwił, gościu ma wielki miecz!\n" +
                            "Ja bym sie chyba odwrócił na pięcie, na pewno nie ma co szukać w tym pokoju...");
                        Console.ResetColor();
                        Exp = 1500;
                    }
                    else if (Burglar.Health == 600)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Co to za bestia kryje się za futryną!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Wiedźmina!\nCzekaj wiedźmina!!? Jakiś spod znaku niedźwiedzia to chyba twardy koleś\n" +
                            "Ale czekaj, on ma tylko jeden miecz, to jeszcze nie ma tragedii!\n" +
                            "Ja bym na pewno dał mu radę, ale siedzę za monitorem to niestety innym razem, ale powodzenia!");
                        Console.ResetColor();
                        Exp = 2500;
                    }
                    else if (Burglar.Health == 700)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Czy to naprawdę on!?");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zostałeś zaatakowany przez Wiedźmina!\nCzekaj wiedźmina!!? Czekaj, czekaj, TO GERALT O RANY!!!\n" +
                            "Bierz nogi w troki i lepiej zmiataj stąd, ON MA 2 MIECZE! I KUSZE!\n" +
                            "Ja bym na pewno dał mu radę, ale siedzę za monitorem to niestety innym razem, ale powodzenia!");
                        Console.ResetColor();
                        Exp = 20000;
                    }
                }
            }
        }
        public void RoomGenerator(Character character, int roomNumber)
        {
            Console.WriteLine("Jestes w pokoju nr");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(roomNumber);
            Console.ResetColor();
            if (Lock == true)
            {
                bool enable = Inventory.UseKey(character);
                if (enable == true)
                {
                    Lock = false;
                    RoomLoop(character, roomNumber);
                }
                else
                {
                    Completed = false;
                }
            }
            else
            {
                RoomLoop(character, roomNumber);
            }
        }
        public void RoomLoop(Character character, int roomNumber)
        {
            for (int random = 0; random < 11; random++)
            {
                switch (random)
                {
                    case 0:
                        if (Fire == true)
                        {
                            Fire = Inventory.Flame(character);
                        }
                        break;
                    case 1:
                        if (Light == false)
                        {
                            Light = Inventory.Darkness(character);
                        }
                        break;
                    case 2:
                        if (Knife == true)
                        {
                            Inventory.PickUpKnife(character);
                            Knife = false;
                        }
                        break;
                    case 3:
                        if (Bat == true)
                        {
                            Inventory.PickUpBat(character);
                            Bat = false;
                        }
                        break;
                    case 4:
                        if (Extinguisher == true)
                        {
                            Inventory.PickUpExtinguisher();
                            Extinguisher = false;
                        }
                        break;
                    case 5:
                        if (FlashLight == true)
                        {
                            Inventory.PickUpFlashLight();
                            FlashLight = false;
                        }
                        break;
                    case 6:
                        if (Key == true)
                        {
                            Inventory.PickUpKey();
                            Key = false;
                        }
                        break;
                    case 7:
                        if (Sword == true)
                        {
                            Inventory.PickUpSword(character);
                            Sword = false;
                        }
                        break;
                    case 8:
                        if (Revolver == true)
                        {
                            Inventory.PickUpRevolver(character);
                            Revolver = false;
                        }
                        break;
                    case 9:
                        if (Meds == true)
                        {
                            Inventory.PickingUpHealing();
                            Meds = false;
                        }
                        break;
                    case 10:
                        Completed = true;
                        break;
                }
            }
            if (Completed == true)
            {
                RoomCompletion(character, roomNumber);
            }
        }
        public void RoomCompletion(Character character, int roomNumber)
        {
            Console.WriteLine("\nJuż nic tu nie ma...\n");
            if (roomNumber % 3 == 0 && Window == false)
            {
                Console.WriteLine("Możesz iść w prawo...\nWciśnij 1");
            }
            else if (roomNumber % 3 == 0 && Window == true)
            {
                Console.WriteLine("W pokoju znajduje się piękne, troche przydymione okno...");
                Console.WriteLine("Możesz iść w prawo...(Wciśnij 1)\nLub skoczyć... (Wciśnij j)");
            }
            else if (roomNumber % 3 == 1 && Window == false)
            {
                Console.WriteLine("Możesz iść w lewo...\nWciśnij 3");
            }
            else if (roomNumber % 3 == 1 && Window == true)
            {
                Console.WriteLine("W pokoju znajduje się piękne, troche przydymione okno...");
                Console.WriteLine("Możesz iść w lewo...(Wciśnij 3)\nLub skoczyć... (Wciśnij j)");
            }
            else if (roomNumber % 3 == 2 && roomNumber == 197)
            {
                Console.WriteLine("Idź w prawo (Wciśnij 1)\nIdź w dół (Wciśnij 2)\n" +
                    "Idź w lewo (Wciśnij 3)");
            }
            else if (roomNumber % 3 == 2 && roomNumber < 195)
            {
                Console.WriteLine("Idź w prawo (Wciśnij 1)\nIdź w dół (Wciśnij 2)\n" +
                    "Idź w lewo (Wciśnij 3)" + "\nIdź w górę (Wciśnij 4)");
            }
            else Console.WriteLine(" ");
            Console.WriteLine("\nWiecej opcji (Wciśnij p)\n");
            if (character.Health < Character.MaxHealth)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nMożesz się teraz wyleczyć...\n" +
                "Użyj potki (Wciśnij z)\nUżyj bandaży (Wciśnij x)\nUżyj apteczki (Wciśnij c)");
                Console.ResetColor();
            }
        }
        public static void Options()
        {
            Console.WriteLine("Zapisz (Wciśnij t)\nWczytaj (Wciśnij r)\nPokaż eq (Wciśnij e)\n" +
                "Pokaż statystyki (Wciśnij w)\nPokaż mapę (Wciśnij m)\nWróć (Wciśnij b)\nWyjdź z gry (Wciśnij q)");
        }
    }
}
