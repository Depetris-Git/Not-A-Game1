using Juego.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerasClases
{
    public partial class Form1 : Form
    {
        Character enemy = new Character();
        Character player = new Character();
        Random random = new Random();

        bool Battle = true;
        int Turn = 1;
        int AttackCount = 0;
        int DefendCount = 0;
        int LastHP;
        

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
            Lb_Turn2.Visible = false;
            Lb_Cooldown.Visible = false;
            Bt_Pause.Visible = false;
            Bt_Help.Visible = false;
            ProBar_HP_Player.Visible = false;
            ProBar_HP_Enemy.Visible = false;
            PicBox_Enemy.Visible = false;
            PicBox_Player.Visible = false;
            Lb_Action.Visible = false;
            lbPause.Visible = false;
            Bt_Exit.Location = new System.Drawing.Point(348, 288);

        }

        private void Bt_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.None,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }
        }

        public void Bt_Play_Click(object sender, EventArgs e)
        {
            Lb_Turn.Visible = true;
            Bt_Pause.Visible = true;
            Bt_Help.Visible = true;
            Lb_Title.Visible = false;
            Bt_Play.Visible = false;
            Lb_Turn.Text = "Wait until game begins";

            Bt_Exit.Location = new System.Drawing.Point(671, 364);

            player.Special_Cooldown = 2;
            player.IsTurn = true;

            TimerLoop.Start();
        }

        private void Bt_Pause_Click(object sender, EventArgs e)
        {
            if (TimerLoop.Enabled == true)
            {
                TimerLoop.Enabled = false;
                Bt_Attack.Visible = false;
                Bt_Defend.Visible = false;
                Bt_Dodge.Visible = false;
                Bt_Special.Visible = false;
                Lb_Cooldown.Visible = false;
                lbPause.Visible = true;
                Bt_Pause.Text = "Resume";

            }
            else
            {
                TimerLoop.Enabled = true;
                Bt_Attack.Visible = true;
                Bt_Defend.Visible = true;
                Bt_Dodge.Visible = true;
                Bt_Special.Visible = true;
                Lb_Cooldown.Visible = true;
                lbPause.Visible = false;
                Bt_Pause.Text = "Pause";
            }
        }


        private void Bt_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attack: Attack the enemy\n\r" +
                "Defend: Reduce damage of enemy attack next turn\n\r" +
                "Dodge: Probability of entierly dodging attack next turn\n\r" +
                "Special: Strong attack. It is better than basic attack, so it has cooldown\n\r" + "\n\r" +
                "Put cursor over action buttons to see the stats.",
                "Game Instructions");
        }


        public async void Bt_Attack_Click(object sender, EventArgs e)
        {
            if (player.IsTurn)
            {
                LastHP = enemy.HP;
                player.Attack(player, enemy, random);

                if (LastHP == enemy.HP)
                {
                    Lb_Action.Text = "Dodged!";
                    Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                    | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                    Lb_Action.Location = new System.Drawing.Point(360, 80);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
                else
                {
                    Lb_Action.Text = (enemy.HP - LastHP).ToString();
                    Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.Red;
                    Lb_Action.Location = new System.Drawing.Point(490, 137);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
            }

            if (enemy.HP > 0)
            {
                ProBar_HP_Enemy.Value = enemy.HP;
                Lb_Enemy_HP.Text = "HP: " + enemy.HP.ToString() + "/" + enemy.MaxHP.ToString();
            }
            else
            {
                ProBar_HP_Enemy.Value = 0;
                Lb_Enemy_HP.Text = "HP: 0/" + enemy.MaxHP.ToString();
                enemy.Alive = false;
            }

            if (player.Special_Cooldown <= 0)
            {
                Lb_Cooldown.Text = "Special ready!";
            }
            else
            {
                Lb_Cooldown.Text = "Cooldown: " + player.Special_Cooldown.ToString();
            }
        }
        private async void Bt_Defend_Click(object sender, EventArgs e)
        {
            if (player.IsTurn)
            {
                player.Defend(player, enemy);

                Lb_Action.Text = "Defending!";
                Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                Lb_Action.Top = 70;
                Lb_Action.Left = 330;
                Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                Lb_Action.Visible = true;
                await Task.Delay(1200);
                Lb_Action.Visible = false;
            }

            if (player.Special_Cooldown <= 0)
            {
                Lb_Cooldown.Text = "Special ready!";
            }
            else
            {
                Lb_Cooldown.Text = "Cooldown: " + player.Special_Cooldown.ToString();
            }
        }

        private async void Bt_Dodge_Click(object sender, EventArgs e)
        {
            if (player.IsTurn)
            {
                player.Dodge(player, enemy);

                Lb_Action.Text = "You are prepared to Dodge!";
                Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                Lb_Action.Location = new System.Drawing.Point(266, 80);
                Lb_Action.Visible = true;
                await Task.Delay(1200);
                Lb_Action.Visible = false;
            }

            if (player.Special_Cooldown <= 0)
            {
                Lb_Cooldown.Text = "Special ready!";
            }
            else
            {
                Lb_Cooldown.Text = "Cooldown: " + player.Special_Cooldown.ToString();
            }

        }

        private async void Bt_Special_Click(object sender, EventArgs e)
        {
            if (player.IsTurn)
            {

            }
            if (player.Special_Cooldown <= 0)
            {
                LastHP = enemy.HP;
                player.SpecialAttack(player, enemy, random);


                if (LastHP == enemy.HP)
                {
                    Lb_Action.Text = "Special Dodged!";
                    Lb_Action.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.MediumVioletRed;
                    Lb_Action.Location = new System.Drawing.Point(256, 80);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
                else
                {
                    Lb_Action.Text = (enemy.HP - LastHP).ToString();
                    Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.Red;
                    Lb_Action.Location = new System.Drawing.Point(490, 137);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }

                if (enemy.HP > 0)
                {
                    ProBar_HP_Enemy.Value = enemy.HP;
                    Lb_Enemy_HP.Text = "HP: " + enemy.HP.ToString() + "/" + enemy.MaxHP.ToString();
                }
                else
                {
                    ProBar_HP_Enemy.Value = 0;
                    Lb_Enemy_HP.Text = "HP: 0/" + enemy.MaxHP.ToString();
                    enemy.Alive = false;
                }

                if (player.Special_Cooldown <= 0)
                {
                    Lb_Cooldown.Text = "Special ready!";
                }
                else
                {
                    Lb_Cooldown.Text = "Cooldown: " + player.Special_Cooldown.ToString();
                }
            }
            else
            {
                await Task.Delay(60);
                MessageBox.Show("Your Special Move is still in cooldown.");
            }

        }

        //Game loop made with a timer
        private async void MyTimer_Tick(object sender, EventArgs e)
        {
            Lb_Turn.Location = new System.Drawing.Point(346, 10);
            Bt_Attack.Visible = true;
            Bt_Defend.Visible = true;
            Bt_Dodge.Visible = true;
            Bt_Special.Visible = true;
            Lb_Enemy_HP.Visible = true;
            Lb_Player_HP.Visible = true;
            ProBar_HP_Player.Visible = true;
            ProBar_HP_Enemy.Visible = true;
            PicBox_Enemy.Visible = true;
            PicBox_Player.Visible = true;
            Lb_Turn2.Visible = true;
            Lb_Cooldown.Visible = true;
            ProBar_HP_Player.Maximum = player.MaxHP;
            ProBar_HP_Enemy.Maximum = enemy.MaxHP;
            if (player.HP <= 0)
            {
                ProBar_HP_Player.Value = 0;
                Lb_Player_HP.Text = "HP: 0/" + player.MaxHP.ToString();
            }
            else
            {
                ProBar_HP_Player.Value = player.HP;
                Lb_Player_HP.Text = "HP: " + player.HP.ToString() + "/" + player.MaxHP.ToString();
            }

            if (enemy.HP <= 0)
            {
                ProBar_HP_Enemy.Value = 0;
                Lb_Enemy_HP.Text = "HP: 0/" + enemy.MaxHP.ToString();
            }
            else 
            {
                ProBar_HP_Enemy.Value = enemy.HP;
                Lb_Enemy_HP.Text = "HP: " + enemy.HP.ToString() + "/" + enemy.MaxHP.ToString();
            }

            if (player.Special_Cooldown <= 0)
            {
                Lb_Cooldown.Text = "Special ready!";
            }
            else
            {
                Lb_Cooldown.Text = "Cooldown: " + player.Special_Cooldown.ToString();
            }

            if (player.IsTurn)
            {
                Lb_Turn.Text = "Player's turn";
                Lb_Turn2.Text = Turn.ToString();
            }
            else
            {
                Lb_Turn.Text = "Enemy's turn";
                Lb_Turn2.Text = Turn.ToString();
            }


            //Enemy's "AI"
            if (enemy.Alive && enemy.IsTurn)
            {
                //Turn = Turn + 1;
                Lb_Turn.Text = "Enemy's turn";
                Lb_Turn2.Text = Turn.ToString();
                await Task.Delay(1200);
                if (enemy.Special_Cooldown <= 0)
                {
                    LastHP = player.HP;
                    enemy.SpecialAttack(enemy, player, random);

                    if (LastHP == player.HP)
                    {
                        Lb_Action.Text = "Special Dodged!";
                        Lb_Action.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Gold;
                        Lb_Action.Location = new System.Drawing.Point(256, 80);
                        Lb_Action.Visible = true;
                        await Task.Delay(1200);
                        Lb_Action.Visible = false;
                    }
                    else
                    {
                        Lb_Action.Text = (player.HP - LastHP).ToString();
                        Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Red;
                        Lb_Action.Location = new System.Drawing.Point(282, 138);
                        Lb_Action.Visible = true;
                        await Task.Delay(1200);
                        Lb_Action.Visible = false;
                    }
                }
                else if (player.Special_Cooldown == 0 || DefendCount >= 1)
                {
                    enemy.Dodge(enemy, player);
                    DefendCount = 0;

                    Lb_Action.Text = "Enemy prepared to Dodge!";
                    Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                    | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                    Lb_Action.Location = new System.Drawing.Point(274, 80);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
                else if (AttackCount >= 2)
                {
                    enemy.Defend(enemy, player);
                    AttackCount = 0;
                    DefendCount = DefendCount + 1;

                    Lb_Action.Text = "Enemy is Defending!";
                    Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                    Lb_Action.Location = new System.Drawing.Point(270, 90);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
                else
                {
                    LastHP = player.HP;
                    enemy.Attack(enemy, player, random);
                    AttackCount++;
                    if (LastHP == player.HP)
                    {
                        Lb_Action.Text = "Dodged!";
                        Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                        | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                        Lb_Action.Location = new System.Drawing.Point(360, 80);
                        Lb_Action.Visible = true;
                        await Task.Delay(1200);
                        Lb_Action.Visible = false;
                    }
                    else
                    {
                        Lb_Action.Text = (player.HP - LastHP).ToString();
                        Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Red;
                        Lb_Action.Location = new System.Drawing.Point(282, 138);
                        Lb_Action.Visible = true;
                        await Task.Delay(1200);
                        Lb_Action.Visible = false;
                    }
                    if (player.HP > 0)
                    {
                        ProBar_HP_Player.Value = player.HP;
                        Lb_Player_HP.Text = "HP: " + player.HP.ToString() + "/" + player.MaxHP.ToString();
                    }
                    else
                    {
                        ProBar_HP_Player.Value = 0;
                        Lb_Player_HP.Text = "HP: 0/" + player.MaxHP.ToString();
                        player.Alive = false;
                    }
                }
                Turn = Turn + 1;

                if (player.IsTurn)
                {
                    Lb_Turn.Text = "Player's turn";
                    Lb_Turn2.Text = Turn.ToString();
                }
                else
                {
                    Lb_Turn.Text = "Enemy's turn";
                    Lb_Turn2.Text = Turn.ToString();
                }
            }
            if (Battle && enemy.Alive == false)
            {
                Battle = false;
                TimerLoop.Stop();
                TimerLoop.Enabled = false;
                MessageBox.Show("YOU\n\rWIN", "Congratulations!");
            }

            if (Battle && player.Alive == false)
            {
                Battle = false;
                TimerLoop.Stop();
                TimerLoop.Enabled = false;
                MessageBox.Show("YOU\n\rDIED", "Try Again!");
            }
        }

    }
}
