using System;

namespace WarlordsOfDraemor
{
    public static class Combat
    {
        public static void StartCombat(Player player)
        {

            Enemy enemy = new Enemy(player); 

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
                    DisplayLootScreen(player, enemy);
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########");
            Console.WriteLine("COMBAT MODE");
            Console.WriteLine("###########");
            Console.ResetColor();

            Console.WriteLine($"Player Name: {player.GetName()}\t\t\tEnemy Class: {enemy.GetEnemyClass()}");
            Console.WriteLine($"Player Health: {player.GetHealth()}\t\t\tEnemy Health: {enemy.GetHealth()}");
            Console.WriteLine();
        }

        /// <summary>
        /// Display the loot screen (showing loot, xp, gold gained etc).
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        private static void DisplayLootScreen(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("############");
            Console.WriteLine("LOOT SCREEN");
            Console.WriteLine("############");
            Console.ResetColor();

            Console.WriteLine($"Player Name: {player.GetName()}\t\t\tEnemy Class: {enemy.GetEnemyClass()}");
            Console.WriteLine($"Player current health: {player.GetHealth()}");
            Console.WriteLine($"Gold: {player.GetGoldAmount()}\t\t\tPlayer xp: {player.GetXPAmount()}");
            Console.WriteLine();
            enemy.Death(player);
            Console.ReadLine();
        } 

    }
}
