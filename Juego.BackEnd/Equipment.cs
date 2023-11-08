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
    public class Equipment
    {
        public string ID_Item { get; set; }
        public string Name { get; set; } = "";
        public int Damage { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public int Thorns { get; set; } = 0; // Only for shields and armor or Special effects. Damage enemy recieves when attacking you.
        public int Agility { get; set; } = 0;
        public int DamageReduction { get; set; } = 0; // Only for shields or Special effects
        public string Type { get; set; } // Types: "One-handed weapon", "Two-handed weapon", "Shield", "Helmet", "Chestplate", "Gauntlet", "Boots"
        public string Rarity { get; set; } // Rarities: "common", "rare", "legendary"
        public bool Equiped { get; set; } = false;

    }
}
