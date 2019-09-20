namespace ChessGame
{
    partial class mainMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabMainMenu = new System.Windows.Forms.TabControl();
            this.tabGame = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSelectPlayer2 = new System.Windows.Forms.ComboBox();
            this.cmbSelectPlayer1 = new System.Windows.Forms.ComboBox();
            this.tabCreatePlayer = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAddPlayer = new System.Windows.Forms.TextBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbPlayers = new System.Windows.Forms.ListBox();
            this.TabMainMenu.SuspendLayout();
            this.tabGame.SuspendLayout();
            this.tabCreatePlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMainMenu
            // 
            this.TabMainMenu.Controls.Add(this.tabGame);
            this.TabMainMenu.Controls.Add(this.tabCreatePlayer);
            this.TabMainMenu.Location = new System.Drawing.Point(12, 12);
            this.TabMainMenu.Name = "TabMainMenu";
            this.TabMainMenu.SelectedIndex = 0;
            this.TabMainMenu.Size = new System.Drawing.Size(617, 646);
            this.TabMainMenu.TabIndex = 0;
            // 
            // tabGame
            // 
            this.tabGame.Controls.Add(this.panel1);
            this.tabGame.Controls.Add(this.btnStartGame);
            this.tabGame.Controls.Add(this.label3);
            this.tabGame.Controls.Add(this.label2);
            this.tabGame.Controls.Add(this.cmbSelectPlayer2);
            this.tabGame.Controls.Add(this.cmbSelectPlayer1);
            this.tabGame.Location = new System.Drawing.Point(4, 29);
            this.tabGame.Name = "tabGame";
            this.tabGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabGame.Size = new System.Drawing.Size(609, 613);
            this.tabGame.TabIndex = 0;
            this.tabGame.Text = "Partie";
            this.tabGame.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            //this.panel1.BackgroundImage = global::ChessGame.Properties.Resources.mainMenu_Picture;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(135, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 312);
            this.panel1.TabIndex = 8;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(67, 505);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(476, 43);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "Démarrer une partie";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Joueur 2 (Noir)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Joueur 1 (Blanc)";
            // 
            // cmbSelectPlayer2
            // 
            this.cmbSelectPlayer2.FormattingEnabled = true;
            this.cmbSelectPlayer2.Location = new System.Drawing.Point(366, 462);
            this.cmbSelectPlayer2.Name = "cmbSelectPlayer2";
            this.cmbSelectPlayer2.Size = new System.Drawing.Size(177, 28);
            this.cmbSelectPlayer2.TabIndex = 1;
            // 
            // cmbSelectPlayer1
            // 
            this.cmbSelectPlayer1.FormattingEnabled = true;
            this.cmbSelectPlayer1.Location = new System.Drawing.Point(67, 462);
            this.cmbSelectPlayer1.Name = "cmbSelectPlayer1";
            this.cmbSelectPlayer1.Size = new System.Drawing.Size(177, 28);
            this.cmbSelectPlayer1.TabIndex = 0;
            // 
            // tabCreatePlayer
            // 
            this.tabCreatePlayer.Controls.Add(this.panel2);
            this.tabCreatePlayer.Controls.Add(this.txtAddPlayer);
            this.tabCreatePlayer.Controls.Add(this.btnAddPlayer);
            this.tabCreatePlayer.Controls.Add(this.btnDeletePlayer);
            this.tabCreatePlayer.Controls.Add(this.label1);
            this.tabCreatePlayer.Controls.Add(this.lsbPlayers);
            this.tabCreatePlayer.Location = new System.Drawing.Point(4, 29);
            this.tabCreatePlayer.Name = "tabCreatePlayer";
            this.tabCreatePlayer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreatePlayer.Size = new System.Drawing.Size(609, 613);
            this.tabCreatePlayer.TabIndex = 1;
            this.tabCreatePlayer.Text = "Création de joueurs";
            this.tabCreatePlayer.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            //this.panel2.BackgroundImage = global::ChessGame.Properties.Resources.mainMenu_Picture;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(135, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 312);
            this.panel2.TabIndex = 7;
            // 
            // txtAddPlayer
            // 
            this.txtAddPlayer.Location = new System.Drawing.Point(33, 339);
            this.txtAddPlayer.Name = "txtAddPlayer";
            this.txtAddPlayer.Size = new System.Drawing.Size(542, 26);
            this.txtAddPlayer.TabIndex = 6;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(33, 371);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(542, 41);
            this.btnAddPlayer.TabIndex = 5;
            this.btnAddPlayer.Text = "Ajouté ce joueur à la liste";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.Location = new System.Drawing.Point(33, 554);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(542, 41);
            this.btnDeletePlayer.TabIndex = 4;
            this.btnDeletePlayer.Text = "Supprimer le joueur sélectionné";
            this.btnDeletePlayer.UseVisualStyleBackColor = true;
            this.btnDeletePlayer.Click += new System.EventHandler(this.BtnDeletePlayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Liste des joueurs présentement enregistrés:";
            // 
            // lsbPlayers
            // 
            this.lsbPlayers.FormattingEnabled = true;
            this.lsbPlayers.ItemHeight = 20;
            this.lsbPlayers.Location = new System.Drawing.Point(33, 455);
            this.lsbPlayers.Name = "lsbPlayers";
            this.lsbPlayers.Size = new System.Drawing.Size(542, 84);
            this.lsbPlayers.TabIndex = 2;
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 665);
            this.Controls.Add(this.TabMainMenu);
            this.Name = "mainMenu";
            this.Text = "Form1";
            this.TabMainMenu.ResumeLayout(false);
            this.tabGame.ResumeLayout(false);
            this.tabGame.PerformLayout();
            this.tabCreatePlayer.ResumeLayout(false);
            this.tabCreatePlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMainMenu;
        private System.Windows.Forms.TabPage tabGame;
        private System.Windows.Forms.TabPage tabCreatePlayer;
        private System.Windows.Forms.ListBox lsbPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeletePlayer;
        private System.Windows.Forms.TextBox txtAddPlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSelectPlayer2;
        private System.Windows.Forms.ComboBox cmbSelectPlayer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

