using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Fight
    {
        public static bool RunSucceded { get; set; } = false; 
        public static void NewEnemy()
        {
            RunSucceded = false;
        }
        public static void AttackBurglar(Character character, Burglar enemy)
        {
            int chance = GameRules.randomNumber(0, 100) + character.Luck;
            if (chance > 20 && chance < 80)
            {
                int damage = + 10 + character.Strenght + Inventory.SwordPossesion() + Inventory.KnifePossesion() + Inventory.BatPossesion();
                enemy.Health -= damage;
                Console.WriteLine("Zadano " + damage + " obrażeń");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przeciwnik: " + enemy.Health + " hp");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ty: " + character.Health + " hp");
                Console.ResetColor();
            }
            else if (chance >= 80)
            {
                int damage = 2* (10 + character.Strenght + Inventory.SwordPossesion() + Inventory.KnifePossesion() + Inventory.BatPossesion());
                enemy.Health -= damage;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zadano " + damage + " obrażeń krytycznych");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przeciwnik: " + enemy.Health + " hp");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ty: " + character.Health + " hp");
                Console.ResetColor();
            }
            else Console.WriteLine("Przeciwnik zablokował atak");
            if (chance < 60 && enemy.Health > 0) 
            {
                character.Health -= enemy.Damage;
                Console.WriteLine("Otrzymano " + enemy.Damage + " obrażeń");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przeciwnik: " + enemy.Health + " hp");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ty: " + character.Health + " hp");
                Console.ResetColor();
            }
            else if (enemy.Health > 0) Console.WriteLine("Uniknąłeś ataku!");
            GameRules.HealthCheck(character);
        }
        public static void BlockBurglar(Character character, Burglar enemy)
        {
            int chance = GameRules.randomNumber(0, 100) + character.Luck;
            if (chance < 40)
            {
                character.Health -= enemy.Damage;
                Console.WriteLine("Otrzymano " + enemy.Damage + " obrażeń");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przeciwnik: " + enemy.Health + " hp");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ty: " + character.Health + " hp");
                Console.ResetColor();
            }
            else
            {
                character.Health += 2*character.Regeneration;
                if (character.Health > Character.MaxHealth) character.Health = Character.MaxHealth;
                Console.WriteLine("Zablokowałeś atak!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<Wyleczono " + 2*character.Regeneration + " hp>");
                Console.ResetColor();
            }
            GameRules.HealthCheck(character);
        }
        public static void RunBurglar(Character character, Burglar enemy, Rooms nextRoom)
        {
            int chance = GameRules.randomNumber(0, 100) + character.Luck;
            if (chance < 40)
            {
                character.Health -= enemy.Damage;
                Console.WriteLine("Otrzymano " + enemy.Damage + " obrażeń");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przeciwnik: " + enemy.Health + " hp");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ty: " + character.Health + " hp");
                Console.ResetColor();
                GameRules.HealthCheck(character);
            }
            else
            {
                RunSucceded = true;
                Movement.GoDown(character, nextRoom);
                Movement.GoUp(character, nextRoom);
                Movement.GoLeft(character, nextRoom);
                Movement.GoRight(character, nextRoom);
                RunSucceded = false;
            }
        }
        public static bool IsEnemyAlive(Character character, Burglar enemy)
        {
            if (enemy is null) return false;
            else if (enemy.Health > 0) return true;
            else if (enemy.Health <= 0)
            {
                return false;
            }
            else return false;
        }
        public static bool IsFightOn(Character character, Burglar enemy)
        {
            if (IsEnemyAlive(character, enemy) == false || RunSucceded == true || character.Health <= 0) return false;
            else return true;
        }
    }
}
