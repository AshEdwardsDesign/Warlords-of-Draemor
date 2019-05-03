using System;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class NewGameStart
    {
        public static void StartGame()
        {
            Player player = new Player();
            PlayIntro(player);
            Location foxHound = WorldLocations.GetAllLocations().Find(v => v.GetName() == "Fox & Hound");
            player.SetLocation(foxHound);
            player.GetLocation().ShowLocationMenu(player);
        }

        public static void PlayIntro(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A JOURNEY BEGINS...");
            Console.ResetColor();
            Console.WriteLine("This is the intro, which will have you fight an enemy and overcome a puzzle before reaching the Fox & Hound.");
            Console.WriteLine("To be implemented.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A combat trial will now begin...");
            Console.ResetColor();
            Console.ReadLine();
            Combat.StartCombat(player);
        }
    }
}
