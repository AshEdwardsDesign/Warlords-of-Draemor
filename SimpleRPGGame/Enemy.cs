using System;

namespace WarlordsOfDraemor
{
    public class Enemy : Character
    {

        // GENERAL INFO
        private enemyClass EnemyClass;

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
            EnemyClass = ChooseRandomEnemyClass();
            strength = 1;
            intelligence = 1;
            dexterity = 1;
            constitution = 1;
            currentHealth = 50;
            maxHealth = currentHealth;
        }

        // CHOOSE RANDOM ENEMY CLASS
        private enemyClass ChooseRandomEnemyClass()
        {
            Random myRand = new Random();
            var enemyClasses = Enum.GetValues(typeof(enemyClass));
            enemyClass chosen = (enemyClass)enemyClasses.GetValue(myRand.Next(enemyClasses.Length));
            return chosen;
        }

        // Enemy class enum
        public enum enemyClass
        {
            Orc,
            Imp,
            Bandit,
            GiantSpider,
            Draugr
        }

        // Get enemy's current class
        public string GetEnemyClass()
        {
            return EnemyClass.ToString();
        }

    }
}
