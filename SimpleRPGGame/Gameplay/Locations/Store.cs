using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarlordsOfDraemor
{
    public class Store
    {
        protected string storeName;
        protected string storeDescription;
        protected NPC storeOwner;

        public Store(string name, string description, NPC owner)
        {
            storeName = name;
            storeDescription = description;
            storeOwner = owner;
        }
    }
}
