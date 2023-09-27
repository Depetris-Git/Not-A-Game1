using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Juego.BackEnd
{
    public class Inventory
    {
        public Equipment[] PlayerEquipment = new Equipment[6];
        public Equipment[] PlayerInventory = new Equipment[12];

        public void PickUp(Equipment equip)
        {
            bool PickedUp = false;
            for (int i = 0; i<=12; i++)
                if (PlayerInventory[i] == null && PickedUp == false)
                {
                    PlayerInventory[i] = equip;
                    PickedUp = true;
                }
            if (PickedUp == false)
            {
                // Text = "Inventory is already full"
            }
        }
    }
}
