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
    public class Character
    {
        public int HP { get; set; } = 30;
        public int MaxHP { get; set; } = 30;
        public int Level { get; set; } = 1;
        public float Exp { get; set; } = 0;
        public int Attack_Damage { get; set; } = 5;
        public int Defense_Capacity { get; set; } = 4;
        public bool Defending { get; set; } = false;
        public int Dodge_Proficiency { get; set; } = 45;
        public bool Dodging { get; set; } = false;
        public int Special_Damage { get; set; } = 14;
        public int Special_Cooldown { get; set; } = 3;
        public int Thorns { get; set; } = 0;
        public bool Alive { get; set; } = true;
        public bool IsTurn { get; set; } = false;

        public void LevelUp()
        {
            int LastLevel = Level;
            int LevelsUp;

            if (Exp < 80)
            {
                Level = 1;
            }
            else
            {
                Level = 1 + Convert.ToInt32(Exp/60f*(1.0f+((Level - 1)/5.0f)));
                LevelsUp = LastLevel - Level;
                Attack_Damage = Attack_Damage + LevelsUp;
                Defense_Capacity = Defense_Capacity + ((LevelsUp) / 2);
                Special_Damage = Special_Damage + ((LevelsUp) / 2);
                MaxHP = MaxHP + (2 * (LevelsUp));
                Dodge_Proficiency = Dodge_Proficiency + ((LevelsUp) / 5);
            }
        }

        public void Attack(Character Target, Random random)
        {
            int Hit_prob = 0;
            Hit_prob = random.Next(0, 101);
            

            if (Alive && IsTurn)
            {
                if (Target.Dodging)
                {
                    if (Hit_prob >= Target.Dodge_Proficiency)
                    {
                        Target.HP = Target.HP - Attack_Damage;
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
                else if (Target.Defending)
                {
                    if ((Attack_Damage - Target.Defense_Capacity) > 0)
                    {
                        Target.HP = Target.HP - (Attack_Damage - Target.Defense_Capacity);
                    }
                    Target.Dodging = false;
                    Target.Defending = false;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
                else
                {
                    Target.HP = Target.HP - Attack_Damage;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
                Special_Cooldown = Special_Cooldown - 1;
                if (Target.HP <= 0)
                {
                    Target.Alive = false;
                }
            }  
        }
        public void SpecialAttack(Character Target, Random random)
        {
            int Hit_prob = random.Next(0, 101);
            if (Alive && IsTurn)
            {
                if (Target.Dodging)
                {
                    if (Hit_prob >= (Target.Dodge_Proficiency - 5))
                    {
                        Target.HP = Target.HP - Special_Damage;
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
                else if (Target.Defending)
                {
                    if ((Special_Damage - Target.Defense_Capacity) > 0)
                    {
                        Target.HP = Target.HP - (Special_Damage - Target.Defense_Capacity);
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
                else
                {
                    Target.HP = Target.HP - Special_Damage;
                    IsTurn = false;
                    Target.IsTurn = true;
                }
            }
            Special_Cooldown = 3;
            if (Target.HP <= 0)
            {
                Target.Alive = false;
            }
        }
        public void Dodge(Character Target)
        {
            if (Alive && IsTurn)
            {
                Dodging = true;
                Defending = false;
                Target.Defending = false;
                Target.Dodging = false;
                IsTurn = false;
                Target.IsTurn = true;
                Special_Cooldown = Special_Cooldown - 1;
            }

        }
        public void Defend(Character Target)
        {
            if (Alive && IsTurn)
            {
                Defending = true;
                Dodging = false;
                Target.Defending = false;
                Target.Dodging = false;
                IsTurn = false;
                Target.IsTurn = true;
                Special_Cooldown = Special_Cooldown - 1;
            }
        }
    }
}
