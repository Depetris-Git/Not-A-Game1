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
        public Equipment[] PlayerEquipment = new Equipment[7];
        public Equipment[] PlayerInventory = new Equipment[12];
        private int EquipRow = 7;
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
                MessageBox.Show("Inventory is already full.", "Inventory Full"); 
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
                case ("Two-Handed Weapon"):
                    Unequip(0);
                    Unequip(1);
                    Unequip(2);
                    PlayerEquipment[0] = item;
                    PlayerEquipment[1] = null;
                    break;

                case ("One-Handed Weapon"):
                    Unequip(1);
                    PlayerEquipment[1] = item;
                    break;

                case ("Shield"):
                    Unequip(2);
                    PlayerEquipment[2] = item;
                    break;

                case ("Helmet"):
                    Unequip(3);
                    PlayerEquipment[3] = item;
                    break;

                case ("Chestplate"):
                    Unequip(4);
                    PlayerEquipment[4] = item;
                    break;

                case ("Gauntlet"):
                    Unequip(5);
                    PlayerEquipment[5] = item;
                    break;

                case ("Boots"):
                    Unequip(6);
                    PlayerEquipment[6] = item;
                    break;

            }
        }
    }
}
