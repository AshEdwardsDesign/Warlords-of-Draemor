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
            player.addDiscoveredLocation(foxHound);
            player.SetLocation(foxHound);
        }

        public static void PlayIntro(Player player)
        {
            Console.Clear();
            UI.DisplayTitle("A JOURNEY BEGINS...");
            Console.WriteLine("This is the intro, which will have you fight an enemy and overcome a puzzle before reaching the Fox & Hound.");
            UI.DisplayWarningText("To be implemented.");
            Console.WriteLine();
            UI.DisplayWarningText("A combat trial will now begin...");
            Console.ReadLine();
            Combat.CombatCheck(player);
        }
    }
}
