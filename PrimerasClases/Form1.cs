using Juego.BackEnd;
using PrimerasClases.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerasClases
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        Character enemy = new Character();
        Character player = new Character();
        Equipment basicChestplate = new Equipment();
        Equipment basicBoots = new Equipment();
        Equipment basicWeapon = new Equipment();
        Equipment basicGauntlet = new Equipment();
        Equipment basicHelmet = new Equipment();
        Equipment basicShield = new Equipment();
        Equipment basicTwoHandedWeapon = new Equipment();
        Equipment spikeShield = new Equipment();
        Equipment magicChestplate = new Equipment();
        Equipment magicBoots = new Equipment();
        Equipment magicWeapon = new Equipment();
        Equipment magicGauntlet = new Equipment();
        Equipment magicHelmet = new Equipment();
        Equipment magicShield = new Equipment();
        Equipment magicTwoHandedWeapon = new Equipment();
        Equipment legendaryChestplate = new Equipment();
        Equipment legendaryBoots = new Equipment();
        Equipment legendaryWeapon = new Equipment();
        Equipment legendaryGauntlet = new Equipment();
        Equipment legendaryHelmet = new Equipment();
        Equipment legendaryShield = new Equipment();
        Equipment legendaryTwoHandedWeapon = new Equipment();

        Icon GauntletCursor = Resources.GauntletIcon;
        Icon SwordCursor = Resources.SwordIcon;


        /*  private void GenerateEquipment(NameNewEquipment)    traté de hacer un método que creara un ítem desde el comienzo
            {                                                   sin que tenga que declarar manualmente "new Equipment()", pero no lo logré
                NameNewEquipment = new Equipment();
            }
        */
        public void FillEquipmentStats(Equipment equipment, 
                                       string rarity,string name, 
                                       int damage, int armor, string type, 
                                       int damageReduction = 0, int thorns = 0, int agility = 0)
        {
            equipment.Rarity = rarity;
            equipment.Name = name;
            equipment.Damage = damage;
            equipment.Armor = armor;
            equipment.Type = type;
            equipment.DamageReduction = damageReduction;
            equipment.Thorns = thorns;
            equipment.Agility = agility;
        }

        bool Battle = false;
        int Turn = 1;
        int AttackC = 0;
        int DefendC = 0;
        int SpecialC = 0;
        int DodgeC = 0;
        int SpecialDodgeC = 0;
        int AttackCE = 0;
        int DefendCE = 0;
        int LastHP;
        int LastLevel;
        bool PauseOn = false;

        public Form1()
        {
            InitializeComponent();

           /* string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources";
            Gauntlet = new Cursor($"{cursorDirectory}\\Gauntlet1.cur");
            this.Cursor = Gauntlet;
           
            Intenté poner un cursor personalizado pero sale sin color, completamente negro.
           */          

            FillEquipmentStats(basicWeapon, "common","Basic Sword", 4, 0, "One-Handed Weapon");
            FillEquipmentStats(basicChestplate, "common", "Basic Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(basicBoots, "common", "Basic Boots", 0, 1, "Boots");
            FillEquipmentStats(basicGauntlet, "common", "Basic Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(basicHelmet, "common", "Basic Helmet", 0, 1, "Helmet");
            FillEquipmentStats(basicShield, "common", "Basic Shield", 0, 0, "Shield", 3);
            FillEquipmentStats(basicTwoHandedWeapon, "common", "Basic Zweinhander", 6, 0, "Two-Handed Weapon");
            FillEquipmentStats(spikeShield, "common", "Spiked Shield", 0, 0, "Shield", 3, 1);
            FillEquipmentStats(magicWeapon, "rare", "Magic Sword", 6, 0, "One-Handed Weapon");
            FillEquipmentStats(magicChestplate, "rare", "Magic Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(magicBoots, "rare", "Magic Boots", 0, 1, "Boots", 0, 0, 1);
            FillEquipmentStats(magicGauntlet, "rare", "Magic Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(magicHelmet, "rare", "Magic Helmet", 0, 1, "Helmet");
            FillEquipmentStats(magicShield, "rare", "Magic Shield", 0, 1, "Shield", 4);
            FillEquipmentStats(magicTwoHandedWeapon, "rare", "Magic Zweinhander", 7, 0, "Two-Handed Weapon");
            FillEquipmentStats(legendaryWeapon, "legendary", "Legendary Sword", 7, 0, "One-Handed Weapon");
            FillEquipmentStats(legendaryChestplate, "legendary", "Legendary Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(legendaryBoots, "legendary", "Legendary Boots", 0, 1, "Boots", 0, 0, 3);
            FillEquipmentStats(legendaryGauntlet, "legendary", "Legendary Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(legendaryHelmet, "legendary", "Legendary Helmet", 0, 1, "Helmet");
            FillEquipmentStats(legendaryShield, "legendary", "Legendary Shield", 0, 2, "Shield", 6);
            FillEquipmentStats(legendaryTwoHandedWeapon, "legendary", "Legendary Zweinhander", 9, 0, "Two-Handed Weapon");

            Lb_Title.Parent = PicBox_TitleScreen;
            label1.Parent = PicBox_TitleScreen;
            label2.Parent = PicBox_TitleScreen;
            Lb_Turn.Parent = PicBox_TitleScreen;
            PicBox_Enemy.Parent = PicBox_FightBackground;
            PicBox_Player.Parent = PicBox_FightBackground;
            Lb_Enemy_HP.Parent = PicBox_FightBackground;
            Lb_Player_HP.Parent = PicBox_FightBackground;
            Lb_Turn2.Parent = PicBox_FightBackground;
            lbPause.Parent = PicBox_FightBackground;
            Lb_Action.Parent = PicBox_FightBackground;
            Lb_Cooldown.Parent = PicBox_FightBackground;

            PicBox_FightBackground.Visible = false;
            Bt_Exit.Visible = false;
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
            Bt_Inventory.Visible = false;
            Bt_Pause.Visible = false;
            Bt_Help.Visible = false;
            Bt_Exit.Location = new System.Drawing.Point(348, 288);

            this.Cursor = new Cursor(GauntletCursor.Handle);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Lb_Turn.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            Bt_Exit.Visible = false;
            Lb_Title.Visible = false;
            Lb_Turn.Text = "Wait until game begins";
            Lb_Turn.Location = new System.Drawing.Point(288, 18);

            player.Special_Cooldown = 2;
            player.IsTurn = true;

            TimerLoop.Start();
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(GauntletCursor.Handle);
            this.label1.Location = new System.Drawing.Point(490, 102);
            label1.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //this.Cursor = new Cursor(SwordCursor.Handle);
            this.label1.Location = new System.Drawing.Point(500, 107);
            label1.Font = new System.Drawing.Font("Castellar", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(GauntletCursor.Handle);
            this.label2.Location = new System.Drawing.Point(494, 140);
            label2.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //this.Cursor = new Cursor(SwordCursor.Handle);
            this.label2.Location = new System.Drawing.Point(504, 145);
            label2.Font = new System.Drawing.Font("Castellar", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private void Bt_Invenitory_Click(object sender, EventArgs e)
        {
            Bt_Attack.Visible = false;
            Bt_Defend.Visible = false;
            Bt_Dodge.Visible = false;
            Bt_Special.Visible = false;
            Lb_Cooldown.Visible = false;
            Bt_Pause.Visible = false;
            Bt_Inventory.Visible = false;
            Bt_Help.Visible = false;
            ProBar_HP_Player.Visible = false;
            ProBar_HP_Enemy.Visible = false;
            GrBox_Inventory.Visible = true;
        }
        private void Bt_ExitGrBox_Click(object sender, EventArgs e)
        {
            GrBox_Inventory.Visible = false;
            if (PauseOn == false && player.IsTurn && Battle)
            {
                Bt_Attack.Visible = true;
                Bt_Defend.Visible = true;
                Bt_Dodge.Visible = true;
                Bt_Special.Visible = true;
                Lb_Cooldown.Visible = true;
            }
            Bt_Pause.Visible = true;
            Bt_Inventory.Visible = true;
            Bt_Help.Visible = true;
            ProBar_HP_Player.Visible = true;
            ProBar_HP_Enemy.Visible = true;
        }

        private void Bt_Pause_Click(object sender, EventArgs e)
        {
            if (PauseOn == false)
            {
                TimerLoop.Enabled = false;
                Bt_Attack.Visible = false;
                Bt_Defend.Visible = false;
                Bt_Dodge.Visible = false;
                Bt_Special.Visible = false;
                Lb_Cooldown.Visible = false;
                lbPause.Visible = true;
                Bt_Pause.Text = "Resume";
                PauseOn = true;

            }
            else
            {
                if (Battle)
                {
                    TimerLoop.Enabled = true;
                }
                Bt_Attack.Visible = true;
                Bt_Defend.Visible = true;
                Bt_Dodge.Visible = true;
                Bt_Special.Visible = true;
                Lb_Cooldown.Visible = true;
                lbPause.Visible = false;
                Bt_Pause.Text = "Pause";
                PauseOn = false;
            }
        }

        private void Bt_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attack: Attack the enemy\n\r" +
                "Defend: Reduce damage of enemy attack next turn\n\r" +
                "Dodge: Probability of entierly dodging attack next turn\n\r" +
                "Special: Strong attack. Does more damage than basic attack, so it has cooldown\n\r" + "\n\r" +
                "Move cursor over action buttons to see the stats.",
                "Game Instructions");
        }

        #region Action Buttons
        public async void Bt_Attack_Click(object sender, EventArgs e)
        {
            if (player.IsTurn && Battle)
            {
                LastHP = enemy.HP;
                player.Attack(enemy, random);

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
                    AttackC = AttackC + 1;
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
            if (player.IsTurn && Battle)
            {
                player.Defend(enemy);
                DefendC = DefendC + 1;
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
            if (player.IsTurn && Battle)
            {
                player.Dodge(enemy);

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
            if (player.IsTurn && Battle)
            {

            }
            if (player.Special_Cooldown <= 0)
            {
                LastHP = enemy.HP;
                player.SpecialAttack(enemy, random);

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
                    Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        #endregion

        private async void MyTimer_Tick(object sender, EventArgs e)
        {
            if (player.IsTurn && Lb_Action.Visible == false && GrBox_Inventory.Visible == false)
            {
                Bt_Attack.Visible = true;
                Bt_Defend.Visible = true;
                Bt_Dodge.Visible = true;
                Bt_Special.Visible = true;
                Lb_Cooldown.Visible = true;
            }

            Lb_Turn.Parent = PicBox_FightBackground;
            Lb_Turn.ForeColor = Color.White;
            PicBox_TitleScreen.Visible = false;
            PicBox_FightBackground.Visible = true;
            Bt_Exit.Location = new System.Drawing.Point(671, 364);
            Lb_Turn.Location = new System.Drawing.Point(346, 10);
            Bt_Exit.Visible = true;
            Lb_Enemy_HP.Visible = true;
            Lb_Player_HP.Visible = true;
            Lb_Turn2.Visible = true;
            ProBar_HP_Player.Maximum = player.MaxHP;
            ProBar_HP_Enemy.Maximum = enemy.MaxHP;

            if (Battle == false && enemy.Alive && player.Alive)
            {
                player.HP = player.MaxHP;
                enemy.HP = enemy.MaxHP;
                enemy.IsTurn = false;
                player.IsTurn = true;
                Bt_Attack.Visible = true;
                Bt_Defend.Visible = true;
                Bt_Dodge.Visible = true;
                Bt_Special.Visible = true;
                Lb_Cooldown.Visible = true;
                Bt_Inventory.Visible = true;
                Bt_Pause.Visible = true;
                Bt_Help.Visible = true;
                ProBar_HP_Player.Visible = true;
                ProBar_HP_Enemy.Visible = true;
                PicBox_Enemy.Visible = true;
                PicBox_Player.Visible = true;
                Battle = true;
            }

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

            if (enemy.IsTurn)
            {
                Bt_Attack.Visible = false;
                Bt_Defend.Visible = false;
                Bt_Dodge.Visible = false;
                Bt_Special.Visible = false;
                Lb_Cooldown.Visible = false;
            }

            //Enemy's "AI"
            if (enemy.Alive && enemy.IsTurn && Lb_Action.Visible == false)
            {
                Lb_Turn.Text = "Enemy's turn";
                Lb_Turn2.Text = Turn.ToString();
                await Task.Delay(1200);
                if (enemy.Special_Cooldown <= 0)
                {
                    LastHP = player.HP;
                    enemy.SpecialAttack(player, random);

                    if (LastHP == player.HP)
                    {
                        SpecialDodgeC = SpecialDodgeC + 1;
                        Lb_Action.Text = "Special Dodged!";
                        Lb_Action.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Gold;
                        Lb_Action.Location = new System.Drawing.Point(256, 80);
                        Lb_Action.Visible = true;
                        Refresh();
                        await Task.Delay(500);
                    }
                    else
                    {
                        Lb_Action.Text = (player.HP - LastHP).ToString();
                        Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Red;
                        Lb_Action.Location = new System.Drawing.Point(282, 138);
                        Lb_Action.Visible = true;
                        Refresh();
                        await Task.Delay(1000);
                    }
                    Lb_Action.Visible = false;
                }
                else if (player.Special_Cooldown == 0 || DefendCE >= 1)
                {
                    enemy.Dodge(player);
                    DefendCE = 0;

                    Lb_Action.Text = "Enemy prepared to Dodge!";
                    Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                    | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                    Lb_Action.Location = new System.Drawing.Point(274, 80);
                    Lb_Action.Visible = true;
                    Refresh();
                    await Task.Delay(500);
                    Lb_Action.Visible = false;
                }
                else if (AttackCE >= 1 && (player.Attack_Damage - enemy.Defense_Capacity) < enemy.HP)
                {
                    enemy.Defend(player);
                    AttackCE = 0;
                    DefendCE = DefendCE + 1;

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
                    enemy.Attack(player, random);
                    AttackCE++;
                    if (LastHP == player.HP)
                    {
                        DodgeC = DodgeC + 1;
                        Lb_Action.Text = "Dodged!";
                        Lb_Action.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold
                        | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.LightSeaGreen;
                        Lb_Action.Location = new System.Drawing.Point(360, 80);
                        Lb_Action.Visible = true;
                        Refresh();
                        await Task.Delay(500);
                        Lb_Action.Visible = false;
                    }
                    else
                    {
                        Lb_Action.Text = (player.HP - LastHP).ToString();
                        Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Red;
                        Lb_Action.Location = new System.Drawing.Point(282, 138);
                        Lb_Action.Visible = true;
                        Refresh();
                        await Task.Delay(1000);
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
                player.Exp = (player.Exp + (56 * enemy.Level)) + (AttackC * 6) + (DefendC * 4) + (DodgeC * 10) + (SpecialDodgeC * 25) + (SpecialC * 20);
                MessageBox.Show(" YOU WIN\n\rExp Gained: " + (player.Exp).ToString(),
                "Congratulations!");
                AttackC = 0;
                DefendC = 0;
                DodgeC = 0;
                SpecialDodgeC = 0;
                SpecialC = 0;
                AttackCE = 0;
                DefendCE = 0;
                LastLevel = player.Level;
                player.LevelUp();
                if ((player.Level - LastLevel) > 0)
                {
                    MessageBox.Show("You leveled up " + (player.Level - LastLevel).ToString() + " levels!\n\r" +
                        "Exp: " + player.Exp.ToString() + "/" + (player.Exp + (60 * (1.0 + (LastLevel - 1 / 5.0)))).ToString(),
                        "Level Up");
                }
            }

            if (Battle && player.Alive == false)
            {
                Battle = false;
                TimerLoop.Stop();
                TimerLoop.Enabled = false;
                AttackC = 0;
                DefendC = 0;
                DodgeC = 0;
                SpecialDodgeC = 0;
                SpecialC = 0;
                AttackCE = 0;
                DefendCE = 0;
                MessageBox.Show("  YOU DIED", "Try Again!");
            }
        }
    }
}
