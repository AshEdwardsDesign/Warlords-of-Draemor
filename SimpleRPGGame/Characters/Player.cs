using System;
using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public class Player : Character
    {
        // Player-specific STATS
        private int currentXP;
        private int nextLevelXP;
        private int currentGold;
        private int skillPoints;
        private int charisma;

        // LOCATIONS
        private Location currentLocation;

        /// <summary>
        /// Set's the players current location and display the locations menu.
        /// </summary>
        /// <param name="loc">The location the player is travelling to.</param>
        public void SetLocation(Location loc)
        {
            currentLocation = loc;
            loc.ShowLocationMenu(this);
        }

        /// <summary>
        /// Returns the players current location.
        /// </summary>
        /// <returns></returns>
        public Location GetLocation()
        {
            return currentLocation;
        }

        // INVENTORY
        private List<Item> inventory = new List<Item>();

        // TO-DO Add item to inventory method
        public void GiveItem(Item item)
        {
            inventory.Add(item);
        }

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
            {
                LevelUp();
            }
        }

        /// <summary>
        /// Give n amount of gold to the player's purse.
        /// </summary>
        public void GainGold(int amount)
        {
            currentGold += amount;
            Console.WriteLine($"You have gained {amount} gold. Your purse now contains {currentGold}.");
        }

        /// <summary>
        /// Deducts n amount of gold from the player's purse.
        /// </summary>
        public void SpendGold(int amount)
        {
            currentGold -= amount;
            Console.WriteLine($"You have spent {amount} gold. Your purse now contains {currentGold}.");
        }

        /// <summary>
        /// Returns the players current gold amount.
        /// </summary>
        public int GetGoldAmount()
        {
            return currentGold;
        }

        /// <summary>
        /// Returns the player's current amount of XP.
        /// </summary>
        /// <returns></returns>
        public int GetXPAmount()
        {
            return currentXP;
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
            Console.ReadLine();

            Console.Clear();
            Console.Write("What is your characters name: ");
            name = Console.ReadLine();

            Console.Clear();
            Console.Write("What is the name of your characters hometown: ");
            homeName = Console.ReadLine();

            Console.Clear();
            Console.Write("Which character class would you like to be? Knight, Mage, Thief or Warlock:\n " +
                "\n" +
                "Class\t\tStrength\tInteligence\tDexterity\tConstitution\tCharisma\n" +
                "Knight\t\t3\t\t1\t\t1\t\t2\t\t1\n" +
                "Mage\t\t1\t\t3\t\t2\t\t1\t\t1\n" +
                "Thief\t\t1\t\t2\t\t3\t\t1\t\t1\n" +
                "Warlock\t\t2\t\t2\t\t2\t\t2\t\t1\n\n" +
                "Your choice (or type random): ");

            string classChoice = Console.ReadLine().ToLower();

            switch (classChoice)
            {
                case "knight":
                    strength = 3;
                    intelligence = 1;
                    dexterity = 1;
                    constitution = 2;
                    charisma = 1;
                    characterClass = CharacterClass.Knight;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You have chosen Knight!");
                    Console.ResetColor();
                    break;
                case "mage":
                    strength = 1;
                    intelligence = 3;
                    dexterity = 2;
                    constitution = 1;
                    charisma = 1;
                    characterClass = CharacterClass.Mage;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You have chosen Mage!");
                    Console.ResetColor();
                    break;
                case "thief":
                    strength = 1;
                    intelligence = 2;
                    dexterity = 3;
                    constitution = 1;
                    charisma = 1;
                    characterClass = CharacterClass.Thief;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You have chosen Thief!");
                    Console.ResetColor();
                    break;
                case "warlock":
                    strength = 2;
                    intelligence = 2;
                    dexterity = 2;
                    constitution = 2;
                    charisma = 1;
                    characterClass = CharacterClass.Warlock;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You have chosen Warlock!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I don't recognise that class, please try again.");
                    Console.ResetColor();
                    break;
            }

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
            Console.WriteLine($"Character Class: {characterClass}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CHARACTER STATS //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Strength: {strength}");
            Console.WriteLine($"Intelligence: {intelligence}");
            Console.WriteLine($"Dexterity: {dexterity}");
            Console.WriteLine($"Constitution: {constitution}");
            Console.WriteLine($"Charisma: {charisma}");
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

        /// <summary>
        /// Get the name of the player.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Display the playter menu, which allows access to the character sheet, inventory and more.
        /// </summary>
        public void DisplayPlayerMenu()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("CHARACTER MENU");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();

            // List the choices available
            Console.WriteLine("1. View Inventory");
            Console.WriteLine("2. View Character Sheet");
            Console.WriteLine("3. Cancel");

            // Get the players choice
            Console.WriteLine();
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "inventory" || choice == "1")
            {
                DisplayInventory();
                DisplayPlayerMenu();
            }
            else if (choice == "character" || choice == "2")
            {
                DisplayCharacterSheet();
                DisplayPlayerMenu();
            }
            else if (choice == "cancel" || choice == "exit")
            {
                currentLocation.ShowLocationMenu(this);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, I dont' recognise that option.");
                Console.ResetColor();
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                DisplayPlayerMenu();
            }


        }

        public void DisplayInventory()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();

            // Menu options
            Console.WriteLine("1. Display All");
            Console.WriteLine("2. Weapons");
            Console.WriteLine("3. Armors");
            Console.WriteLine("4. Potions");
            Console.WriteLine("5. Books");
            Console.WriteLine("6. Cancel");
            Console.WriteLine();

            // Get the players choice
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "1" || choice == "all")
            {
                DisplayAll();
            }
            else if (choice == "2" || choice == "weapons")
            {
                DisplayWeapons();
            }
            else if (choice == "3" || choice == "armors")
            {
                DisplayArmors();
            }
            else if (choice == "4" || choice == "potions")
            {
                DisplayPotions();
            }
            else if (choice == "5" || choice == "books")
            {
                DisplayBooks();
            }
            else if (choice == "6" || choice == "cancel")
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, I don't recognise that option");
                Console.ResetColor();
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayAll()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY > All items");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();

            // Populate the list
            int count = 1;

            if (inventory.Count != 0)
            {
                foreach (Item item in inventory)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", "Item", "Name", "Type", "Value", "Weight");
                    Console.ResetColor();
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", count, item.getName(), item.GetItemType(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You don't have anything in your inventory.");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }

        }

        public void DisplayWeapons()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY > Weapons");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();


            // Populate the list
            int count = 1;

            if (inventory.Count != 0)
            {
                var weapons = inventory.Where(i => i.GetType() == typeof(Weapon)).ToList();

                foreach (Weapon item in weapons)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", "Item", "Name", "Damage", "Value", "Weight");
                    Console.ResetColor();
                    //Console.WriteLine($"{count}.\t{item.getName()}\t\t{item.GetItemType()}\t\t{item.getValue()}\t\t{item.getWeight()}");
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", count, item.getName(), item.GetDamage(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You don't have any weapons in your inventory.");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayArmors()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY > Armor");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplayBooks()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY > Books");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplayPotions()
        {
            // Clear the screen and display the header bar
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("##########");
            Console.WriteLine("INVENTORY > Potions");
            Console.WriteLine("##########");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
