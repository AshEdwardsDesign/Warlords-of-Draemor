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

        // LOCATIONS
        private Location currentLocation;
        private List<Location> discoveredLocations = new List<Location>();

        /// <summary>
        /// Set's the players current location and displays the location's menu.
        /// </summary>
        /// <param name="loc">The location the player is travelling to.</param>
        public void SetLocation(Location loc)
        {
            currentLocation = loc;
            loc.ShowLocationMenu(this);
        }

        internal int GetBaseStrength()
        {
            return strength.GetBaseValue();
        }

        internal int GetBaseIntelligence()
        {
            return intelligence.GetBaseValue();
        }

        internal int GetBaseAgility()
        {
            return agility.GetBaseValue();
        }

        internal int GetBaseConstitution()
        {
            return constitution.GetBaseValue();
        }

        internal int GetBaseLuck()
        {
            return luck.GetBaseValue();
        }

        internal int GetMaxHealth()
        {
            return maxHealth;
        }

        internal int GetBaseCharisma()
        {
            return charisma.GetBaseValue();
        }

        /// <summary>
        /// Returns the players current location.
        /// </summary>
        /// <returns></returns>
        public Location GetLocation()
        {
            return currentLocation;
        }

        /// <summary>
        /// Add the location to the players list of discovered locations (if undiscovered).
        /// </summary>
        /// <param name="location"></param>
        public void addDiscoveredLocation(Location location)
        {
            if (discoveredLocations.Contains(location))
            {
                UI.DisplayNoticeText("You have already discovered this location.");
            } else
            {
                discoveredLocations.Add(location);
                UI.DisplayNoticeText($"You have discovered a new location: {location.GetName()}");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Get the list of locations discovered by the player.
        /// </summary>
        /// <returns></returns>
        public List<Location> getDiscoveredLocations()
        {
            return discoveredLocations;
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
            UI.DisplaySuccessText($"You have gained {xpGained} XP.");
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
            UI.DisplayNoticeText($"You have gained {amount} gold. Your purse now contains {currentGold}.");
        }

        /// <summary>
        /// Deducts n amount of gold from the player's purse.
        /// </summary>
        public void SpendGold(int amount)
        {
            currentGold -= amount;
            UI.DisplayNoticeText($"You have spent {amount} gold. Your purse now contains {currentGold}.");
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
            UI.DisplaySuccessText($"LEVEL UP! You are now level {level}! You have gained a skill point and +5 max HP!");
        }

        // DEATH 
        public void PlayerDeath()
        {
            UI.DisplayWarningText("You are dead! Press enter to return the Main Menu.");
            Console.ReadLine();
            Program.MainMenu();
        }

        // CHARACTER CREATION
        public Player()
        {
            StartCharacterCreation();
        }

        public void StartCharacterCreation()
        {
            UI.DisplayTitle("CHARACTER CREATION WIZARD", true);

            Console.WriteLine("Before your adventure throughout Draemor begins, you will create your character.");

            Console.WriteLine();

            Console.WriteLine("The following wizard will ask you some simple details, after which you will be shown your character sheet and your adventure can begin!");

            Console.WriteLine();

            UI.DisplayInputText("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();

            UI.DisplayInputText("What is your characters name:\t\t\t", true);
            name = Console.ReadLine();

            UI.DisplayInputText("What is the name of your characters hometown:\t", true);
            homeName = Console.ReadLine();

            CreateBaseStats();

            level = 1;
            currentXP = 0;
            nextLevelXP = 100;

            maxHealth = 100;
            currentHealth = 100;
            calcHealthPercentage();
            currentArmor = 0;

            Console.WriteLine();
            UI.DisplaySuccessText("Character creation completed!");
            Console.WriteLine();
            UI.DisplayInputText("Press any key to continue and view your character sheet.");
            Console.ReadKey();

            DisplayCharacterSheet();
            FinaliseCharacterCreation();
        }

        public void FinaliseCharacterCreation()
        {
            UI.DisplayTitle("FINISH CHARACTER CREATION?");
            UI.DisplayInputText("Finish character creation and start your adventure [Y/N]? ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "n") StartCharacterCreation();
        }

        private void CreateBaseStats()
        {
            int newCharSP = 20;
            
            UI.DisplayTitle("CHARACTER CREATION WIZARD", true);

            Console.WriteLine("You will now determine your characters base stats.");
            Console.WriteLine();
            UI.DisplayNoticeText($"You have {newCharSP} skill points available to spend. You must spend all points to complete character creation.");
            Console.WriteLine();
            UI.DisplayInputText("Press any key to continue.");
            Console.ReadKey();

            UI.DisplayTitle("CHARACTER CREATION WIZARD", true);
            UI.DisplaySubTitle("AVAILABLE CHARACTER STATS");

            Console.WriteLine("Stats and their affects are as follows;");
            Console.WriteLine();
            Console.WriteLine("Strength:\tDetermines how much damage you do and how much you can carry.");
            Console.WriteLine("Intelligence:\tDetermines how much XP you earn and your total mana.");
            Console.WriteLine("Agility:\tDetermines your ability to avoid taking damage and your total stamina.");
            Console.WriteLine("Constitution:\tDetermines how much health you have, the bonus from potions and your resistance to negative effects.");
            Console.WriteLine("Charisma:\tDetermines the buying and selling prices at stores and your ability to convince people to see your way.");
            Console.WriteLine("Luck:\t\tDetermines the likelihood of scoring a critical hit and has a chance to effect everything you do.");
            Console.WriteLine();
            UI.DisplayInputText("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();

            UI.DisplaySubTitle("STAT POINT ALLOCATION");
            Console.WriteLine();
            Console.WriteLine("You will be shown each stat in turn. Please enter the number of skill points you would like to allocate to each skill as a whole number (i.e 4);");
            Console.WriteLine();

            int pointsRemaining = newCharSP;

            UI.DisplayInputText("STRENGTH:\t", true);
            int.TryParse(Console.ReadLine(), out int strengthChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= strengthChoice} points remaining.");
            Console.WriteLine();

            UI.DisplayInputText("INTELLIGENCE:\t", true);
            int.TryParse(Console.ReadLine(), out int intelligenceChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= intelligenceChoice} points remaining.");
            Console.WriteLine();

            UI.DisplayInputText("AGILITY:\t", true);
            int.TryParse(Console.ReadLine(), out int agilityChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= agilityChoice} points remaining.");
            Console.WriteLine();

            UI.DisplayInputText("CONSTITUTION:\t", true);
            int.TryParse(Console.ReadLine(), out int constitutionChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= constitutionChoice} points remaining.");
            Console.WriteLine();

            UI.DisplayInputText("CHARISMA:\t", true);
            int.TryParse(Console.ReadLine(), out int charismaChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= charismaChoice} points remaining.");
            Console.WriteLine();

            UI.DisplayInputText("LUCK:\t\t", true);
            int.TryParse(Console.ReadLine(), out int luckChoice);
            UI.DisplayNoticeText($"{pointsRemaining -= luckChoice} points remaining.");
            Console.WriteLine();

            int totalSpend = strengthChoice + intelligenceChoice + agilityChoice + constitutionChoice + charismaChoice + luckChoice;

            if (totalSpend == newCharSP)
            {
                strength = new Strength(strengthChoice);
                intelligence = new Intelligence(intelligenceChoice);
                agility = new Agility(agilityChoice);
                constitution = new Constitution(constitutionChoice);
                charisma = new Charisma(charismaChoice);
                luck = new Luck(luckChoice);

                UI.DisplaySuccessText("You have spent all available skill points");
            } else
            {
                UI.DisplayWarningText("You have not spent all available skill points (or have spent too many)");
                UI.DisplayInputText("Press any key to retry point allocation.");
                Console.ReadKey();
                CreateBaseStats();
            }
        }

        // DISPLAY CHARACTER SHEET
        public void DisplayCharacterSheet()
        {
            UI.DisplayTitle("CHARACTER SHEET");

            UI.DisplaySubTitle("CHARACTER BIO");
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Character Name:", name, "Hometown:", homeName);
            Console.WriteLine();

            UI.DisplaySubTitle("CHARACTER STATS");
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Strength:", strength.GetEffectiveValue(), "Current Gold:", currentGold);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Intelligence:", intelligence.GetEffectiveValue(), "Current XP:", currentXP);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Dexterity:", agility.GetEffectiveValue(), "Next Level XP:", nextLevelXP);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Constitution:", constitution.GetEffectiveValue(), "Available SP:", skillPoints);
            Console.WriteLine("{0, -20}{1, -20}", "Charisma:", charisma.GetEffectiveValue());
            Console.WriteLine("{0, -20}{1, -20}", "Luck:", luck.GetEffectiveValue());
            Console.WriteLine();

            UI.DisplaySubTitle("CURRENT STATUS");
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Current Health:", currentHealth, "Max Health:", maxHealth);
            Console.WriteLine();

            UI.DisplaySubTitle("EQUIPMENT");
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Helmet:", GetItemPresence(helmet), "Weapon:", GetItemPresence(weapon));
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Chest:", GetItemPresence(chest), "Shield:", GetItemPresence(shield));
            Console.WriteLine("{0, -20}{1, -20}", "Gauntlets:", GetItemPresence(gauntlets));
            Console.WriteLine("{0, -20}{1, -20}", "Boots:", GetItemPresence(legs));
            Console.WriteLine("{0, -20}{1, -20}", "TOTAL DEFENCE:", getTotalArmorRating());
            Console.WriteLine();
            
            UI.DisplayInputText("Press any key to continue.");
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
            UI.DisplayTitle("CHARACTER MENU");

            // List the choices available
            Console.WriteLine("1. View Inventory");
            Console.WriteLine("2. View Character Sheet");
            Console.WriteLine("3. Cancel");

            // Get the players choice
            Console.WriteLine();
            UI.DisplayInputText("Please choose an option: ");
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
                UI.DisplayWarningText("Sorry, I dont' recognise that option.");
                UI.DisplayInputText("Press any key to try again.");
                Console.ReadKey();
                DisplayPlayerMenu();
            }


        }

        public void DisplayInventory()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY");

            // Menu options
            Console.WriteLine("1. Display All");
            Console.WriteLine("2. Weapons");
            Console.WriteLine("3. Armors");
            Console.WriteLine("4. Potions");
            Console.WriteLine("5. Books");
            Console.WriteLine("6. Cancel");
            Console.WriteLine();

            // Get the players choice
            UI.DisplayInputText("Please choose an option: ");
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
                UI.DisplayWarningText("Sorry, I don't recognise that option");
                UI.DisplayInputText("Press any key to try again.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayAll()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY > All items");

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
                UI.DisplayInputText("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                UI.DisplayWarningText("You don't have anything in your inventory.");
                UI.DisplayInputText("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }

        }

        public void DisplayWeapons()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY > Weapons");


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
                UI.DisplayInputText("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                UI.DisplayWarningText("You don't have any weapons in your inventory.");
                UI.DisplayInputText("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayArmors()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY > Armor");

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
                UI.DisplayInputText("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                UI.DisplayWarningText("You don't have any armor in your inventory.");
                UI.DisplayInputText("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayBooks()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY > Books");

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
                UI.DisplayInputText("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                UI.DisplayWarningText("You don't have any books in your inventory.");
                UI.DisplayInputText("Press any key to go back.");
                Console.ReadKey();
                DisplayInventory();
            }
        }

        public void DisplayPotions()
        {
            // Clear the screen and display the header bar
            UI.DisplayTitle("INVENTORY > Potions");

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
                UI.DisplayInputText("Please choose an option (or cancel): ");
                Console.ReadKey();
            }
            else
            {
                UI.DisplayWarningText("You don't have any potions in your inventory.");
                UI.DisplayInputText("Press any key to go back.");
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
