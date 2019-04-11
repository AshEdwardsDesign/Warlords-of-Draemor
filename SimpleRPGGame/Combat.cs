using System;

namespace WarlordsOfDraemor
{
    public static class Combat
    {
        public static void StartCombat(Player player)
        {

            Enemy enemy = new Enemy(player); 

            while (true)
            {
                DisplayCombatScreen(player, enemy);
                player.DealDamage(enemy);
                Console.WriteLine($"Player hits. Enemy Health = {enemy.GetHealth()}");
                Console.ReadLine();

                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine("You have died!");
                    Console.WriteLine("Press enter to return the the main menu.");
                    Console.ReadLine();
                    Program.MainMenu();
                }

                if (enemy.GetHealth() <= 0)
                {
                    Console.WriteLine("You have killed the enemy!");
                    Console.ReadLine();
                    return;
                }

                DisplayCombatScreen(player, enemy);
                enemy.DealDamage(player);
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

    }
}
