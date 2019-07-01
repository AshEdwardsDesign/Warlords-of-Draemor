using System.Collections.Generic;

namespace WarlordsOfDraemor
{
    public class Character
    {
        // GENERAL INFO
        protected string name;
        protected string homeName;
        protected string characterClass;
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

        // STAMINA
        protected int currentStamina;
        protected int maxStamina;

        // MANA
        protected int currentMana;
        protected int maxMana;

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

            if (helmet != null)
            {
                total += helmet.GetArmorRating();
            }

            if (chest != null)
            {
                total += chest.GetArmorRating();
            }

            if (gauntlets != null)
            {
                total += gauntlets.GetArmorRating();
            }

            if (legs != null)
            {
                total += legs.GetArmorRating();
            }

            return total;
        }

        /// <summary>
        /// Get the characters base Strength value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseStrength()
        {
            return strength.GetBaseValue();
        }

        /// <summary>
        /// Get the characters base Intelligence value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseIntelligence()
        {
            return intelligence.GetBaseValue();
        }

        /// <summary>
        /// Get the characters base Agility value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseAgility()
        {
            return agility.GetBaseValue();
        }

        /// <summary>
        /// Get the characters base Constitution value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseConstitution()
        {
            return constitution.GetBaseValue();
        }

        /// <summary>
        /// Get the characters base Luck value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseLuck()
        {
            return luck.GetBaseValue();
        }

        /// <summary>
        /// Get the characters base Charisma value.
        /// </summary>
        /// <returns></returns>
        internal int GetBaseCharisma()
        {
            return charisma.GetBaseValue();
        }

        /// <summary>
        /// Get the characters maximum health.
        /// </summary>
        /// <returns></returns>
        internal int GetMaxHealth()
        {
            return maxHealth;
        }

        /// <summary>
        /// Get the characters effective  Strength value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveStrength()
        {
            return strength.GetEffectiveValue();
        }

        /// <summary>
        /// Get the characters effective Intelligence value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveIntelligence()
        {
            return intelligence.GetEffectiveValue();
        }

        /// <summary>
        /// Get the characters effective Agility value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveAgility()
        {
            return agility.GetEffectiveValue();
        }

        /// <summary>
        /// Get the characters base Constitution value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveConstitution()
        {
            return constitution.GetEffectiveValue();
        }

        /// <summary>
        /// Get the characters base Luck value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveLuck()
        {
            return luck.GetEffectiveValue();
        }

        /// <summary>
        /// Get the characters base Charisma value.
        /// </summary>
        /// <returns></returns>
        internal int GetEffectiveCharisma()
        {
            return charisma.GetEffectiveValue();
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
