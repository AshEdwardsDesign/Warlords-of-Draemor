using System;

namespace WarlordsOfDraemor
{
    public static class NewGameStart
    {
        public static bool StartGame()
        {
            Player player = new Player();
            Hub foxAndHound = new Hub("Fox & Hound", "on the outskirts of the Arwaen forest", Hub.HubType.Inn, false, false, false, false, false);
            PlayIntro(player);
            bool cont = true;
            while (cont)
            {
                cont = foxAndHound.GoToHub(player);
            }
            return false;
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
