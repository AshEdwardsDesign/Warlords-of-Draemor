using System;

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
        private int xp;
        private int nextLevelXP;

        // HEALTH & ARMOR
        private int maxHealth;
        private int currentHealth;
        private decimal healthPercentage;
        private int currentArmor;

        // HEALTH PERCENTAGE CALC
        public void calcHealthPercentage()
        {
            healthPercentage = ((decimal)currentHealth / (decimal)maxHealth) * 100M;
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
            xp = 0;
            nextLevelXP = 100;

            maxHealth = 91;
            currentHealth = 42;
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
            Console.WriteLine($"{fullName} of {homeName}\t\tHealth: {healthPercentage.ToString("F2")}%\t\tArmor: {currentArmor}\t\tLevel: 0\t\tXP: 0 / 0");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }


    }
}
