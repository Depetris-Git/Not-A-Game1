using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego.BackEnd
{
    public class Character
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Attack_Damage { get; set; }
        public int Defense_Capacity { get; set; }
        public int Dodge_Proficiency { get; set; }
        public int Special_Damage { get; set; }
        public int Special_Cooldown { get; set; }
        public bool Alive { get; set; }
        public bool IsTurn { get; set; }


    }

}
