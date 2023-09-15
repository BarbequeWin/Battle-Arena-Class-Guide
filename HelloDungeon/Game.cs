using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {

        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public Weapon CurrentWeapon;
        }

        struct Weapon
        {
            public string Name;
            public float Damage;
        }

        string monster1Nmae = "JoePable";
        float monster1Name = 2119f;
        float monster1Damage = 246.90f;
        float monster1Defense = 0.9f;
        float monster1Stamina = 3f;


        string monster2Name = "JOHN.....cena";
        float monster2Health = 2120f;
        float monster2Damage = 246.91f;
        float monster2Defense = 1f;
        float monster2Stamina = 4f;


        string monster3Name = "Lucy Jill DirtBag Biden";
        float monster3Health = 2118f;
        float monster3Damage = 246.89f;
        float monster3Defense = 0.8f;
        float monster3Stamina = 0f;

        bool gameOver;
        int currentScene = 0;

        Character JoePable;
        Character JohnCena;
        Character LucyJill;

        Character Player;
        void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }

        string GetInput(string prompt, string option1, string option2, string option3)
        {
            string playerChoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> ");

            playerChoice = Console.ReadLine();

            return playerChoice;
        }

        void CharacterSelectionScene()
        {
            string characterChoice = GetInput("Choose Your character", JoePable.Name, JohnCena.Name, LucyJill.Name);

            if (characterChoice == "1")
            {
                Player = JoePable;
            }
            else if (characterChoice == "2")
            {
                Player = JohnCena;
            }
            else if (characterChoice == "3")
            {
                Player = LucyJill;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            PrintStats(Player);
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }

        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage + attacker.CurrentWeapon.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        float Heal(Character monster, float Heal)
        {
            float NewHealth = Heal + monster.Health;

            return NewHealth;
        }

        void Fight(ref Character monster2)
        {
            PrintStats(Player);
            PrintStats(monster2);

            bool isDefending = false;
            string battleChoice = GetInput("What is your move?", "Attack", "Defend", "Run");

            if (battleChoice == "1")
            {
                monster2.Health = Attack(Player, monster2);
                Console.WriteLine("You used " + Player.CurrentWeapon.Name + "!");

                if (monster2.Health <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                Player.Defense *= 5;
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You ran away from the fight.");
                currentScene = 2;
                return;
            }

            Console.WriteLine(monster2.Name + " punches " + Player.Name + "!");
            Player.Health = Attack(monster2, Player);
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.Defense /= 5;
            }
        }

        void BattleScene()
        {

            Fight(ref JohnCena);

            Console.Clear();

            if (Player.Health <= 0 || JohnCena.Health <= 0)
            {
                currentScene = 2;
            }

        }

        void WinResultsScene()
        {
            if (Player.Health > 0 && JohnCena.Health <= 0)
            {
                Console.WriteLine("The winner is: " + Player.Name);
            }
            else if (JohnCena.Health > 0 && Player.Health <= 0)
            {
                Console.WriteLine("The winner is: " + JohnCena.Name);
            }
        }

        void Start()
        {
            Weapon deezHands;
            deezHands.Name = "Deez Hands";
            deezHands.Damage = 0.5f;

            Weapon chairAdjustment;
            chairAdjustment.Name = "Chair Adjustment";
            chairAdjustment.Damage = 500.00f;

            Weapon bidenBlast;
            bidenBlast.Name = "You've done well to make it this fat, but I've only used 0.1% of my power. Now taste my Biden Blast!!!";
            bidenBlast.Damage = 9000.00f;

            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defense = 0.9f;
            JoePable.Stamina = 3;
            JoePable.CurrentWeapon = deezHands;

            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 2120f;
            JohnCena.Damage = 246.91f;
            JohnCena.Defense = 1f;
            JohnCena.Stamina = 4f;
            JoePable.CurrentWeapon = chairAdjustment;

            LucyJill.Name = "Lucy Jill DirtBag Biden";
            LucyJill.Health = 2118f;
            LucyJill.Damage = 246.89f;
            LucyJill.Defense = 0.8f;
            LucyJill.Stamina = 0f;
            JoePable.CurrentWeapon = bidenBlast;
        }

        void Update()
        {
            if (currentScene == 0)
            {
                CharacterSelectionScene();
            }
            else if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinResultsScene();
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("Thanks for playing");
        }

        void CountNumber()
        {
            int[] numbers = new int[1] { 6 };
        }
                
        

        public void Run()
        {  

            CountNumber();
            //start - called before the first loop
            Start();

            while (gameOver == false)
            {
                //update - called every time the game loops
                Update();
            }

            //end - called after the main game loop exits
            End();
        }
    }
}
