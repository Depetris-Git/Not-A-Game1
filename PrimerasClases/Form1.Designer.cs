namespace PrimerasClases
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Bt_Attack = new System.Windows.Forms.Button();
            this.Bt_Special = new System.Windows.Forms.Button();
            this.Bt_Defend = new System.Windows.Forms.Button();
            this.Bt_Exit = new System.Windows.Forms.Button();
            this.Bt_Pause = new System.Windows.Forms.Button();
            this.Lb_Player_HP = new System.Windows.Forms.Label();
            this.Lb_Enemy_HP = new System.Windows.Forms.Label();
            this.Lb_Turn = new System.Windows.Forms.Label();
            this.Lb_Cooldown = new System.Windows.Forms.Label();
            this.Bt_Dodge = new System.Windows.Forms.Button();
            this.Bt_Help = new System.Windows.Forms.Button();
            this.ProBar_HP_Player = new System.Windows.Forms.ProgressBar();
            this.ProBar_HP_Enemy = new System.Windows.Forms.ProgressBar();
            this.PicBox_Player = new System.Windows.Forms.PictureBox();
            this.PicBox_Enemy = new System.Windows.Forms.PictureBox();
            this.Bt_Play = new System.Windows.Forms.Button();
            this.Lb_Title = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TimerLoop = new System.Windows.Forms.Timer(this.components);
            this.Lb_Action = new System.Windows.Forms.Label();
            this.Lb_Turn2 = new System.Windows.Forms.Label();
            this.lbPause = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Enemy)).BeginInit();
            this.SuspendLayout();
            // 
            // Bt_Attack
            // 
            this.Bt_Attack.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Attack.Location = new System.Drawing.Point(301, 294);
            this.Bt_Attack.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Attack.Name = "Bt_Attack";
            this.Bt_Attack.Size = new System.Drawing.Size(115, 55);
            this.Bt_Attack.TabIndex = 2;
            this.Bt_Attack.Text = "Attack";
            this.ToolTip.SetToolTip(this.Bt_Attack, "Attack = 5");
            this.Bt_Attack.UseVisualStyleBackColor = true;
            this.Bt_Attack.Click += new System.EventHandler(this.Bt_Attack_Click);
            // 
            // Bt_Special
            // 
            this.Bt_Special.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Special.Location = new System.Drawing.Point(424, 357);
            this.Bt_Special.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Special.Name = "Bt_Special";
            this.Bt_Special.Size = new System.Drawing.Size(115, 55);
            this.Bt_Special.TabIndex = 3;
            this.Bt_Special.Text = "Special";
            this.ToolTip.SetToolTip(this.Bt_Special, "Special Damage = 14");
            this.Bt_Special.UseVisualStyleBackColor = true;
            this.Bt_Special.Click += new System.EventHandler(this.Bt_Special_Click);
            // 
            // Bt_Defend
            // 
            this.Bt_Defend.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Defend.Location = new System.Drawing.Point(424, 294);
            this.Bt_Defend.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Defend.Name = "Bt_Defend";
            this.Bt_Defend.Size = new System.Drawing.Size(115, 55);
            this.Bt_Defend.TabIndex = 4;
            this.Bt_Defend.Text = "Defend";
            this.ToolTip.SetToolTip(this.Bt_Defend, "Defense = 4");
            this.Bt_Defend.UseVisualStyleBackColor = true;
            this.Bt_Defend.Click += new System.EventHandler(this.Bt_Defend_Click);
            // 
            // Bt_Exit
            // 
            this.Bt_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Exit.Location = new System.Drawing.Point(895, 448);
            this.Bt_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Exit.Name = "Bt_Exit";
            this.Bt_Exit.Size = new System.Drawing.Size(115, 55);
            this.Bt_Exit.TabIndex = 5;
            this.Bt_Exit.Text = "Exit";
            this.Bt_Exit.UseVisualStyleBackColor = true;
            this.Bt_Exit.Click += new System.EventHandler(this.Bt_Exit_Click);
            // 
            // Bt_Pause
            // 
            this.Bt_Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Pause.Location = new System.Drawing.Point(56, 448);
            this.Bt_Pause.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Pause.Name = "Bt_Pause";
            this.Bt_Pause.Size = new System.Drawing.Size(175, 55);
            this.Bt_Pause.TabIndex = 6;
            this.Bt_Pause.Text = "Pause";
            this.Bt_Pause.UseVisualStyleBackColor = true;
            this.Bt_Pause.Click += new System.EventHandler(this.Bt_Pause_Click);
            // 
            // Lb_Player_HP
            // 
            this.Lb_Player_HP.AutoSize = true;
            this.Lb_Player_HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Player_HP.Location = new System.Drawing.Point(51, 54);
            this.Lb_Player_HP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Player_HP.Name = "Lb_Player_HP";
            this.Lb_Player_HP.Size = new System.Drawing.Size(205, 29);
            this.Lb_Player_HP.TabIndex = 7;
            this.Lb_Player_HP.Text = "HP: Vida/VidaMax";
            // 
            // Lb_Enemy_HP
            // 
            this.Lb_Enemy_HP.AutoSize = true;
            this.Lb_Enemy_HP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Enemy_HP.Location = new System.Drawing.Point(767, 54);
            this.Lb_Enemy_HP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Enemy_HP.Name = "Lb_Enemy_HP";
            this.Lb_Enemy_HP.Size = new System.Drawing.Size(205, 29);
            this.Lb_Enemy_HP.TabIndex = 8;
            this.Lb_Enemy_HP.Text = "HP: Vida/VidaMax";
            // 
            // Lb_Turn
            // 
            this.Lb_Turn.AutoSize = true;
            this.Lb_Turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Turn.Location = new System.Drawing.Point(383, 18);
            this.Lb_Turn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Turn.Name = "Lb_Turn";
            this.Lb_Turn.Size = new System.Drawing.Size(143, 29);
            this.Lb_Turn.TabIndex = 9;
            this.Lb_Turn.Text = "Player\'s turn";
            // 
            // Lb_Cooldown
            // 
            this.Lb_Cooldown.AutoSize = true;
            this.Lb_Cooldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cooldown.Location = new System.Drawing.Point(419, 416);
            this.Lb_Cooldown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Cooldown.Name = "Lb_Cooldown";
            this.Lb_Cooldown.Size = new System.Drawing.Size(148, 29);
            this.Lb_Cooldown.TabIndex = 10;
            this.Lb_Cooldown.Text = "Cooldown: 0";
            // 
            // Bt_Dodge
            // 
            this.Bt_Dodge.Font = new System.Drawing.Font("Palatino Linotype", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Dodge.Location = new System.Drawing.Point(301, 357);
            this.Bt_Dodge.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Dodge.Name = "Bt_Dodge";
            this.Bt_Dodge.Size = new System.Drawing.Size(115, 55);
            this.Bt_Dodge.TabIndex = 11;
            this.Bt_Dodge.Text = "Dodge";
            this.ToolTip.SetToolTip(this.Bt_Dodge, "Dodge probability = 50%");
            this.Bt_Dodge.UseVisualStyleBackColor = true;
            this.Bt_Dodge.Click += new System.EventHandler(this.Bt_Dodge_Click);
            // 
            // Bt_Help
            // 
            this.Bt_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Help.Location = new System.Drawing.Point(772, 448);
            this.Bt_Help.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Help.Name = "Bt_Help";
            this.Bt_Help.Size = new System.Drawing.Size(115, 55);
            this.Bt_Help.TabIndex = 12;
            this.Bt_Help.Text = "Help";
            this.Bt_Help.UseVisualStyleBackColor = true;
            this.Bt_Help.Click += new System.EventHandler(this.Bt_Help_Click);
            // 
            // ProBar_HP_Player
            // 
            this.ProBar_HP_Player.BackColor = System.Drawing.Color.Red;
            this.ProBar_HP_Player.ForeColor = System.Drawing.Color.Green;
            this.ProBar_HP_Player.Location = new System.Drawing.Point(56, 89);
            this.ProBar_HP_Player.Margin = new System.Windows.Forms.Padding(4);
            this.ProBar_HP_Player.Name = "ProBar_HP_Player";
            this.ProBar_HP_Player.Size = new System.Drawing.Size(237, 18);
            this.ProBar_HP_Player.TabIndex = 14;
            // 
            // ProBar_HP_Enemy
            // 
            this.ProBar_HP_Enemy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ProBar_HP_Enemy.ForeColor = System.Drawing.Color.Green;
            this.ProBar_HP_Enemy.Location = new System.Drawing.Point(772, 89);
            this.ProBar_HP_Enemy.Margin = new System.Windows.Forms.Padding(4);
            this.ProBar_HP_Enemy.Name = "ProBar_HP_Enemy";
            this.ProBar_HP_Enemy.Size = new System.Drawing.Size(237, 17);
            this.ProBar_HP_Enemy.TabIndex = 15;
            // 
            // PicBox_Player
            // 
            this.PicBox_Player.Image = global::PrimerasClases.Properties.Resources.Player_Alt;
            this.PicBox_Player.Location = new System.Drawing.Point(56, 89);
            this.PicBox_Player.Margin = new System.Windows.Forms.Padding(4);
            this.PicBox_Player.Name = "PicBox_Player";
            this.PicBox_Player.Size = new System.Drawing.Size(237, 342);
            this.PicBox_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Player.TabIndex = 16;
            this.PicBox_Player.TabStop = false;
            // 
            // PicBox_Enemy
            // 
            this.PicBox_Enemy.Image = global::PrimerasClases.Properties.Resources.Enemy;
            this.PicBox_Enemy.Location = new System.Drawing.Point(772, 113);
            this.PicBox_Enemy.Margin = new System.Windows.Forms.Padding(4);
            this.PicBox_Enemy.Name = "PicBox_Enemy";
            this.PicBox_Enemy.Size = new System.Drawing.Size(237, 297);
            this.PicBox_Enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Enemy.TabIndex = 17;
            this.PicBox_Enemy.TabStop = false;
            // 
            // Bt_Play
            // 
            this.Bt_Play.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Play.Location = new System.Drawing.Point(434, 294);
            this.Bt_Play.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Play.Name = "Bt_Play";
            this.Bt_Play.Size = new System.Drawing.Size(175, 55);
            this.Bt_Play.TabIndex = 18;
            this.Bt_Play.Text = "Play";
            this.Bt_Play.UseVisualStyleBackColor = true;
            this.Bt_Play.Click += new System.EventHandler(this.Bt_Play_Click);
            // 
            // Lb_Title
            // 
            this.Lb_Title.AutoSize = true;
            this.Lb_Title.Font = new System.Drawing.Font("Engravers MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Title.Location = new System.Drawing.Point(207, 84);
            this.Lb_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Title.Name = "Lb_Title";
            this.Lb_Title.Size = new System.Drawing.Size(589, 35);
            this.Lb_Title.TabIndex = 19;
            this.Lb_Title.Text = "INSERT NAME OF THE GAME";
            this.Lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimerLoop
            // 
            this.TimerLoop.Interval = 1500;
            this.TimerLoop.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // Lb_Action
            // 
            this.Lb_Action.AutoSize = true;
            this.Lb_Action.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Action.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.Lb_Action.Location = new System.Drawing.Point(320, 80);
            this.Lb_Action.Name = "Lb_Action";
            this.Lb_Action.Size = new System.Drawing.Size(345, 41);
            this.Lb_Action.TabIndex = 20;
            this.Lb_Action.Text = "Special Dodged!";
            this.Lb_Action.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_Turn2
            // 
            this.Lb_Turn2.AutoSize = true;
            this.Lb_Turn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Turn2.Location = new System.Drawing.Point(522, 47);
            this.Lb_Turn2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Turn2.Name = "Lb_Turn2";
            this.Lb_Turn2.Size = new System.Drawing.Size(26, 29);
            this.Lb_Turn2.TabIndex = 21;
            this.Lb_Turn2.Text = "1";
            // 
            // lbPause
            // 
            this.lbPause.AutoSize = true;
            this.lbPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPause.Location = new System.Drawing.Point(457, 157);
            this.lbPause.Name = "lbPause";
            this.lbPause.Size = new System.Drawing.Size(152, 42);
            this.lbPause.TabIndex = 22;
            this.lbPause.Text = "Paused";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lbPause);
            this.Controls.Add(this.Lb_Action);
            this.Controls.Add(this.Lb_Turn2);
            this.Controls.Add(this.Lb_Title);
            this.Controls.Add(this.Bt_Play);
            this.Controls.Add(this.ProBar_HP_Enemy);
            this.Controls.Add(this.ProBar_HP_Player);
            this.Controls.Add(this.Bt_Help);
            this.Controls.Add(this.Bt_Dodge);
            this.Controls.Add(this.Lb_Cooldown);
            this.Controls.Add(this.Lb_Turn);
            this.Controls.Add(this.Lb_Enemy_HP);
            this.Controls.Add(this.Lb_Player_HP);
            this.Controls.Add(this.Bt_Pause);
            this.Controls.Add(this.Bt_Exit);
            this.Controls.Add(this.Bt_Defend);
            this.Controls.Add(this.Bt_Special);
            this.Controls.Add(this.Bt_Attack);
            this.Controls.Add(this.PicBox_Player);
            this.Controls.Add(this.PicBox_Enemy);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Enemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Bt_Attack;
        private System.Windows.Forms.Button Bt_Special;
        private System.Windows.Forms.Button Bt_Defend;
        private System.Windows.Forms.Button Bt_Exit;
        private System.Windows.Forms.Button Bt_Pause;
        private System.Windows.Forms.Label Lb_Player_HP;
        private System.Windows.Forms.Label Lb_Enemy_HP;
        private System.Windows.Forms.Label Lb_Turn;
        private System.Windows.Forms.Label Lb_Cooldown;
        private System.Windows.Forms.Button Bt_Dodge;
        private System.Windows.Forms.Button Bt_Help;
        private System.Windows.Forms.ProgressBar ProBar_HP_Player;
        private System.Windows.Forms.ProgressBar ProBar_HP_Enemy;
        private System.Windows.Forms.PictureBox PicBox_Player;
        private System.Windows.Forms.PictureBox PicBox_Enemy;
        private System.Windows.Forms.Button Bt_Play;
        private System.Windows.Forms.Label Lb_Title;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Timer TimerLoop;
        private System.Windows.Forms.Label Lb_Action;
        private System.Windows.Forms.Label Lb_Turn2;
        private System.Windows.Forms.Label lbPause;
    }
}

