using System.Collections.Generic;

namespace WarlordsOfDraemor
{
    public class Stat
    {
        protected int baseValue = 1;                // The base value of the given stat. I.e. Strength = 5;
        protected int EffectiveValue;               // The base value + all modifiers. If the player has a piece of armor that adds 2, effective strength = 7;
        protected List<StatModifier> modifiers;     // A list of all modifiers currently in effect (i.e. from armor, weapons, status effects.

        /// <summary>
        /// Stat Constructor. Just needs an int value.
        /// </summary>
        /// <param name="value"></param>
        public Stat(int value)
        {
            baseValue += value;
            EffectiveValue = baseValue;
        }

        /// <summary>
        /// Add a modifier to the modifier list. This causes stat value recalc.
        /// </summary>
        /// <param name="mod"></param>
        public void AddModifier(StatModifier mod)
        {
            modifiers.Add(mod);
            RecalculateStatValue();
        }

        /// <summary>
        /// Remove a modifer from the modifier list. This causes stat value recalc.
        /// </summary>
        /// <param name="mod"></param>
        public void RemoveModifier(StatModifier mod)
        {
            modifiers.Remove(mod);
            RecalculateStatValue();
        }

        /// <summary>
        /// Add a skill point to this stat (i.e. when levelling up). This causes stat value recalc.
        /// </summary>
        /// <param name="value"></param>
        public void AddSkillPoint(int value)
        {
            baseValue += value;
            RecalculateStatValue();
        }

        /// <summary>
        /// Method to trigger recalucation of the players effective value for this stat.
        /// </summary>
        private void RecalculateStatValue()
        {
            EffectiveValue = baseValue + ValueOfAllModifiers();
        }

        /// <summary>
        /// Get the total value of all stat modifiers in the modifier list.
        /// </summary>
        /// <returns></returns>
        private int ValueOfAllModifiers()
        {
            int temp = 0;
            foreach (StatModifier mod in modifiers)
            {
                temp += mod.GetValue();
            }
            return temp;
        }

        public int GetBaseValue()
        {
            return baseValue;
        }

        public int GetEffectiveValue()
        {
            return EffectiveValue;
        }


    }
}
