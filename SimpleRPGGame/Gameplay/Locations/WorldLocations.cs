using System.Collections.Generic;
using System.Linq;

namespace WarlordsOfDraemor
{
    public static class WorldLocations
    {
        private static List<Location> allWorldLocations = new List<Location>()
        {
            // Inns
            new Inn("Fox & Hound", "A dank and dark inn on the outskirts of the Arwaen forest", false, false, false, false, false),
            
            // Villages
            new Village("Caeldor", "A peaceful village near the Fox & Hound.", true, true, false, false, false),

            // Towns
            new Town("Yorktown", "A bustling town and minor port on the banks of the Vildur river.", true, true, true, false, false),

            // Castles
            new Castle("Castle Wyvet", "A castle held by xxx, located near Yorktown", true, false, true, false, false),

            // Caves
            new Cave("Dawn Hollow", "A cave home to a local legend. Locals say a vampire dwells here."),

            // Cities
            new City("Treyport", "A sprawling metropolis and power base for Lord Hassan.", true, true, true, true, true),

            // Dungeons
            new Dungeon("Fort Haagstaad", "An old, decrepit war fort, long since abandoned. Now home to all manner of foulness."),

            // Forests
            new Forest("Arwaen Forest", "A small and generally safe forest, located east of the Korvan mountains.")
        };

        private static List<Location> allVillages = allWorldLocations.Where(v => v.GetType() == typeof(Village)).ToList();
        private static List<Location> allTowns = allWorldLocations.Where(v => v.GetType() == typeof(Town)).ToList();
        private static List<Location> allCastles = allWorldLocations.Where(v => v.GetType() == typeof(Castle)).ToList();
        private static List<Location> allCaves = allWorldLocations.Where(v => v.GetType() == typeof(Cave)).ToList();
        private static List<Location> allCities = allWorldLocations.Where(v => v.GetType() == typeof(City)).ToList();
        private static List<Location> allDungeons = allWorldLocations.Where(v => v.GetType() == typeof(Dungeon)).ToList();
        private static List<Location> allForests = allWorldLocations.Where(v => v.GetType() == typeof(Forest)).ToList();
        private static List<Location> allInns = allWorldLocations.Where(v => v.GetType() == typeof(Inn)).ToList();

        public static List<Location> GetAllLocations()
        {
            return allWorldLocations;
        }

    }
}
