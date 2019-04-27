namespace WarlordsOfDraemor
{
    public class NPC
    {
        private string npcName;
        private string npcDescription;
        private int npcRelationship;

        public NPC(string name, string desc, int relation = 0)
        {
            npcName = name;
            npcDescription = desc;
            npcRelationship = relation;
        }

        public void ModifyRelation(int mod)
        {
            npcRelationship += mod;
        }
        public string GetName()
        {
            return npcName;
        }

        public string GetDescription()
        {
            return npcDescription;
        }

        public int GetRelationship()
        {
            return npcRelationship;
        }
    }
}
