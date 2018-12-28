using System;

namespace WarlordsOfDraemor
{
    public class Enemy
    {

        // GENERAL INFO
        private string enemyType;

        // STATS
        private int strength;
        private int intelligence;
        private int dexterity;
        private int constitution;
        private int level;

        // HEALTH & ARMOR
        private int maxHealth;
        private int currentHealth;
        private decimal healthPercentage;
        private int currentArmor;

        // HEALTH PERCENTAGE CALC
        public void calcHealthPercentage()
        {
            healthPercentage = ((decimal)currentHealth / (decimal)maxHealth) * 100M;
        }

        // ENEMY CREATION (CONSTRUCTOR)
        public Enemy(Player player)
        {
            // TO-DO
        }
        
    }
}
