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

        public int calcGoldValue()
        {
            return 10;
        }

        // DEATH 
        public void Death(Player enemy)
        {
            enemy.GainXP(calcXPValue());
            enemy.GainGold(calcGoldValue());
        }

        // ENEMY CREATION (CONSTRUCTOR)
        public Enemy(Player player)
        {
            EnemyClass = ChooseRandomEnemyClass();
            strength = new Strength(1);
            intelligence = new Intelligence(1);
            agility = new Agility(1);
            constitution = new Constitution(1);
            charisma = new Charisma(1);
            luck = new Luck(1);
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
            Draugr,
            Dhampyr,
            Vampire
        }

        /// <summary>
        /// Get the Enemy's class.
        /// </summary>
        /// <returns></returns>
        public string GetEnemyClass()
        {
            return EnemyClass.ToString();
        }

    }
}
