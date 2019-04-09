namespace WarlordsOfDraemor
{
    public class Enemy : Character
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
        public void DealDamage(Character enemy)
        {
            enemy.TakeDamage(5);
        }

        // TAKE DAMAGE
        public void TakeDamage(int dmgReceived, Player enemy)
        {
            currentHealth -= dmgReceived;
            if (currentHealth <= 0)
            {
                Death(enemy);
            }
        }

        public int calcXPValue()
        {
            return 25;
        }

        // DEATH 
        public void Death(Player enemy)
        {
            enemy.GainXP(calcXPValue());
        }

        // ENEMY CREATION (CONSTRUCTOR)
        public Enemy(Player player)
        {
            enemyType = "Orc";
            strength = 1;
            intelligence = 1;
            dexterity = 1;
            constitution = 1;
            currentHealth = 100;
            maxHealth = 100;
        }

    }
}
