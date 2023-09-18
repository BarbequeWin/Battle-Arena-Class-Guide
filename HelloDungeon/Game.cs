using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    struct Weapon
    {
        public string Name;
        public float Damage;
    }
    class Game
    {
        

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
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Character Player;
        void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
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
            string characterChoice = GetInput("Choose Your character", JoePable.GetName(), JohnCena.GetName(), LucyJill.GetName());

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

            return defender.GetHealth() - totalDamage;
        }

        float Heal(Character monster, float Heal)
        {
            float NewHealth = Heal + monster.GetHealth();

            return NewHealth;
        }

        void Fight(ref Character monster2)
        {
            Player.PrintStats();
            monster2.PrintStats();

            bool isDefending = false;
            string battleChoice = GetInput("What is your move?", "Attack", "Defend", "Run");

            if (battleChoice == "1")
            {
                monster2.TakeDamage(Player.GetDamage());
                Console.WriteLine("You used " + Player.GetWeapon().Name + "!");

                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.BoostDefense();
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You ran away from the fight.");
                currentScene = 2;
                return;
            }

            Console.WriteLine(monster2.GetName() + " punches " + Player.GetName() + "!");
            Player.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.ResetDefense();
            }
        }

        void BattleScene()
        {

            Fight(ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (Player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }

        }

        void WinResultsScene()
        {
            if (Player.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Player.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && Player.GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void EndGameScene()
        {
            string playerChoice = GetInput("You Died. Play Again?", "Yes", "No", "");

            if (playerChoice == "1")
            {
                currentScene = 0;
            }
            else if (playerChoice == "2")
            {
                gameOver = true;
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

            JoePable = new Character("Joe Pable", 2119f, 246.90f, 0.9f, deezHands);

            JohnCena = new Character("John Cena", 2120f, 246.91f, 1f, chairAdjustment);

            LucyJill = new Character("Lucy Jill Dirtbag Biden", 2118f, 246.89f, 0.8f, bidenBlast);

            Enemies = new Character[3] {JoePable, JohnCena, LucyJill};
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
            else if (currentScene == 3)
            {
                EndGameScene();
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("Thanks for playing!");
        }

        void PrintSum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
                
        void PrintLargest(int[] numbers)
        {
            int biggestNumber = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > biggestNumber)
                {
                    biggestNumber = numbers[i];
                }
            }
            Console.WriteLine(biggestNumber);
        }

        public void Run()
        {
            int[] numbers = new int[5] { 5, 10, 15, 20, 25 };
            PrintSum(numbers);

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
