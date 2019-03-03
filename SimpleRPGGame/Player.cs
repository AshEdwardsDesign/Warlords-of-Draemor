using System;
using System.Collections.Generic;
using WarlordsOfDraemor.Items;

namespace WarlordsOfDraemor
{
    public class Player : Character
    {
        // Player-specific STATS
        private int currentXP;
        private int nextLevelXP;
        private int currentGold;
        private int skillPoints;

        // INVENTORY
        private List<Item> inventory = new List<Item>();

        // TO-DO Add item to inventory method

        // TO-DO Remove item from inventory method

        // TO-DO Use item method

        // TO-DO Equip armor method

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
            Console.WriteLine($"LEVEL UP! You are now level {level}! You have gained a skill point and +5 max HP!");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the new Character Creation Wizard!");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Before your adventure throughout Draemor begins, you will create your character.");
            Console.WriteLine("The following wizard will ask you some simple details, after which you will be shown your character sheet and your adventure can begin!");
            Console.WriteLine();
            
            Console.Write("What is your characters name: ");
            name = Console.ReadLine();
            

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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("CHARACTER SHEET");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CHARACTER BIO //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Character Name: {name}");
            Console.WriteLine($"Character hails from: {homeName}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CHARACTER STATS //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Strength: {strength}");
            Console.WriteLine($"Intelligence: {intelligence}");
            Console.WriteLine($"Dexterity: {dexterity}");
            Console.WriteLine($"Constitution: {constitution}");
            Console.WriteLine();
            Console.WriteLine($"Current Gold: {currentGold}");
            Console.WriteLine($"Current XP: {currentXP}");
            Console.WriteLine($"Next Level XP: {nextLevelXP}");
            Console.WriteLine($"Available Skill Points: {skillPoints}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CURRENT STATUS //");
            Console.ResetColor();
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
            Console.WriteLine($"{name} of {homeName}\t\tHealth: {healthPercentage.ToString("F2")}%\t\tArmor: {currentArmor}\t\tLevel: {level}\t\tXP: {currentXP} / {nextLevelXP}");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }


    }
}
