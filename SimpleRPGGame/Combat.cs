using System;

namespace WarlordsOfDraemor
{
    public static class Combat
    {
        public static void StartCombat(Player player, Enemy enemy)
        {

            while (true)
            {
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
                
                enemy.DealDamage(player);
                Console.WriteLine($"Enemy hits. Player health = {player.GetHealth()}");
                Console.ReadLine();

                if (enemy.GetHealth() <= 0)
                {
                    Console.WriteLine("You have killed the enemy!");
                    Console.ReadLine();
                    return;
                }
            }
        }

    }
}
