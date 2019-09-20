﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Game
    {
        Player m_pWhite, m_pBlack;
        bool m_turn;
        Board m_board;
        gameGUI m_gameGUI;
        List<Piece> m_whiteEaten;
        List<Piece> m_blackEaten;

    }
}