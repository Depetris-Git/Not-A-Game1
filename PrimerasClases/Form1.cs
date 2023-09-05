using Juego.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerasClases
{
    public partial class Form1 : Form
    {
        int P_MaxHP = 30;
        int P_HP = 30;
        int P_Attack_Damage = 7;
        int P_Defense_Capacity = 4;
        int P_Dodge_Proficiency = 50;
        int P_Special_Damage = 15;
        int P_Special_Cooldown = 3;
        bool P_IsTurn = true;
        bool P_Alive = true;
        int E_MaxHP = 30;
        int E_HP = 30;
        int E_Attack_Damage = 5;
        int E_Defense_Capacity = 6;
        int E_Dodge_Proficiency = 50;
        int E_Special_Damage = 15;
        int E_Special_Cooldown = 3;
        bool E_IsTurn = false;
        bool E_Alive = true;


        public Form1()
        {
            InitializeComponent();

            Bt_Attack.Visible = false;
            Bt_Defend.Visible = false;
            Bt_Dodge.Visible = false;
            Bt_Special.Visible = false;
            Lb_Enemy_HP.Visible = false;
            Lb_Player_HP.Visible = false;
            Lb_Turn.Visible = false;
            Lb_Cooldown.Visible = false;
            Bt_Pause.Visible = false;
            Bt_Help.Visible = false;
            ProBar_HP_Player.Visible = false;
            ProBar_HP_Enemy.Visible = false;
            PicBox_Enemy.Visible = false;
            PicBox_Player.Visible = false;
            Lb_Exit_message.Visible = false;
            Bt_Exit_no.Visible = false;
            Bt_Exit_yes.Visible = false;
            Bt_Exit.Location = new System.Drawing.Point(348, 288);
        }
        
        private void Bt_Exit_Click(object sender, EventArgs e)
        {
            Bt_Exit.Visible = false;
            Bt_Attack.Visible = false;
            Bt_Defend.Visible = false;
            Bt_Dodge.Visible = false;
            Bt_Special.Visible = false;
            Lb_Enemy_HP.Visible = false;
            Lb_Player_HP.Visible = false;
            Lb_Turn.Visible = false;
            Lb_Cooldown.Visible = false;
            Bt_Pause.Visible = false;
            Bt_Help.Visible = false;
            ProBar_HP_Player.Visible = false;
            ProBar_HP_Enemy.Visible = false;
            PicBox_Enemy.Visible = false;
            PicBox_Player.Visible = false;
            Lb_Exit_message.Visible = true;
            Bt_Exit_no.Visible = true;
            Bt_Exit_yes.Visible = true;
        }

        public void Bt_Play_Click(object sender, EventArgs e)
        {

            Bt_Attack.Visible = true;
            Bt_Defend.Visible = true;
            Bt_Dodge.Visible = true;
            Bt_Special.Visible = true;
            Lb_Enemy_HP.Visible = true;
            Lb_Player_HP.Visible = true;
            Lb_Turn.Visible = true;
            Lb_Cooldown.Visible = true;
            Bt_Pause.Visible = true;
            Bt_Help.Visible = true;
            ProBar_HP_Player.Visible = true;
            ProBar_HP_Enemy.Visible = true;
            PicBox_Enemy.Visible = true;
            PicBox_Player.Visible = true;
            Lb_Title.Visible = false;
            Bt_Play.Visible = false;

            Bt_Exit.Location = new System.Drawing.Point(671, 364);

            Character player = new Character();
            player.MaxHP = P_MaxHP;
            player.HP = P_HP;
            player.Attack_Damage = P_Attack_Damage;
            player.Defense_Capacity = P_Defense_Capacity;
            player.Dodge_Proficiency = P_Dodge_Proficiency;
            player.Special_Damage = P_Special_Damage;
            player.Special_Cooldown = P_Special_Cooldown;
            player.IsTurn = P_IsTurn;
            player.Alive = P_Alive;

            Character enemy = new Character();
            enemy.MaxHP = E_MaxHP;
            enemy.HP = E_HP;
            enemy.Attack_Damage = E_Attack_Damage;
            enemy.Defense_Capacity = E_Defense_Capacity;
            enemy.Dodge_Proficiency = E_Dodge_Proficiency;
            enemy.Special_Damage = E_Special_Damage;
            enemy.Special_Cooldown = E_Special_Cooldown;
            enemy.IsTurn = E_IsTurn;
            enemy.Alive = E_Alive;

            Lb_Enemy_HP.Text = "HP: "+enemy.HP.ToString()+"/"+enemy.MaxHP.ToString();
            Lb_Player_HP.Text = "HP: " + player.HP.ToString() + "/" + player.MaxHP.ToString();
            ProBar_HP_Enemy.Maximum = enemy.MaxHP;
            ProBar_HP_Enemy.Value = enemy.HP;
            ProBar_HP_Player.Maximum = player.MaxHP;
            ProBar_HP_Player.Value = player.HP;

            if (player.Special_Cooldown <= 0)
            {
                Lb_Cooldown.Text = "Special ready";
            }
            else
            {
                Lb_Cooldown.Text = "Cooldown: "+player.Special_Cooldown.ToString();
            }
        }
        public void Bt_Attack_Click(object sender, EventArgs e)
        {
            Character player = new Character();
            player.MaxHP = P_MaxHP;
            player.HP = P_HP;
            player.Attack_Damage = P_Attack_Damage;
            player.Defense_Capacity = P_Defense_Capacity;
            player.Dodge_Proficiency = P_Dodge_Proficiency;
            player.Special_Damage = P_Special_Damage;
            player.Special_Cooldown = P_Special_Cooldown;
            player.IsTurn = P_IsTurn;
            player.Alive = P_Alive;

            Character enemy = new Character();
            enemy.MaxHP = E_MaxHP;
            enemy.HP = E_HP;
            enemy.Attack_Damage = E_Attack_Damage;
            enemy.Defense_Capacity = E_Defense_Capacity;
            enemy.Dodge_Proficiency = E_Dodge_Proficiency;
            enemy.Special_Damage = E_Special_Damage;
            enemy.Special_Cooldown = E_Special_Cooldown;
            enemy.IsTurn = E_IsTurn;
            enemy.Alive = E_Alive;

            enemy.HP = enemy.HP - player.Attack_Damage;
        }

        private void Bt_Pause_Click(object sender, EventArgs e)
        {

        }

        private void Bt_Exit_yes_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void Bt_Exit_no_Click(object sender, EventArgs e)
        {
            Bt_Exit.Visible = true;
            Bt_Attack.Visible = true;
            Bt_Defend.Visible = true;
            Bt_Dodge.Visible = true;
            Bt_Special.Visible = true;
            Lb_Enemy_HP.Visible = true;
            Lb_Player_HP.Visible = true;
            Lb_Turn.Visible = true;
            Lb_Cooldown.Visible = true;
            Bt_Pause.Visible = true;
            Bt_Help.Visible = true;
            ProBar_HP_Player.Visible = true;
            ProBar_HP_Enemy.Visible = true;
            PicBox_Enemy.Visible = true;
            PicBox_Player.Visible = true;
            Lb_Exit_message.Visible = false;
            Bt_Exit_no.Visible = false;
            Bt_Exit_yes.Visible = false;
        }
    }
}
