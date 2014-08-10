using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Wood : Item
    {
        /*The Wood item has a money value of 2
            o	The Wood item decreases its value each time it is dropped by 1, until it reaches 0
            o	Syntax: create item wood woodname location */
        private const int WoodValue = 2;

        public Wood(string name, Location location = null) : base(name, WoodValue, ItemType.Wood, location)
        {

        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}
