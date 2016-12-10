using LD37.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LD37.Entities.Item;

namespace LD37.Entities
{
    class PlayerEntity :GameEntity
    {

        #region Variables
        Item[,] inventory;
        Weapon equipedWeapon;
        Armour headgear, chest, boots, shield, gloves, cloak;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public PlayerEntity(string name,int maxHP, int damage) : base(name,maxHP, damage)
        {
            inventory = new Item[8, 4];

            EquipItem(new Armour("No headgear", "", 0, 0, Equipable.Headgear));
            EquipItem(new Armour("No chest armour", "", 0, 0, Equipable.Chest));
            EquipItem(new Armour("No boots", "", 0, 0, Equipable.Boots));
            EquipItem(new Armour("No shield", "", 0, 0, Equipable.Shield));
            EquipItem(new Armour("No gloves", "", 0, 0, Equipable.Gloves));
            EquipItem(new Armour("No cloak", "", 0, 0, Equipable.Cloak));
            EquipItem(new Weapon("Unarmed", "I was born a brawler", 0, 3, Equipable.MeleeWeapon));
        }
        #endregion

        #region Public methods
        public void UnequipItem(Item item,int inventoryDropSlot=-1,bool replaceWithEmpty=true)
        {
            int targetInventorySpace = inventoryDropSlot>-1 ? inventoryDropSlot : PerformInventorySpaceAvailableCheck();
            if(targetInventorySpace>-1)
            {
                if(item.GetType()== typeof(Weapon))
                {
                    PlaceItemInInventory(item, targetInventorySpace);
                    if(replaceWithEmpty)
                        EquipEmpty(Equipable.MeleeWeapon);
                }
                else
                {
                    Equipable slot = item.EquipableSlot;
                    PlaceItemInInventory(item, targetInventorySpace);
                    if (replaceWithEmpty)
                        EquipEmpty(slot);
                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Checks if there is any space available
        /// </summary>
        /// <returns>The first position available</returns>
        private int PerformInventorySpaceAvailableCheck()
        {
            for(int j=0;j<4;j++)
            {
                for(int i=0;i<8;i++)
                {
                    if (inventory[i, j] == null)
                        return i + j * 8;
                }
            }

            return -1;
        }

        private void EquipEmpty(Equipable slot)
        {
            switch (slot)
            {
                case Equipable.Boots:
                    {
                        EquipItem(new Armour("No boots", "", 0, 0, Equipable.Boots,true));
                        break;
                    }
                case Equipable.Headgear:
                    {
                        EquipItem(new Armour("No headgear", "", 0, 0, Equipable.Headgear, true));
                        break;
                    }
                case Equipable.Chest:
                    {
                        EquipItem(new Armour("No chest armour", "", 0, 0, Equipable.Chest, true));
                        break;
                    }
                case Equipable.Shield:
                    {
                        EquipItem(new Armour("No shield", "", 0, 0, Equipable.Shield, true));
                        break;
                    }
                case Equipable.Gloves:
                    {
                        EquipItem(new Armour("No gloves", "", 0, 0, Equipable.Gloves, true));
                        break;
                    }
                case Equipable.Cloak:
                    {
                        EquipItem(new Armour("No cloak", "", 0, 0, Equipable.Cloak, true));
                        break;
                    }
                case Equipable.MeleeWeapon:
                    {
                        EquipItem(new Weapon("Unarmed", "I was born a brawler", 0, 3, Equipable.MeleeWeapon, true));
                        break;
                    }
            }
        }

        /// <summary>
        /// Equips an item - Overload - Do not use unless you know what you're doing
        /// </summary>
        /// <param name="item">Item to equip</param>
        /// <returns>Equipment in Slot</returns>
        private Item EquipItem(Item item)
        {
            Item equiped=null;

            switch (item.EquipableSlot)
            {
                case Equipable.Boots:
                    {
                        equiped = boots;
                        boots = (Armour)item;
                        break;
                    }
                case Equipable.Headgear:
                    {
                        equiped = headgear;
                        headgear = (Armour)item;
                        break;
                    }
                case Equipable.Chest:
                    {
                        equiped = chest;
                        chest = (Armour)item;
                        break;
                    }
                case Equipable.Shield:
                    {
                        equiped = shield;
                        shield = (Armour)item;
                        break;
                    }
                case Equipable.Gloves:
                    {
                        equiped = gloves;
                        gloves = (Armour)item;
                        break;
                    }
                case Equipable.Cloak:
                    {
                        equiped = cloak;
                        cloak = (Armour)item;
                        break;
                    }
                case Equipable.MeleeWeapon:
                    {
                        equiped = equipedWeapon;
                        equipedWeapon = (Weapon)item;
                        break;
                    }
                case Equipable.Ranged:
                    {
                        equiped = equipedWeapon;
                        equipedWeapon = (Weapon)item;
                        break;
                    }
            }

            //TODO: Add the onscreen placement logic

            return equiped;
        }

        /// <summary>
        /// Equips an inventory item
        /// </summary>
        /// <param name="itemInventoryPosition">Position in inventory - Rows contain : 0-7,8-15,16-23,24-31</param>
        private void EquipItemFromInventory(int itemInventoryPosition)
        {
            Item item = inventory[itemInventoryPosition % 8, itemInventoryPosition / 8];

            Item formerItem = EquipItem(item);

            if (formerItem != null && !formerItem.IsPlaceholder)
            {
                PlaceItemInInventory(formerItem, itemInventoryPosition);
            }
        }

        private void PlaceItemInInventory(Item item, int position)
        {
            inventory[position % 8, position / 8] = item;

            //TODO: Add the onscreen placement logic
        }
        #endregion
    }
}
