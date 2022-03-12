using System;
using System.Collections.Generic;
using System.Text;

namespace FireInASkyscraper
{
    class Burglar
    {
        public Burglar(int damage, int health)
        {
            Health = health;
            Damage = damage;
        }
        public int Health { get; set; } = 100;
        public int Damage { get; set; } = 15;
    }
}
