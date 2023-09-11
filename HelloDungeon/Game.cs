using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
        }

        string monster1Nmae = "JoePable";
        float monster1Name = 2119f;
        float monster1Damage = 246.90f;
        float monster1Defense = 0.9f;
        float monster1Stamina = 3f;
        float monster1Heal = 25f;

        string monster2Name = "JOHN.....cena";
        float monster2Health = 2120f;
        float monster2Damage = 246.91f;
        float monster2Defense = 1f;
        float monster2Stamina = 4f;
        float monster2Heal = 25;

        string monster3Name = "Lucy Jill DirtBag Biden";
        float monster3Health = 2118f;
        float monster3Damage = 246.89f;
        float monster3Defense = 0.8f;
        float monster3Stamina = 0f;
        float monster3Heal = 25;

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }

        float Attack(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        float Heal(Monster monster, float Heal)
        {
            float NewHealth = Heal + monster.Health;
            
            return NewHealth;
        }

        void Fight(Monster monster1, Monster monster2)
        {
            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " punches " + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " punches " + monster1.Name + "!");
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }

        public void Run()
        {
            Monster JoePable;
            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defense = 0.9f;
            JoePable.Stamina = 3;

            Monster JohnCena;
            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 2120f;
            JohnCena.Damage = 246.91f;
            JohnCena.Defense = 1f;
            JohnCena.Stamina = 4f;

            Monster LucyJill;
            LucyJill.Name = "Lucy Jill DirtBag Biden";
            LucyJill.Health = 2118f;
            LucyJill.Damage = 246.89f;
            LucyJill.Defense = 0.8f;
            LucyJill.Stamina = 0f;

            Fight(JoePable, LucyJill);

            Console.Clear();

            Fight(JoePable, LucyJill);

            Console.Clear();

            Fight(JoePable, LucyJill);

            Console.Clear();
        }
    }
}
