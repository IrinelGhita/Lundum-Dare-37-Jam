using LD37.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            EquipItem(new Armour("No headgear", "", 0, 0, ArmourSlot.Headgear));
            EquipItem(new Armour("No chest armour", "", 0, 0, ArmourSlot.Chest));
            EquipItem(new Armour("No boots", "", 0, 0, ArmourSlot.Boots));
            EquipItem(new Armour("No shield", "", 0, 0, ArmourSlot.Shield));
            EquipItem(new Armour("No gloves", "", 0, 0, ArmourSlot.Gloves));
            EquipItem(new Armour("No cloak", "", 0, 0, ArmourSlot.Cloak));
            EquipItem(new Weapon("Unarmed", "I was born a brawler", 0, 3, WeaponType.Melee));
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
                        EquipEmpty(ArmourSlot.None);
                }
                else
                {
                    ArmourSlot slot = ((Armour)item).Slot;
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

        private void EquipEmpty(ArmourSlot slot)
        {
            switch (slot)
            {
                case ArmourSlot.Boots:
                    {
                        EquipItem(new Armour("No boots", "", 0, 0, ArmourSlot.Boots));
                        break;
                    }
                case ArmourSlot.Headgear:
                    {
                        EquipItem(new Armour("No headgear", "", 0, 0, ArmourSlot.Headgear));
                        break;
                    }
                case ArmourSlot.Chest:
                    {
                        EquipItem(new Armour("No chest armour", "", 0, 0, ArmourSlot.Chest));
                        break;
                    }
                case ArmourSlot.Shield:
                    {
                        EquipItem(new Armour("No shield", "", 0, 0, ArmourSlot.Shield));
                        break;
                    }
                case ArmourSlot.Gloves:
                    {
                        EquipItem(new Armour("No gloves", "", 0, 0, ArmourSlot.Gloves));
                        break;
                    }
                case ArmourSlot.Cloak:
                    {
                        EquipItem(new Armour("No cloak", "", 0, 0, ArmourSlot.Cloak));
                        break;
                    }
                default:
                    {
                        EquipItem(new Weapon("Unarmed", "I was born a brawler", 0, 3, WeaponType.Melee));
                        break;
                    }
            }
        }

        /// <summary>
        /// Equips an item - Overloads any current gear
        /// </summary>
        /// <param name="item">Item to equip</param>
        /// <returns>Equipped successfully?</returns>
        private bool EquipItem(Item item)
        {

            //TODO: Add the onscreen placement logic

            return true;
        }

        /// <summary>
        /// Equips an inventory item
        /// </summary>
        /// <param name="itemInventoryPosition">Position in inventory - Rows contain : 0-7,8-15,16-23,24-31</param>
        private void EquipItemFromInventory(int itemInventoryPosition)
        {
            //Add logic

        }

        private void PlaceItemInInventory(Item item, int position)
        {
            inventory[position % 8, position / 8] = item;
            //TODO: Add the onscreen placement logic
        }
        #endregion
    }
}
