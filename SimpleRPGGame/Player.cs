using System;
using System.Collections.Generic;
using WarlordsOfDraemor.Items;

namespace WarlordsOfDraemor
{
    public class Player
    {

        // GENERAL INFO
        private string firstName;
        private string lastName;
        private string fullName;
        private string homeName;

        // STATS
        private int strength;
        private int intelligence;
        private int dexterity;
        private int constitution;
        private int level;
        private int currentXP;
        private int nextLevelXP;
        private int currentGold;
        private int skillPoints;

        // HEALTH & ARMOR
        private int maxHealth;
        private int currentHealth;
        private decimal healthPercentage;
        private int currentArmor;

        // EQUIPMENT SLOTS
        private Weapon weapon;
        private Shield shield;
        private Helmet helmet;
        private ChestArmor chest;
        private Gauntlets gauntlets;
        private LegArmor legs;

        // INVENTORY
        private List<Item> inventory = new List<Item>();

        // HEALTH PERCENTAGE CALC
        public void calcHealthPercentage()
        {
            healthPercentage = ((decimal)currentHealth / (decimal)maxHealth) * 100M;
        }

        // GAIN XP
        public void GainXP(int xpGained)
        {
            currentXP += xpGained;
            Console.WriteLine($"You have gained {xpGained} XP.");
            if (currentXP >= nextLevelXP)
                LevelUp();
        }

        // LEVEL UP 
        public void LevelUp()
        {
            skillPoints++;
            double temp = nextLevelXP;
            temp *= 1.5;
            nextLevelXP = (int)temp;
            maxHealth += 5;
            Console.WriteLine($"LEVEL UP! You are now level {level}! You have gained a skill point and +10 max HP!");
        }

        // DEAL DAMAGE
        public void DealDamage(Enemy enemy)
        {
            enemy.TakeDamage(10);
        }

        // TAKE DAMAGE
        public void TakeDamage(int dmgReceived)
        {
            currentHealth -= dmgReceived;
            if (currentHealth <= 0)
                PlayerDeath();
        }

        // DEATH 
        public void PlayerDeath()
        {
            Console.WriteLine("You are dead! Press enter to return the Main Menu.");
            Console.ReadLine();
            Program.MainMenu();
        }

        // CHARACTER CREATION
        public Player()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the new Character Creation Wizard!");

            Console.WriteLine();
            Console.WriteLine("Before your adventure throughout Draemor begins, you will create your character.\nThe following wizard will ask you some simple details, after which you will be shown your character sheet and your adventure can begin!");
            Console.WriteLine();

            Console.Write("What is your characters first name: ");
            firstName = Console.ReadLine();

            Console.Write("What is your characters last name: ");
            lastName = Console.ReadLine();

            fullName = string.Format($"{firstName} {lastName}");

            Console.Write("What is the name of your characters hometown: ");
            homeName = Console.ReadLine();

            strength = 1;
            intelligence = 1;
            dexterity = 1;
            constitution = 1;
            level = 1;
            currentXP = 0;
            nextLevelXP = 100;

            maxHealth = 100;
            currentHealth = 100;
            calcHealthPercentage();
            currentArmor = 0;

            Console.WriteLine();
            Console.WriteLine("Character creation completed!");
            Console.WriteLine("Press enter to continue and view your character sheet.");
            Console.ReadLine();
            DisplayCharacterSheet();
        }

        // DISPLAY CHARACTER SHEET
        public void DisplayCharacterSheet()
        {
            Console.Clear();
            Console.WriteLine("YOUR CHARACTER SHEET");
            Console.WriteLine();
            Console.WriteLine("// CHARACTER BIO //");
            Console.WriteLine();
            Console.WriteLine($"Character Name: {fullName}");
            Console.WriteLine($"Character hails from: {homeName}");
            Console.WriteLine();
            Console.WriteLine("// CHARACTER STATS //");
            Console.WriteLine();
            Console.WriteLine($"Strength: {strength}");
            Console.WriteLine($"Intelligence: {intelligence}");
            Console.WriteLine($"Dexterity: {dexterity}");
            Console.WriteLine($"Constitution: {constitution}");
            Console.WriteLine();
            Console.WriteLine("// CURRENT STATUS //");
            Console.WriteLine();
            Console.WriteLine($"Current/Max Health: {currentHealth}/{maxHealth} ({healthPercentage.ToString("F2")}%)");
            Console.WriteLine($"Current Armor rating: {currentArmor}");

            Console.WriteLine();
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        // Display header bar
        public void DisplayHeaderBar()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"{fullName} of {homeName}\t\tHealth: {healthPercentage.ToString("F2")}%\t\tArmor: {currentArmor}\t\tLevel: {level}\t\tXP: {currentXP} / {nextLevelXP}");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }


    }
}
