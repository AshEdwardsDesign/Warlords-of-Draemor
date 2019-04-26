using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarlordsOfDraemor
{
    public class Location
    {
        protected string locationName;
        protected string locationDescription;

        public Location(string locName, string locDescription)
        {
            locationName = locName;
            locationDescription = locDescription;
        }
    }
}
