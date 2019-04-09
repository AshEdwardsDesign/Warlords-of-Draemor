namespace WarlordsOfDraemor
{
    public class Enemy : Character
    {

        // GENERAL INFO
        private string enemyType;

        // HEALTH PERCENTAGE CALC
        public void calcHealthPercentage()
        {
            healthPercentage = ((decimal)currentHealth / (decimal)maxHealth) * 100M;
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
