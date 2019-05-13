﻿using System;
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
            Console.Write("What is your characters name: ");
            name = Console.ReadLine();
            Console.Write("What is the name of your characters hometown: ");
            homeName = Console.ReadLine();

            Console.WriteLine("You will now determine your characters base stats.");
            Console.ReadKey();
            CreateBaseStats();

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

        private void CreateBaseStats()
        {
            GiveSkillPoints(10);
            Console.WriteLine($"You have {skillPoints} skill points available to spend.");
            Console.WriteLine("Please allocate your skill points as you wish between the below stats:");
            Console.WriteLine();
            Console.WriteLine("Strength: Determines how much damage you do and how much you can carry.");
            Console.WriteLine("Intelligence: Determines how much XP you earn and your total mana.");
            Console.WriteLine("Agility: Determines your ability to avoid taking damage and your total stamina.");
            Console.WriteLine("Constitution: Determines how much health you have, the bonus from potions and your resistance to negative effects.");
            Console.WriteLine("Charisma: Determines the buying and selling prices at stores and your ability to convince people to see your way.");
            Console.WriteLine("Luck: Determines the likelihood of scoring a critical hit and has a chance to effect everything you do.");

            Console.Write("STRENGTH: ");
            int.TryParse(Console.ReadLine(), out int strengthChoice);

            Console.Write("INTELLIGENCE: ");
            int.TryParse(Console.ReadLine(), out int intelligenceChoice);

            Console.Write("AGILITY: ");
            int.TryParse(Console.ReadLine(), out int agilityChoice);

            Console.Write("CONSTITUTION: ");
            int.TryParse(Console.ReadLine(), out int constitutionChoice);

            Console.Write("CHARISMA: ");
            int.TryParse(Console.ReadLine(), out int charismaChoice);

            Console.Write("LUCK: ");
            int.TryParse(Console.ReadLine(), out int luckChoice);

            Console.WriteLine();
            Console.WriteLine($"Str: {strengthChoice}, agi: {agilityChoice}, luck: {luckChoice}");
            Console.ReadKey();

        }

        private void GiveSkillPoints(int points)
        {
            skillPoints += points;
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
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Character Name:", name, "Hometown:", homeName);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CHARACTER STATS //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Strength:", strength, "Current Gold:", currentGold);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Intelligence:", intelligence, "Current XP:", currentXP);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Dexterity:", agility, "Next Level XP:", nextLevelXP);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Constitution:", constitution, "Available SP:", skillPoints);
            Console.WriteLine("{0, -20}{1, -20}", "Charisma:", charisma);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// CURRENT STATUS //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Current Health:", currentHealth, "Max Health:", maxHealth);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("// EQUIPMENT //");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Helmet:", GetItemPresence(helmet), "Weapon:", GetItemPresence(weapon));
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Chest:", GetItemPresence(chest), "Shield:", GetItemPresence(shield));
            Console.WriteLine("{0, -20}{1, -20}", "Gauntlets:", GetItemPresence(gauntlets));
            Console.WriteLine("{0, -20}{1, -20}", "Boots:", GetItemPresence(legs));
            Console.WriteLine("{0, -20}{1, -20}", "TOTAL DEFENCE:", getTotalArmorRating());
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
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
                Console.ResetColor();
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

            if (inventory.Where(i => i.GetType() == typeof(Weapon)).ToList().Count != 0)
            {
                var weapons = inventory.Where(i => i.GetType() == typeof(Weapon)).ToList();

                foreach (Weapon item in weapons)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", "Item", "Name", "Damage", "Value", "Weight");
                    Console.ResetColor();
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", count, item.getName(), item.GetDamage(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any weapons in your inventory.");
                Console.ResetColor();
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

            // Populate the list
            int count = 1;

            if (inventory.Where(i => i.GetType() == typeof(Armor)).ToList().Count != 0)
            {
                var armors = inventory.Where(i => i.GetType() == typeof(Armor)).ToList();

                foreach (Armor item in armors)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", "Item", "Name", "Defence", "Value", "Weight");
                    Console.ResetColor();
                    Console.WriteLine("{0, -10}{1,-20}{2, -10}{3, -10}{4, -10}", count, item.getName(), item.GetArmorRating(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any armor in your inventory.");
                Console.ResetColor();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
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

            // Populate the list
            int count = 1;

            if (inventory.Where(i => i.GetType() == typeof(Book)).ToList().Count != 0)
            {
                var books = inventory.Where(i => i.GetType() == typeof(Book)).ToList();

                foreach (Book item in books)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{3, -10}{4, -10}", "Item", "Name", "Value", "Weight");
                    Console.ResetColor();
                    Console.WriteLine("{0, -10}{1,-20}{3, -10}{4, -10}", count, item.getName(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any books in your inventory.");
                Console.ResetColor();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
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

            // Populate the list
            int count = 1;

            if (inventory.Where(i => i.GetType() == typeof(Potion)).ToList().Count != 0)
            {
                var potions = inventory.Where(i => i.GetType() == typeof(Potion)).ToList();

                foreach (Potion item in potions)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0, -10}{1,-20}{3, -10}{4, -10}", "Item", "Name", "Value", "Weight");
                    Console.ResetColor();
                    Console.WriteLine("{0, -10}{1,-20}{3, -10}{4, -10}", count, item.getName(), item.getValue(), item.getWeight());
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any potions in your inventory.");
                Console.ResetColor();
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public string GetItemPresence(Item item)
        {
            if (item == null)
            {
                return "Not Equipped";
            }
            else
            {
                return item.getName();
            }
        }
    }
}
