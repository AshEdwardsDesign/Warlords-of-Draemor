using System;

namespace WarlordsOfDraemor
{
    public class Enemy : Character
    {

        // Random instance
        Random random;

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
            random = new Random();
            ChooseRandomEnemyClass();
            strength = new Strength(GetScaledStat(player.GetBaseStrength()));
            intelligence = new Intelligence(GetScaledStat(player.GetBaseIntelligence()));
            agility = new Agility(GetScaledStat(player.GetBaseAgility()));
            constitution = new Constitution(GetScaledStat(player.GetBaseConstitution()));
            charisma = new Charisma(GetScaledStat(player.GetBaseCharisma()));
            luck = new Luck(GetScaledStat(player.GetBaseLuck()));
            currentHealth = GetScaledHealth(player.GetMaxHealth());
            maxHealth = currentHealth;
        }

        /// <summary>
        /// Takes in the players health value and returns a random health value for the enemy, scaled to the player.
        /// </summary>
        /// <param name="playerHealth"></param>
        /// <returns></returns>
        private int GetScaledHealth(int playerHealth)
        {
            int enemyHealth = random.Next(playerHealth - 50, playerHealth + 51);

            if (enemyHealth < 50) enemyHealth = 50;

            return enemyHealth;
        }

        /// <summary>
        /// Takes in a stat and returns a value in a range around that stat value.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private int GetScaledStat(int val)
        {
            int calcedVal = random.Next(val - 2, val + 3);

            if (calcedVal < 1)
            {
                calcedVal = 1;
            }
            else if (calcedVal > 10)
            {
                calcedVal = 10;
            }

            return calcedVal;
        }

        // CHOOSE RANDOM ENEMY CLASS
        private void ChooseRandomEnemyClass()
        {
            var enemyClasses = Enum.GetValues(typeof(enemyClass));
            EnemyClass = (enemyClass)enemyClasses.GetValue(random.Next(enemyClasses.Length));
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
