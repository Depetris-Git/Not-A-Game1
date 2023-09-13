using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego.BackEnd
{
    public class Character
    {
        public int HP { get; set; } = 30;
        public int MaxHP { get; set; } = 30;
        public int Attack_Damage { get; set; } = 5;
        public int Defense_Capacity { get; set; } = 4;
        public bool Defending { get; set; } = false;
        public int Dodge_Proficiency { get; set; } = 45;
        public bool Dodging { get; set; } = false;
        public int Special_Damage { get; set; } = 14;
        public int Special_Cooldown { get; set; } = 3;
        public bool Alive { get; set; } = true;
        public bool IsTurn { get; set; } = false;


        public void Attack(Character Attacker,Character Target, Random random)
        {
            int Hit_prob = 0;
            Hit_prob = random.Next(0, 101);
            

            if (Attacker.Alive && Attacker.IsTurn)
            {
                if (Target.Dodging)
                {
                    if (Hit_prob >= Target.Dodge_Proficiency)
                    {
                        Target.HP = Target.HP - Attacker.Attack_Damage;
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
                else if (Target.Defending)
                {
                    if ((Attacker.Attack_Damage - Target.Defense_Capacity) > 0)
                    {
                        Target.HP = Target.HP - (Attacker.Attack_Damage - Target.Defense_Capacity);
                    }
                    Target.Dodging = false;
                    Target.Defending = false;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
                else
                {
                    Target.HP = Target.HP - Attacker.Attack_Damage;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
                Attacker.Special_Cooldown = Attacker.Special_Cooldown - 1;
                if (Target.HP <= 0)
                {
                    Target.Alive = false;
                }
            }  
        }
        public void SpecialAttack(Character Attacker, Character Target, Random random)
        {
            int Hit_prob = random.Next(0, 101);
            if (Attacker.Alive && Attacker.IsTurn)
            {
                if (Target.Dodging)
                {
                    if (Hit_prob >= (Target.Dodge_Proficiency - 5))
                    {
                        Target.HP = Target.HP - Attacker.Special_Damage;
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
                else if (Target.Defending)
                {
                    if ((Attacker.Special_Damage - Target.Defense_Capacity) > 0)
                    {
                        Target.HP = Target.HP - (Attacker.Special_Damage - Target.Defense_Capacity);
                    }
                    Target.Defending = false;
                    Target.Dodging = false;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
                else
                {
                    Target.HP = Target.HP - Attacker.Special_Damage;
                    Attacker.IsTurn = false;
                    Target.IsTurn = true;
                }
            }
            Attacker.Special_Cooldown = 3;
            if (Target.HP <= 0)
            {
                Target.Alive = false;
            }
        }
        public void Dodge(Character Attacker, Character Target)
        {
            if (Attacker.Alive && Attacker.IsTurn)
            {
                Attacker.Dodging = true;
                Attacker.Defending = false;
                Target.Defending = false;
                Target.Dodging = false;
                Attacker.IsTurn = false;
                Target.IsTurn = true;
                Attacker.Special_Cooldown = Attacker.Special_Cooldown - 1;
            }

        }
        public void Defend(Character Attacker, Character Target)
        {
            if (Attacker.Alive && Attacker.IsTurn)
            {
                Attacker.Defending = true;
                Attacker.Dodging = false;
                Target.Defending = false;
                Target.Dodging = false;
                Attacker.IsTurn = false;
                Target.IsTurn = true;
                Attacker.Special_Cooldown = Attacker.Special_Cooldown - 1;
            }
        }
    }
}
