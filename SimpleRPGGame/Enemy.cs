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

        // DEAL DAMAGE
        public void DealDamage(Player player)
        {
            player.TakeDamage(5);
        }

        // TAKE DAMAGE
        public void TakeDamage(int dmgReceived, Player player)
        {
            currentHealth -= dmgReceived;
            if (currentHealth <= 0)
                Death(player);
        }

        public int calcXPValue()
        {
            return 25;
        }

        // DEATH 
        public void Death(Player player)
        {
            player.GainXP(calcXPValue());
        }

        // ENEMY CREATION (CONSTRUCTOR)
        public Enemy(Player player)
        {
            // TO-DO
        }
        
    }
}
