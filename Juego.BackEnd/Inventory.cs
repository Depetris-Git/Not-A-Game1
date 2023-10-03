using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego.BackEnd
{
    public class Inventory
    {
        public Equipment[] PlayerEquipment = new Equipment[6];
        public Equipment[] PlayerInventory = new Equipment[12];
        private int EquipRow = 6;
        private int InventoryRow = 12;

        public void PickUp(Equipment equip)
        {
            bool PickedUp = false;
            for (int i = 0; i<=12; i++)
                if (PlayerInventory[i] == null && PickedUp == false)
                {
                    PlayerInventory[i] = equip;
                    PickedUp = true;
                    break;
                }
            if (PickedUp == false)
            {
                // Text = "Inventory is already full"
            }
        }
        
        public Equipment Search(string aName)
        {
            for (int i = 0; i < InventoryRow; i++)
            {
                if (PlayerInventory[i].Name == aName)
                {
                    return PlayerInventory[i];
                }
            }
            for (int i = 0; i<EquipRow; i++)
            {
                if (PlayerEquipment[i].Name == aName)
                {
                    return PlayerEquipment[i];
                }
            }
                return null;
        }
        public void Unequip(int Row)
        {
            if (PlayerEquipment[Row] != null)
            {
                PickUp(PlayerEquipment[Row]);
            }
            PlayerEquipment[Row] = null;
        }
        public void Equip(Equipment item)
        {
            switch (item.Type)
            {
                case ("Two-handed weapon"):
                    Unequip(0);
                    Unequip(1);
                    PlayerInventory[0] = item;
                    PlayerInventory[1] = null;
                    break;

                case ("One-handed weapon"):
                    PlayerInventory[0] = item;
                    break;

                case ("Shield"):
                    PlayerInventory[1] = item;
                    break;

                case ("Helmet"):
                    PlayerInventory[2] = item;
                    break;

                case ("Chestplate"):
                    PlayerInventory[3] = item;
                    break;

                case ("Gauntlet"):
                    PlayerInventory[4] = item;
                    break;

                case ("Boots"):
                    PlayerInventory[5] = item;
                    break;

            }
        }
    }
}
