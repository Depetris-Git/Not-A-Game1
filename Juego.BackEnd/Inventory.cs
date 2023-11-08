using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego.BackEnd
{
    public class Inventory
    {
        public Equipment[] PlayerEquipment;
        public Equipment[] PlayerInventory;
        
        private int EquipRow = 7;
        private int InventoryRow = 12;
        public DataTable InventoryList { get; set; } = new DataTable();
        public DataTable EquipmentList { get; set; } = new DataTable();
        public Inventory()
        {
            InventoryList.TableName = "Inventory Save";
            InventoryList.Columns.Add("Inventory Slot", typeof(string));
            InventoryList.Columns.Add("Item ID", typeof(string));
            InventoryList.Columns.Add("Array Position", typeof(int));
            ReadInventoryFile();

            EquipmentList.TableName = "Equipment Save";
            EquipmentList.Columns.Add("Equipment Slot", typeof(string));
            EquipmentList.Columns.Add("Item ID", typeof(string));
            EquipmentList.Columns.Add("Array Position", typeof(int));
            ReadEquipmentFile();
        }

        public void ReadInventoryFile() 
        {
            if (System.IO.File.Exists("Inventory.xml"))
            {
                InventoryList.ReadXml("Inventory.xml");
            }
        }

        public void ReadEquipmentFile()
        {
            if (System.IO.File.Exists("Equipment.xml"))
            {
                EquipmentList.ReadXml("Equipment.xml");
            }
        }

        public void InventoryScan()
        { 
            for (int i = 0; i < PlayerInventory.Length; i++)
            {
                string ID;
                int Position;

                InventoryList.Rows.Add();

                if (PlayerInventory[i] == null)
                {
                    ID = string.Empty;
                    InventoryList.Rows[i]["Array Position"] = DBNull.Value;
                }
                else
                {
                    ID = PlayerInventory[i].ID_Item;
                    Position = i;
                    InventoryList.Rows[i]["Array Position"] = i;
                }

                InventoryList.Rows[i]["Inventory Slot"] = "Player Inventory Slot " + i;
                InventoryList.Rows[i]["Item ID"] = ID;
            }

            InventoryList.WriteXml("Inventory.xml");
        }

        public void EquipmentScan()
        {
            for (int i = 0; i < PlayerEquipment.Length; i++)
            {
                string ID;
                int Position;

                EquipmentList.Rows.Add();

                if (PlayerEquipment[i] == null)
                {
                    ID = string.Empty;
                    InventoryList.Rows[i]["Array Position"] = DBNull.Value;
                }
                else
                {
                    ID = PlayerEquipment[i].ID_Item;
                    Position = i;
                    EquipmentList.Rows[i]["Array Position"] = i;
                }

                EquipmentList.Rows[i]["Item ID"] = ID;
                
                switch (i)
                {
                    case (0):
                        EquipmentList.Rows[0]["Equipment Slot"] = "Two-Handed Weapon Slot";
                        break;
                    case (1):
                        EquipmentList.Rows[1]["Equipment Slot"] = "One-Handed Weapon Slot";
                        break;
                    case (2):
                        EquipmentList.Rows[2]["Equipment Slot"] = "Shield Slot";
                        break;
                    case (3):
                        EquipmentList.Rows[3]["Equipment Slot"] = "Helmet Slot";
                        break;
                    case (4):
                        EquipmentList.Rows[4]["Equipment Slot"] = "Chestplate Slot";
                        break;
                    case (5):
                        EquipmentList.Rows[5]["Equipment Slot"] = "Gauntlet Slot";
                        break;
                    case (6):
                        EquipmentList.Rows[6]["Equipment Slot"] = "Boots Slot";
                        break;
                    default:
                        break;
                }
                EquipmentList.WriteXml("Equipment.xml");
            }
        }

        public void PickUp(Equipment equip)
        {
            bool PickedUp = false;
            for (int i = 0; i<=(PlayerInventory.Length); i++)
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


        public string SearchBoth(string aName)
        {
            string name;
            for (int i = 0; i <= PlayerInventory.Length; i++)
            {
                if (PlayerInventory[i] == null)
                {
                    name = string.Empty;
                }
                else
                {
                    name = PlayerInventory[i].Name;
                }
                if (name != string.Empty)
                {
                    if (PlayerInventory[i].Name == aName)
                    {
                        return i.ToString();
                    }
                }

            }
            for (int i = 0; i<PlayerEquipment.Length; i++)
            {
                if (PlayerEquipment[i] == null)
                {
                    name = string.Empty;
                }
                else
                {
                    name = PlayerEquipment[i].Name;
                }
                if (name != string.Empty)
                {
                    if (PlayerEquipment[i].Name == aName)
                    {
                        return i.ToString();
                    }
                }
            }
            return null;
        }
        public Equipment SearchInInventory(string ID)
        {
            string ItemID;
            for (int i = 0; i <= (PlayerInventory.Length); i++)
            {
                if (PlayerInventory[i] == null)
                {
                    ItemID = string.Empty;
                }
                else
                {
                    ItemID = PlayerInventory[i].ID_Item;

                }

                if (ItemID == ID)
                {
                    return PlayerInventory[i];
                }
            }
            return null;
        }
        public Equipment SearchInEquipment(string ID)
        {
            for (int i = 0; i <= PlayerEquipment.Length; i++)
            {
                if (PlayerEquipment[i].ID_Item == ID)
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

        public void DropItem(int Row)
        {
            PlayerEquipment[Row] = null;
        }

        public void Equip(Equipment item)
        {
           int Row = Convert.ToInt32(SearchBoth(item.Name));
            switch (item.Type)
            {
                case ("Two-Handed Weapon"):
                    PlayerInventory[Row] = null;
                    Unequip(0);
                    Unequip(1);
                    Unequip(2);
                    PlayerEquipment[0] = item;
                    PlayerEquipment[1] = null;
                    PlayerEquipment[2] = null;
                    break;

                case ("One-Handed Weapon"):
                    PlayerInventory[Row] = null;
                    Unequip(0);
                    Unequip(1);
                    PlayerEquipment[0] = null;
                    PlayerEquipment[1] = item;
                    break;

                case ("Shield"):
                    PlayerInventory[Row] = null;
                    Unequip(0);
                    Unequip(2);
                    PlayerEquipment[0] = null;
                    PlayerEquipment[2] = item;
                    break;

                case ("Helmet"):
                    PlayerInventory[Row] = null;
                    Unequip(3);
                    PlayerEquipment[3] = item;
                    break;

                case ("Chestplate"):
                    PlayerInventory[Row] = null;
                    Unequip(4);
                    PlayerEquipment[4] = item;
                    break;

                case ("Gauntlet"):
                    PlayerInventory[Row] = null;
                    Unequip(5);
                    PlayerEquipment[5] = item;
                    break;

                case ("Boots"):
                    PlayerInventory[Row] = null;
                    Unequip(6);
                    PlayerEquipment[6] = item;
                    break;

            }
        }

        public int GetStatFromSet(string Stat)
        {
            int Result = 0;
            int a;
            int b;
            int c;
            int d;
            int e;
            foreach (Equipment item in PlayerEquipment)
            {
                if (item == null)
                {
                    a = 0;
                    b = 0;
                    c = 0;
                    d = 0;
                    e = 0;
                }
                else 
                {
                    a = item.Damage;
                    b = item.Armor;
                    c = item.DamageReduction;
                    d = item.Agility;
                    e = item.Thorns;
                }

                switch (Stat)
                {
                    case ("Damage"):
                        Result = Result + a;
                        break;

                    case ("Armor"):
                        Result = Result + b;
                        break;

                    case ("DamageReduction"):
                        Result = Result + c;
                        break;

                    case ("Agility"):
                        Result = Result + d;
                        break;

                    case ("Thorns"):
                        Result = Result + e;
                        break;

                    default:
                        Result = Result + 0;
                       break;
                }
            }
            return Result;
        }
    }
}
