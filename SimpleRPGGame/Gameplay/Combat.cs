using System;

namespace WarlordsOfDraemor
{
    public static class Combat
    {
        public static void CombatCheck(Player player)
        {
            bool combatAvoided = false;

            if (combatAvoided)
            {
                Console.WriteLine("You have avoided combat!");
            } else
            {
                Console.WriteLine("Combat is beginning...");
                Enemy enemy = new Enemy(player);
                Console.ReadLine();
                StartCombat(player, enemy);
            }
            
        }

        public static void StartCombat(Player player, Enemy enemy)
        {

            while (player.isAlive && enemy.isAlive)
            {
                player.DealDamage(enemy);
                DisplayCombatScreen(player, enemy);
                Console.WriteLine($"Player hits. Enemy Health = {enemy.GetHealth()}");
                Console.ReadLine();

                if (player.GetHealth() <= 0)
                {
                    player.isAlive = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have died!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press enter to return the the main menu.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Program.MainMenu();
                }

                if (enemy.GetHealth() <= 0)
                {
                    enemy.isAlive = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have killed the enemy!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press enter to loot the corpse.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Loot.DisplayLootScreen(player, enemy);
                    return;
                }

                enemy.DealDamage(player);
                DisplayCombatScreen(player, enemy);
                Console.WriteLine($"Enemy hits. Player health = {player.GetHealth()}");
                Console.ReadLine();

            }
        }

        private static void DisplayCombatScreen(Player player, Enemy enemy)
        {
            UI.DisplayTitle("COMBAT MODE", true);

            UI.DisplayNoticeText("PLAYER\t\t\tENEMY");
            Console.WriteLine();

            Console.WriteLine($"Player Name: {player.GetName()}\t\t\tEnemy Class: {enemy.GetEnemyClass()}");
            Console.WriteLine($"Player Health: {player.GetHealth()}\t\t\tEnemy Health: {enemy.GetHealth()}");
            Console.WriteLine($"Player Armor: {player.getTotalArmorRating()}\t\t\tEnemy Armor: {enemy.getTotalArmorRating()}");
            Console.WriteLine(
                $"Player Stats (Agi, Chr, Con, Int, Lck, Str): " +
                $"{player.GetEffectiveAgility()}, " +
                $"{player.GetEffectiveCharisma()}, " +
                $"{player.GetEffectiveConstitution()}, " +
                $"{player.GetEffectiveIntelligence()}, " +
                $"{player.GetEffectiveLuck()}, " +
                $"{player.GetEffectiveStrength()}" +
                $"\t\t\tEnemy Stats (Agi, Chr, Con, Int, Lck, Str): " +
                $"{enemy.GetEffectiveAgility()}, " +
                $"{enemy.GetEffectiveCharisma()}, " +
                $"{enemy.GetEffectiveConstitution()}, " +
                $"{enemy.GetEffectiveIntelligence()}, " +
                $"{enemy.GetEffectiveLuck()}, " +
                $"{enemy.GetEffectiveStrength()}");
            Console.WriteLine();
        }

    }
}
