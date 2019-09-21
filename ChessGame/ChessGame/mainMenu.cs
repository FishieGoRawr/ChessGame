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
            fillListBoxPlayer();
        }

        public void fillListBoxPlayer()
        {
            foreach (var player in m_chessGame.PlayerList)
            {
                lsbPlayers.Items.Add(player.Name);                
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
        }

        private void BtnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (lsbPlayers.SelectedIndex == -1)
                MessageBox.Show("Vous devez sélectionné un nom pour le supprimer.", "Aucun nom sélectionné", MessageBoxButtons.OK);
            else
                lsbPlayers.Items.RemoveAt(lsbPlayers.SelectedIndex);
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            m_chessGame.createGame();

        }
    }
}
