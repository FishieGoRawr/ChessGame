using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Move
    {
        //DONNEES MEMBRES
        private Player m_player;
        private Tile m_start;
        private Tile m_end;
        private Piece m_movedPiece;
        private Piece m_killedPiece;

        //ACCESSEURS
        public Player Player { get => m_player; set => m_player = value; }
        public Piece MovedPiece { get => m_movedPiece; set => m_movedPiece = value; }
        public Piece KilledPiece { get => m_killedPiece; set => m_killedPiece = value; }
        internal Tile Start { get => m_start; set => m_start = value; }
        internal Tile End { get => m_end; set => m_end = value; }

        //CONSTRUCTEURS
        public Move(Player p_player, Tile p_start)
        {
            this.m_player = p_player;
            this.m_start = p_start;
            this.m_end = null;
            this.m_movedPiece = m_start.CurrentPiece;
            this.m_killedPiece = null;
        }

        //METHODES
        public int[] getCoordFrom()
        {
            int[] coordFrom = { m_start.X, m_start.Y };
            return coordFrom;
        }

        public int[] getCoordTo()
        {
            int[] coordTo = { m_end.X, m_end.Y };
            return coordTo;
        }

        public bool isValidMovement()
        {
            bool validMovement = false;
            if (this.MovedPiece.GetType().Name != "Pawn")
            {
                validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo());
            }
            else
            {
                //If we are eating another piece
                if (!this.m_end.isOccupied())
                {
                    validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo(), false);
                }
                else
                {
                    validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo(), true);
                }

            }


            return validMovement;
        }


    }
}
