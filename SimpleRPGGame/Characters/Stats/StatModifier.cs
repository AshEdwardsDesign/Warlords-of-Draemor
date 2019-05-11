namespace WarlordsOfDraemor
{
    public class StatModifier
    {
        protected string StatModificationName;
        protected int StatModificationValue;

        public StatModifier(string name, int value)
        {
            StatModificationName = name;
            StatModificationValue = value;
        }

        public string GetName()
        {
            return StatModificationName;
        }

        public int GetValue()
        {
            return StatModificationValue;
        }
    }
}
