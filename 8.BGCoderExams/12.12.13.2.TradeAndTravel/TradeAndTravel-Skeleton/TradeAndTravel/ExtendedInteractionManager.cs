using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(Person actor, string newItemName)
        {
            var currentLocation = actor.Location as IGatheringLocation;

            if (currentLocation != null)
            {
                var inventory = actor.ListInventory();

                foreach (var item in inventory)
                {
                    if (item.ItemType == currentLocation.RequiredItem)
                    {
                        var producedItem = currentLocation.ProduceItem(newItemName);

                        this.AddToPerson(actor, producedItem);
                        break;
                    }
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string type, string newItemName)
        {
            List<Item> inventory = actor.ListInventory();

            if (type == "armor" && inventory.Any(it => it.ItemType == ItemType.Iron))
            {
                this.AddToPerson(actor, new Armor(newItemName));
            }
            else if (type == "weapon" && inventory.Any(it => it.ItemType == ItemType.Wood) && inventory.Any(it => it.ItemType == ItemType.Iron))
            {
                this.AddToPerson(actor, new Weapon(newItemName));
            }
        }
    }
}
