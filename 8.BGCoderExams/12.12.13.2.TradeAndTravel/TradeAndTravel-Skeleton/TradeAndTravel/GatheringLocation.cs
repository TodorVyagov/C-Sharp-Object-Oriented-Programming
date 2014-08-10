using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        protected GatheringLocation(string name, LocationType locType, ItemType gatheredType, ItemType requiredItem) :base(name, locType)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = requiredItem;
        }

        public ItemType GatheredType
        {
            get;
            protected set;
        }

        public ItemType RequiredItem
        {
            get;
            protected set;
        }

        public abstract Item ProduceItem(string name);
    }
}
