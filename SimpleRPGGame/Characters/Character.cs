using System.Collections.Generic;

namespace WarlordsOfDraemor
{
    public class Character
    {
        // GENERAL INFO
        protected string name;
        protected string homeName;
        protected string characterClass;
        protected CharacterClass enemyClass;
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
        protected Strength strength;
        protected Intelligence intelligence;
        protected Agility agility;
        protected Constitution constitution;
        protected Charisma charisma;
        protected Luck luck;
        protected int level;

        // STATUS EFFECTS
        protected List<StatusEffect> statusEffects;

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

        public int getTotalArmorRating()
        {
            int total = 0;

            if (helmet != null) total += helmet.GetArmorRating();
            if (chest != null) total += chest.GetArmorRating();
            if (gauntlets != null) total += gauntlets.GetArmorRating();
            if (legs != null) total += legs.GetArmorRating();

            return total;
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
