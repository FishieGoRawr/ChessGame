using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class mainMenu : Form
    {
        private ChessGame m_chessGame;

        public mainMenu(ChessGame chessGame)
        {
            m_chessGame = chessGame;
            InitializeComponent();
            m_chessGame.createPlayerFromFile();
            reloadMenuPlayers();
        }

        public void reloadMenuPlayers()
        {
            lsbPlayers.Items.Clear();
            cmbSelectPlayer1.Items.Clear();
            cmbSelectPlayer2.Items.Clear();

            foreach (var player in m_chessGame.PlayerList)
            {
                lsbPlayers.Items.Add(player.Name); //Remplie Lsbplayers, liste des joueurs incrit
                cmbSelectPlayer1.Items.Add(player.Name); //Remplie le cmb selection joueur 1
                cmbSelectPlayer2.Items.Add(player.Name); //Remplie le cmb selection joueur 2
            }
        }

        public void reloadCmbPlayerSelection(string choix)
        {
            switch (choix)
            {
                case "p1":
                    cmbSelectPlayer1.Items.Clear();
                    foreach (var player in m_chessGame.PlayerList)
                    { 
                        cmbSelectPlayer1.Items.Add(player.Name);
                    }
                    cmbSelectPlayer1.Items.Remove(cmbSelectPlayer2.SelectedItem.ToString());
                    break;
                case "p2":
                    cmbSelectPlayer2.Items.Clear();
                    foreach (var player in m_chessGame.PlayerList)
                        cmbSelectPlayer2.Items.Add(player.Name);

                    cmbSelectPlayer2.Items.Remove(cmbSelectPlayer1.SelectedItem.ToString());
                    break;
                default:
                    break;
            }
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            string playerName = txtAddPlayer.Text;
            bool duplicate = false;

            foreach (var name in lsbPlayers.Items) //Parcour lsb pour trouver duplictat de nom
            {
                if (playerName == (string)name)
                    duplicate = true;
            }

            if (!duplicate && !String.IsNullOrEmpty(playerName)) //Ajoute le nom si ok, sinon, affiche un erreur
            {
                lsbPlayers.Items.Add(playerName);
                txtAddPlayer.Clear();

                m_chessGame.createNewPlayer(playerName);
                m_chessGame.savePlayerList();
            }
            else if (String.IsNullOrEmpty(playerName))
                MessageBox.Show("Vous ne pouvez pas entrer un nom vide. Veuillez entrer un nom.", "Nom vide", MessageBoxButtons.OK);
            else if (duplicate)
                MessageBox.Show("Ce nom existe déjà. Veuillez entrer un autre nom.", "Nom identique trouvé", MessageBoxButtons.OK);

            reloadMenuPlayers();
        }

        private void BtnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (lsbPlayers.SelectedIndex == -1)
                MessageBox.Show("Vous devez sélectionné un nom pour le supprimer.", "Aucun nom sélectionné", MessageBoxButtons.OK);
            else
            {
                Player toRemove = null;
                string pName = lsbPlayers.SelectedItem.ToString();

                for (int i = 0; i < m_chessGame.PlayerList.Count(); i++)
                {
                    if (pName == m_chessGame.PlayerList[i].Name)
                    {
                        toRemove = m_chessGame.PlayerList[i];
                        break;
                    }
                }

                if (toRemove != null)
                    m_chessGame.PlayerList.Remove(toRemove);

                lsbPlayers.Items.RemoveAt(lsbPlayers.SelectedIndex);
                reloadMenuPlayers();
            }
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            //if (cmbSelectPlayer1.SelectedItem.ToString() == cmbSelectPlayer2.SelectedItem.ToString())
            //    MessageBox.Show("Jouer avec vous même ne serait pas très efficace... Veuillez choisir 2 joueurs différents!", "Choisir 2 joueurs différents.", MessageBoxButtons.OK);
            //else
                m_chessGame.createGame();

        }

        private void CmbSelectPlayer1_SelectedValueChanged(object sender, EventArgs e)
        {
            reloadCmbPlayerSelection("p2");
        }

        private void CmbSelectPlayer2_SelectedValueChanged(object sender, EventArgs e)
        {
            reloadCmbPlayerSelection("p1");
        }
    }
}
