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
        Character ChuckCheese;
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Player PlayerCharacter;
        void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.GetName());
            Console.WriteLine("Health: " + monster.GetHealth());
            Console.WriteLine("Damage: " + monster.GetDamage());
            Console.WriteLine("Defense: " + monster.GetDefense());
        }

        void CharacterSelectionScene()
        {
            PlayerCharacter = new Player();
            string characterChoice = PlayerCharacter.GetInput("Choose Your character", JoePable.GetName(), JohnCena.GetName(), LucyJill.GetName(), ChuckCheese.GetName());

            if (characterChoice == "1")
            {
                PlayerCharacter = new Player(JoePable.GetName(), JoePable.GetHealth(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetWeapon());
            }
            else if (characterChoice == "2")
            {
                PlayerCharacter = new Player(JohnCena.GetName(), JohnCena.GetHealth(), JohnCena.GetDamage(), JohnCena.GetDefense(), JohnCena.GetWeapon());
            }
            else if (characterChoice == "3")
            {
                PlayerCharacter = new Player(LucyJill.GetName(), LucyJill.GetHealth(), LucyJill.GetDamage(), LucyJill.GetDefense(), LucyJill.GetWeapon());
            }
            else if (characterChoice == "4")
            {
                PlayerCharacter = new Player(ChuckCheese.GetName(), ChuckCheese.GetHealth(), ChuckCheese.GetDamage(), ChuckCheese.GetDefense(), ChuckCheese.GetWeapon());
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            PrintStats(PlayerCharacter);
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }

        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.GetDamage() + attacker.GetWeapon().Damage - defender.GetDefense();

            return defender.GetHealth() - totalDamage;
        }

        float Heal(Character monster, float Heal)
        {
            float NewHealth = Heal + monster.GetHealth();

            return NewHealth;
        }

        void Fight(ref Character monster2)
        {
            PlayerCharacter.PrintStats();
            monster2.PrintStats();

            bool isDefending = false;
            string battleChoice = PlayerCharacter.GetInput("What is your move?", "Attack", "Defend", "Run");

            if (battleChoice == "1")
            {
                monster2.TakeDamage(PlayerCharacter.GetDamage());
                Console.WriteLine("You used " + PlayerCharacter.GetWeapon().Name + "!");

                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                PlayerCharacter.BoostDefense();
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You ran away from the fight.");
                currentScene = 2;
                return;
            }

            Console.WriteLine(monster2.GetName() + " punches " + PlayerCharacter.GetName() + "!");
            PlayerCharacter.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                PlayerCharacter.ResetDefense();
            }
        }

        void BattleScene()
        {

            Fight(ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (PlayerCharacter.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }

        }

        void WinResultsScene()
        {
            if (PlayerCharacter.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + PlayerCharacter.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && PlayerCharacter.GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void EndGameScene()
        {
            string playerChoice = PlayerCharacter.GetInput("You Died. Play Again?", "Yes", "No");

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
            bidenBlast.Name = "You've done well to make it this far, but I've only used 0.1% of my power. Now taste my Biden Blast!!!";
            bidenBlast.Damage = 9000.00f;

            Weapon pizzaTasteDifferent;
            pizzaTasteDifferent.Name = "You wanna know how I got these toppings?";
            pizzaTasteDifferent.Damage = 450.00f;

            JoePable = new Character("Joe Pable", 2119f, 246.90f, 0.9f, deezHands);

            JohnCena = new Character("John Cena", 2120f, 246.91f, 1f, chairAdjustment);

            LucyJill = new Character("Lucy Jill Dirtbag Biden", 2118f, 9000f, 0.8f, bidenBlast);

            ChuckCheese = new Character("Charles Entertainment Cheese", 2139f, 239.78f, 0.7f, pizzaTasteDifferent);

            Enemies = new Character[4] {JoePable, JohnCena, LucyJill, ChuckCheese};
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
