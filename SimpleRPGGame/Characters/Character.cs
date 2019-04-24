namespace WarlordsOfDraemor
{
    public class Character
    {
        // GENERAL INFO
        protected string name;
        protected string homeName;
        protected CharacterClass characterClass;
        protected bool alive = true;
        public bool isAlive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
            }
        }

        // STATS
        protected int strength;
        protected int intelligence;
        protected int dexterity;
        protected int constitution;
        protected int level;

        // HEALTH & ARMOR
        protected int maxHealth;
        protected int currentHealth;
        protected decimal healthPercentage;
        protected int currentArmor;

        // EQUIPMENT SLOTS
        protected Weapon weapon;
        protected Shield shield;
        protected Helmet helmet;
        protected ChestArmor chest;
        protected Gauntlet gauntlets;
        protected LegArmor legs;

        // LOOT PROPERTIES
        protected int lootDropChance = 0;
        protected int lootDropMaxRarity = 0;

        // DEAL DAMAGE METHOD
        public void DealDamage(Character enemy)
        {
            enemy.TakeDamage(10);
        }

        // TAKE DAMAGE METHOD
        public void TakeDamage(int dmgReceived)
        {
            currentHealth -= dmgReceived;
        }

        // GET HEALTH METHOD
        public int GetHealth()
        {
            return currentHealth;
        }

    }

    // Character class Enum
    public enum CharacterClass
    {
        Knight,
        Mage,
        Thief,
        Warlock
    }
}
