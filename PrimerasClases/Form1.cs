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
        Inventory gameInventory = new Inventory();
        Inventory playerInventory = new Inventory();
        Inventory enemyInventory = new Inventory();
        Icon GauntletCursor = Resources.GauntletCursorIcon;
        //Icon SwordCursor = Resources.SwordCursorIcon;


        /*  private void GenerateEquipment(NameNewEquipment)    traté de hacer un método que creara un ítem desde el comienzo
            {                                                   sin que tenga que declarar manualmente "new Equipment()", pero no lo logré
                NameNewEquipment = new Equipment();
            } 
        */

        Equipment[] DropList = new Equipment[4];
        bool WasDodging;
        bool EnemyWasDodging;
        public void FillEquipmentStats(Equipment equipment, string ID, 
                                       string rarity,string name, 
                                       int damage, int armor, string type, 
                                       int damageReduction = 0, int thorns = 0, int agility = 0)
        {
            equipment.ID_Item = ID;
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

        int equipm;
        int inven;

        public Form1()
        {
            InitializeComponent();

            /* string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources";
             Gauntlet = new Cursor($"{cursorDirectory}\\Gauntlet1.cur");
             this.Cursor = Gauntlet;

             Intenté poner un cursor personalizado pero sale sin color, completamente negro.
            */

            playerInventory.PlayerEquipment = new Equipment[7];
            playerInventory.PlayerInventory = new Equipment[12];
            enemyInventory.PlayerEquipment = new Equipment[7];
            enemyInventory.PlayerInventory = new Equipment[12];
            gameInventory.PlayerInventory = new Equipment[50];

            FillEquipmentStats(basicWeapon, "0000001", "common","Basic Sword", 4, 0, "One-Handed Weapon");
            FillEquipmentStats(basicChestplate, "0000010", "common", "Basic Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(basicBoots, "0000100", "common", "Basic Boots", 0, 1, "Boots");
            FillEquipmentStats(basicGauntlet, "0001000", "common", "Basic Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(basicHelmet, "0010000", "common", "Basic Helmet", 0, 1, "Helmet");
            FillEquipmentStats(basicShield, "0100000", "common", "Basic Shield", 0, 0, "Shield", 3);
            FillEquipmentStats(basicTwoHandedWeapon, "1000000", "common", "Basic Zweinhander", 6, 0, "Two-Handed Weapon");
            FillEquipmentStats(spikeShield, "0400000", "common", "Spiked Shield", 0, 0, "Shield", 3, 1);
            FillEquipmentStats(magicWeapon, "0000002", "rare", "Magic Sword", 6, 0, "One-Handed Weapon");
            FillEquipmentStats(magicChestplate, "0000020", "rare", "Magic Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(magicBoots, "0000200", "rare", "Magic Boots", 0, 1, "Boots", 0, 0, 1);
            FillEquipmentStats(magicGauntlet, "0002000", "rare", "Magic Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(magicHelmet, "0020000", "rare", "Magic Helmet", 0, 1, "Helmet");
            FillEquipmentStats(magicShield, "0200000", "rare", "Magic Shield", 0, 1, "Shield", 4);
            FillEquipmentStats(magicTwoHandedWeapon, "2000000", "rare", "Magic Zweinhander", 7, 0, "Two-Handed Weapon");
            FillEquipmentStats(legendaryWeapon, "0000003", "legendary", "Legendary Sword", 7, 0, "One-Handed Weapon");
            FillEquipmentStats(legendaryChestplate, "0000030", "legendary", "Legendary Chestplate", 0, 3, "Chestplate");
            FillEquipmentStats(legendaryBoots, "0000300", "legendary", "Legendary Boots", 0, 1, "Boots", 0, 0, 3);
            FillEquipmentStats(legendaryGauntlet, "0003000", "legendary", "Legendary Gauntlet", 0, 1, "Gauntlet");
            FillEquipmentStats(legendaryHelmet, "0030000", "legendary", "Legendary Helmet", 0, 1, "Helmet");
            FillEquipmentStats(legendaryShield, "0300000", "legendary", "Legendary Shield", 0, 2, "Shield", 6);
            FillEquipmentStats(legendaryTwoHandedWeapon, "3000000", "legendary", "Legendary Zweinhander", 9, 0, "Two-Handed Weapon");
        
            gameInventory.PickUp(basicWeapon);
            gameInventory.PickUp(basicChestplate);
            gameInventory.PickUp(basicBoots);
            gameInventory.PickUp(basicGauntlet);
            gameInventory.PickUp(basicHelmet);
            gameInventory.PickUp(basicShield);
            gameInventory.PickUp(basicTwoHandedWeapon);
            gameInventory.PickUp(spikeShield);
            gameInventory.PickUp(magicWeapon);
            gameInventory.PickUp(magicChestplate);
            gameInventory.PickUp(magicBoots);
            gameInventory.PickUp(magicGauntlet);
            gameInventory.PickUp(magicHelmet);
            gameInventory.PickUp(magicShield);
            gameInventory.PickUp(magicTwoHandedWeapon);
            gameInventory.PickUp(legendaryWeapon);
            gameInventory.PickUp(legendaryChestplate);
            gameInventory.PickUp(legendaryBoots);
            gameInventory.PickUp(legendaryGauntlet);
            gameInventory.PickUp(legendaryHelmet);
            gameInventory.PickUp(legendaryShield);
            gameInventory.PickUp(legendaryTwoHandedWeapon);

           int safskdgnvdj = gameInventory.PlayerInventory.Length; //--Buscando propiedad de array que diga cuantos "espacios" o "slots" tiene una lista--

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
            Lb_ItemsEquiped.Parent = PicBox_InventoryBackground;
            Lb_Bag.Parent = PicBox_InventoryBackground;
            Lb_Damage.Parent = PicBox_InventoryBackground;
            Lb_SpecialDamage.Parent = PicBox_InventoryBackground;
            Lb_Armor.Parent = PicBox_InventoryBackground;
            Lb_Defense.Parent = PicBox_InventoryBackground;
            Lb_DodgeProb.Parent = PicBox_InventoryBackground;
            Lb_Thorns.Parent = PicBox_InventoryBackground;

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

            if (System.IO.File.Exists("Inventory.xml") || System.IO.File.Exists("Equipment.xml"))
            {
                string Id;
                int Position;

                foreach (DataRow row in playerInventory.InventoryList.Rows)
                {
                     if (row["Item ID"] == null)
                     {
                         Id = "";
                     }
                     else
                     {
                          if ((row["Array Position"]) != DBNull.Value)
                          {
                          Id = Convert.ToString(row["Item ID"]);
                          Position = Convert.ToInt32(row["Array Position"]);

                          playerInventory.PlayerInventory[Position] = gameInventory.SearchInInventory(Id);
                          }

                     }
                }

                foreach (DataRow row in playerInventory.EquipmentList.Rows)
                {
                    if ((row)["Item ID"] == null)
                    {
                        Id = "";
                    }
                    else
                    {
                        if (row["Item ID"] == null)
                        {
                            Id = "";
                        }
                        else
                        {
                          if ((row["Array Position"]) != DBNull.Value)
                          {
                              Id = Convert.ToString(row["Item ID"]);
                              Position = Convert.ToInt32(row["Array Position"]);

                              playerInventory.PlayerEquipment[Position] = gameInventory.SearchInInventory(Id);
                          }

                      }
                    }  
                }
            }
            else
            {
                playerInventory.PickUp(basicWeapon);
                playerInventory.PickUp(basicChestplate);
                playerInventory.PickUp(basicGauntlet);
                playerInventory.PickUp(basicBoots);
                playerInventory.Equip(basicWeapon);
                playerInventory.Equip(basicChestplate);
                playerInventory.Equip(basicGauntlet);
                playerInventory.Equip(basicBoots);

                enemyInventory.PickUp(basicWeapon);
                enemyInventory.PickUp(basicChestplate);
                enemyInventory.PickUp(basicShield);
                enemyInventory.Equip(basicWeapon);
                enemyInventory.Equip(basicChestplate);
                enemyInventory.Equip(basicShield);

                playerInventory.PickUp(legendaryTwoHandedWeapon);
            }
            /*  --Para resetear el Inventario si los datos se corrompen o la persistencia sale mal
             playerInventory.PickUp(basicWeapon);
             playerInventory.PickUp(basicChestplate);
             playerInventory.PickUp(basicGauntlet);
             playerInventory.PickUp(basicBoots);
             playerInventory.Equip(basicWeapon);
             playerInventory.Equip(basicChestplate);
             playerInventory.Equip(basicGauntlet);
             playerInventory.Equip(basicBoots);

             enemyInventory.PickUp(basicWeapon);
             enemyInventory.PickUp(basicChestplate);
             enemyInventory.PickUp(basicShield);
             enemyInventory.Equip(basicWeapon);
             enemyInventory.Equip(basicChestplate);
             enemyInventory.Equip(basicShield);

             playerInventory.PickUp(legendaryTwoHandedWeapon);
            */

           player.Special_Cooldown = 2;
            player.IsTurn = true;

            TimerLoop.Start();
            Timer2.Start();
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
                    Bt_Attack.Visible = true;
                    Bt_Defend.Visible = true;
                    Bt_Dodge.Visible = true;
                    Bt_Special.Visible = true;
                    Lb_Cooldown.Visible = true;
                    TimerLoop.Enabled = true;
                }
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

        private void Bt_HelpInv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here you can see the items you've obtained and you have equipped\n\r" +
                "If the item has a rosy brown color, it is common;\n\rif sky blue, is rare; \n\r" +
                "and if it is orange, then it is legendary.\n\r" +
                "You can only equip 1 type of item at a time, also Two-handed swords cannot be used with shields nor one-handed swords.",
               "Inventory Instructions");
        }

        #region Action Buttons
        public async void Bt_Attack_Click(object sender, EventArgs e)
        {
            if (player.IsTurn && Battle)
            {
                LastHP = enemy.HP;
                EnemyWasDodging = enemy.Dodging;
                player.Attack(enemy, random);

                if (LastHP == enemy.HP & EnemyWasDodging)
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
                else if (LastHP == enemy.HP)
                {
                    Lb_Action.Text = "No Damage";
                    Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                    Lb_Action.Top = 70;
                    Lb_Action.Left = 330;
                    Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    Lb_Action.Visible = true;
                    await Task.Delay(500);
                    Refresh();
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
                await Task.Delay(700);
                Refresh();
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
                EnemyWasDodging = enemy.Dodging;
                player.SpecialAttack(enemy, random);

                if (LastHP == enemy.HP & EnemyWasDodging)
                {
                    Lb_Action.Text = "Special Dodged!";
                    Lb_Action.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.MediumVioletRed;
                    Lb_Action.Location = new System.Drawing.Point(256, 80);
                    Lb_Action.Visible = true;
                    await Task.Delay(1200);
                    Lb_Action.Visible = false;
                }
                else if (LastHP == enemy.HP)
                {
                    Lb_Action.Text = "No Damage";
                    Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                    Lb_Action.Top = 70;
                    Lb_Action.Left = 330;
                    Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    Lb_Action.Visible = true;
                    await Task.Delay(500);
                    Refresh();
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
                Refresh();
                await Task.Delay(700);
                if (enemy.Special_Cooldown <= 0)
                {
                    LastHP = player.HP;
                    WasDodging = player.Dodging;
                    enemy.SpecialAttack(player, random);

                    if (LastHP == player.HP & WasDodging)
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
                    else if (LastHP == player.HP)
                    {
                        Lb_Action.Text = "No Damage";
                        Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                        Lb_Action.Top = 70;
                        Lb_Action.Left = 330;
                        Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        Lb_Action.Visible = true;
                        await Task.Delay(500);
                        Refresh();
                        Lb_Action.Visible = false;
                    }
                    else
                    {
                        Lb_Action.Text = (player.HP - LastHP).ToString();
                        Lb_Action.Font = new System.Drawing.Font("Bahnschrift Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.Red;
                        Lb_Action.Location = new System.Drawing.Point(282, 138);
                        Lb_Action.Visible = true;
                        Refresh();
                        await Task.Delay(700);
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
                    Refresh();
                    await Task.Delay(700);
                    Lb_Action.Visible = false;
                }
                else
                {
                    LastHP = player.HP;
                    WasDodging = player.Dodging;
                    enemy.Attack(player, random);
                    AttackCE++;
                    if (LastHP == player.HP & WasDodging)
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
                    else if (LastHP == player.HP)
                    {
                        Lb_Action.Text = "No Damage";
                        Lb_Action.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        Lb_Action.ForeColor = System.Drawing.Color.RoyalBlue;
                        Lb_Action.Top = 70;
                        Lb_Action.Left = 330;
                        Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        Lb_Action.Visible = true;
                        await Task.Delay(500);
                        Refresh();
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
                        await Task.Delay(700);
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
                        "Exp: " + player.Exp.ToString() + "/" + ((80 * (player.Level - 1)) + (60 * (1.0 + (LastLevel - 1 / 5.0)))).ToString(),
                        "Level Up");
                    //First Level Up should say "Exp: 80/188". 80 can variate since it is not a constant, it is actual Exp of the player.
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

        #region PicBoxs Inventory
        private void PicBox_BagSlot0_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[0] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[0]);          
            }
        }

        private void PicBox_BagSlot1_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[1] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[1]);
            }
        }

        private void PicBox_BagSlot2_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[2] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[2]);
            }
        }

        private void PicBox_BagSlot3_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[3] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[3]);
            }
        }

        private void PicBox_BagSlot4_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[4] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[4]);
            }
        }

        private void PicBox_BagSlot5_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[5] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[5]);
            }
        }

        private void PicBox_BagSlot6_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[6] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[6]);
            }
        }

        private void PicBox_BagSlot7_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[7] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[7]);
            }
        }

        private void PicBox_BagSlot8_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[8] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[8]);
            }
        }

        private void PicBox_BagSlot9_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[9] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[9]);
            }
        }

        private void PicBox_BagSlot10_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[10] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[10]);
            }
        }

        private void PicBox_BagSlot11_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerInventory[11] != null)
            {
                playerInventory.Equip(playerInventory.PlayerInventory[11]);
            }
        }

        private void PicBox_THWeaponSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[0] != null)
            {
                playerInventory.Unequip(0);
            }
        }

        private void PicBox_WeaponSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[1] != null)
            {
                playerInventory.Unequip(1);
            }
        }

        private void PicBox_ShieldSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[2] != null)
            {
                playerInventory.Unequip(2);
            }
        }

        private void PicBox_HelmetSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[3] != null)
            {
                playerInventory.Unequip(3);
            }
        }

        private void PicBox_ChestplateSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[4] != null)
            {
                playerInventory.Unequip(4);
            }
        }

        private void PicBox_GauntletSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[5] != null)
            {
                playerInventory.Unequip(5);
            }
        }

        private void PicBox_BootsSlot_DoubleClick(object sender, EventArgs e)
        {
            if (playerInventory.PlayerEquipment[6] != null)
            {
                playerInventory.Unequip(6);
            }
        }
        #endregion

        private void Timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                var PicBox = PicBox_TitleScreen;
                string Types;
                string Rarities;
                string name;
                if (playerInventory.PlayerInventory[i] == null)
                {
                    Types = string.Empty;
                    Rarities = string.Empty;
                    name = string.Empty;
                }
                else
                {
                    Types = playerInventory.PlayerInventory[i].Type;
                    Rarities = playerInventory.PlayerInventory[i].Rarity;
                    name = playerInventory.PlayerInventory[i].Name;
                }
                switch (i)
                {
                    case (0):
                        PicBox = PicBox_BagSlot0;
                        break;
                    case (1):
                        PicBox = PicBox_BagSlot1;
                        break;
                    case (2):
                        PicBox = PicBox_BagSlot2;
                        break;
                    case (3):
                        PicBox = PicBox_BagSlot3;
                        break;
                    case (4):
                        PicBox = PicBox_BagSlot4;
                        break;
                    case (5):
                        PicBox = PicBox_BagSlot5;
                        break;
                    case (6):
                        PicBox = PicBox_BagSlot6;
                        break;
                    case (7):
                        PicBox = PicBox_BagSlot7;
                        break;
                    case (8):
                        PicBox = PicBox_BagSlot8;
                        break;
                    case (9):
                        PicBox = PicBox_BagSlot9;
                        break;
                    case (10):
                        PicBox = PicBox_BagSlot10;
                        break;
                    case (11):
                        PicBox = PicBox_BagSlot11;
                        break;
                }
                switch (Types)
                {
                    case ("Two-Handed Weapon"):
                        PicBox.Image = Resources.Zweihander;
                        break;
                    case ("One-Handed Weapon"):
                        PicBox.Image = Resources.OneHandedSword;
                        break;
                    case ("Shield"):
                        switch (name)
                        {
                            case ("Spiked Shield"):
                                PicBox.Image = Resources.Spiked_Shield;
                                break;
                            default:
                                PicBox.Image = Resources.Shield;
                                break;
                        }
                        break;
                    case ("Helmet"):
                        PicBox.Image = Resources.Helmet;
                        break;
                    case ("Chestplate"):
                        PicBox.Image = Resources.Chestplate;
                        break;
                    case ("Gauntlet"):
                        PicBox.Image = Resources.Gauntlets;
                        break;
                    case ("Boots"):
                        PicBox.Image = Resources.Boots;
                        break;
                    default:
                        PicBox.Image = null;
                        break;
                }
                switch (Rarities)
                {
                    case ("common"):
                        PicBox.BackColor = Color.RosyBrown;
                        break;
                    case ("rare"):
                        PicBox.BackColor = Color.DeepSkyBlue;
                        break;
                    case ("legendary"):
                        PicBox.BackColor = Color.Orange;
                        break;
                    default:
                        PicBox.BackColor = Color.LightGray;
                        break;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                var PicBox = PicBox_TitleScreen;
                string Types;
                string Rarities;
                string name;
                if (playerInventory.PlayerEquipment[i] == null)
                {
                    Types = string.Empty;
                    Rarities = string.Empty;
                    name = string.Empty;
                }
                else
                {
                    Types = playerInventory.PlayerEquipment[i].Type;
                    Rarities = playerInventory.PlayerEquipment[i].Rarity;
                    name = playerInventory.PlayerEquipment[i].Name;
                }
                switch (i)
                {
                    case (0):
                        PicBox = PicBox_THWeaponSlot;
                        break;
                    case (1):
                        PicBox = PicBox_WeaponSlot;
                        break;
                    case (2):
                        PicBox = PicBox_ShieldSlot;
                        break;
                    case (3):
                        PicBox = PicBox_HelmetSlot;
                        break;
                    case (4):
                        PicBox = PicBox_ChestplateSlot;
                        break;
                    case (5):
                        PicBox = PicBox_GauntletSlot;
                        break;
                    case (6):
                        PicBox = PicBox_BootsSlot;
                        break;
                }
                switch (Types)
                {
                    case ("Two-Handed Weapon"):
                        PicBox_THWeaponSlot.Image = Resources.Zweihander;

                        break;
                    case ("One-Handed Weapon"):
                        PicBox_WeaponSlot.Image = Resources.OneHandedSword;
                        break;
                    case ("Shield"):
                        switch (name)
                        {
                            case ("Spiked Shield"):
                                PicBox_ShieldSlot.Image = Resources.Spiked_Shield;
                                break;
                            default:
                                PicBox_ShieldSlot.Image = Resources.Shield;
                                break;
                        }
                        break;
                    case ("Helmet"):
                        PicBox_HelmetSlot.Image = Resources.Helmet;
                        break;
                    case ("Chestplate"):
                        PicBox_ChestplateSlot.Image = Resources.Chestplate;
                        break;
                    case ("Gauntlet"):
                        PicBox_GauntletSlot.Image = Resources.Gauntlets;
                        break;
                    case ("Boots"):
                        PicBox_BootsSlot.Image = Resources.Boots;
                        break;
                    default:
                        switch (i)
                        {
                            case (0):
                                PicBox.Image = Resources.TwoHandedSwordIcon;
                                break;
                            case (1):
                                PicBox.Image = Resources.SwordIcon;
                                break;
                            case (2):
                                PicBox.Image = Resources.ShieldIcon;
                                break;
                            case (3):
                                PicBox.Image = Resources.HelmetIcon;
                                break;
                            case (4):
                                PicBox.Image = Resources.ChestplateIcon;
                                break;
                            case (5):
                                PicBox.Image = Resources.GauntletIcon;
                                break;
                            case (6):
                                PicBox.Image = Resources.BootsIcon;
                                break;
                        }
                        break;
                }
                switch (Rarities)
                {
                    case ("common"):
                        PicBox.BackColor = Color.RosyBrown;
                        break;
                    case ("rare"):
                        PicBox.BackColor = Color.DeepSkyBlue;
                        break;
                    case ("legendary"):
                        PicBox.BackColor = Color.Orange;
                        break;
                    default:
                        PicBox.BackColor = Color.LightGray;
                        break;
                }
            }
            player.Total_Damage = player.Attack_Damage + (playerInventory.GetStatFromSet("Damage"));
            player.Total_Defense = player.Defense_Capacity + (playerInventory.GetStatFromSet("DamageReduction"));
            player.Special_Damage = (player.Total_Damage * 2) - (player.Total_Damage / 2);
            player.Armor = (playerInventory.GetStatFromSet("Armor"));
            player.Thorns = (playerInventory.GetStatFromSet("Thorns"));
            player.Dodge_Probability = player.Dodge_Proficiency + (playerInventory.GetStatFromSet("Agility"));
            Lb_Damage.Text = "Damage: " + (player.Total_Damage.ToString());
            Lb_SpecialDamage.Text = "Special damage: " + (player.Special_Damage.ToString());
            Lb_Armor.Text = "Armor: " + (player.Armor.ToString());
            Lb_Defense.Text = "Defense: " + (player.Total_Defense.ToString());
            Lb_DodgeProb.Text = "Dodge prob: " + (player.Dodge_Probability.ToString());
            Lb_Thorns.Text = "Thorns: " + (player.Thorns.ToString());

            enemy.Total_Damage = enemy.Attack_Damage + (enemyInventory.GetStatFromSet("Damage"));
            enemy.Total_Defense = enemy.Defense_Capacity + (enemyInventory.GetStatFromSet("DamageReduction"));
            enemy.Special_Damage = (player.Total_Damage * 2) - (player.Total_Damage / 2);
            enemy.Armor = (enemyInventory.GetStatFromSet("Armor"));
            enemy.Thorns = (enemyInventory.GetStatFromSet("Thorns"));
            enemy.Dodge_Probability = enemy.Dodge_Proficiency + (enemyInventory.GetStatFromSet("Agility"));

            playerInventory.InventoryScan();
            playerInventory.EquipmentScan();
        }

    }
}
