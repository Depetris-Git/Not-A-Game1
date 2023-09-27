using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Juego.BackEnd
{
    public class Equipment
    {
        public string Name { get; set; } = "";
        public int Damage { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public int DamageReduction { get; set; } = 0; // Only for shields or Special effects
        public string Type { get; set; } // Types: "One-handed weapon", "Two-handed weapon", "shield", "helmet", "chestplate", "gloves", "boots"
        public bool Equiped { get; set; } = false;

    }
}
