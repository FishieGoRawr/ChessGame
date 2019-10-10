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
            string tempName = "";
            switch (choix)
            {
                case "p1":
                    if (cmbSelectPlayer1.SelectedIndex != -1) //If something selected in cmb1, set tempName to selected name
                        tempName = cmbSelectPlayer1.SelectedItem.ToString();

                    cmbSelectPlayer1.Items.Clear();

                    foreach (var player in m_chessGame.PlayerList) //Loop through player list to populate the cmb
                        cmbSelectPlayer1.Items.Add(player.Name);

                    cmbSelectPlayer1.Items.Remove(cmbSelectPlayer2.SelectedItem.ToString()); //Remove the item selected in cmb2 from cmb1

                    if (tempName != "") //If a name was selected, set it back to the good entry
                        cmbSelectPlayer1.SelectedItem = tempName;
                    break;
                case "p2":
                    if (cmbSelectPlayer2.SelectedIndex != -1) //If something selected in cmb2, set tempName to selected name
                        tempName = cmbSelectPlayer2.SelectedItem.ToString();

                    cmbSelectPlayer2.Items.Clear();

                    foreach (var player in m_chessGame.PlayerList) //Loop through player list to populate the cmb
                        cmbSelectPlayer2.Items.Add(player.Name);

                    cmbSelectPlayer2.Items.Remove(cmbSelectPlayer1.SelectedItem.ToString());

                    if (tempName != "") //If a name was selected, set it back to the good entry
                        cmbSelectPlayer2.SelectedItem = tempName;
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
            string p1Name = "", p2Name = "";            

            if (!(cmbSelectPlayer1.SelectedIndex == -1) && !(cmbSelectPlayer2.SelectedIndex == -1))
            {
                p1Name = cmbSelectPlayer1.SelectedItem.ToString();
                p2Name = cmbSelectPlayer2.SelectedItem.ToString();

                m_chessGame.createGame(m_chessGame.PlayerList, p1Name, p2Name);
            }
            else
            {
                if (cmbSelectPlayer1.SelectedIndex == -1)
                    MessageBox.Show("Veuillez sélectionner le joueur #1.", "Aucun joueur #1 sélectionné", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Veuillez sélectionner le joueur #2.", "Aucun joueur #2 sélectionné", MessageBoxButtons.OK);
            }
        }

        private void CmbSelectPlayer1_DropDownClosed(object sender, EventArgs e)
        {
            reloadCmbPlayerSelection("p2");
            Console.WriteLine(cmbSelectPlayer1.SelectedIndex + "   " + cmbSelectPlayer2.SelectedIndex);
        }

        private void CmbSelectPlayer2_DropDownClosed(object sender, EventArgs e)
        {
            reloadCmbPlayerSelection("p1");
            Console.WriteLine(cmbSelectPlayer1.SelectedIndex + "   " + cmbSelectPlayer2.SelectedIndex);
        }
    }
}
