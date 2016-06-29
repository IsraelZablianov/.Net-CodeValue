using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGameUI
    {
        private TicTacToeGame m_Game = new TicTacToeGame();
        private bool m_IsGameOver;
        private Player m_Player1 = new Player(eCell.X, "Player1");
        private Player m_Player2 = new Player(eCell.O, "Player2");
        private StringBuilder m_RowsDisplay = new StringBuilder();
        private StringBuilder m_ColsDisplay = new StringBuilder();
        private StringBuilder m_NumberOfRowDisplay = new StringBuilder();

        public TicTacToeGameUI()
        {
            for (int i = 0; i < m_Game.SizeOfMatrix; i++)
            {
                m_NumberOfRowDisplay.AppendFormat("   {0}", i + 1);
            }

            m_ColsDisplay.Append("|");
            m_RowsDisplay.Append(" ");
            for (int i = 0; i < m_Game.SizeOfMatrix; i++)
            {
                m_ColsDisplay.Append("   |");
                m_RowsDisplay.Append(" ===");
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
        }

        private void TurnOfPlayer(Player i_Player)
        {
            bool makedAMove = false;
            do
            {
                Console.WriteLine("{0} make your move (in format of Row 'Enter' col)", i_Player.Name);
                makedAMove = ValidInput(Console.ReadLine(), Console.ReadLine(), i_Player);
            }
            while (!makedAMove);
            ShowBoard();
            if (m_Game.CheckIfWin(i_Player.CellMark))
            {
                m_IsGameOver = true;
                Console.WriteLine("{0} won!!!!!", i_Player.Name);
            }
            else if(m_Game.CheckIfMatrixFull())
            {
                m_IsGameOver = true;
                Console.WriteLine("Tie!!!");
            }
        }

        public void StartGame()
        {
            ShowEmptyBoard();
            do
            {
                TurnOfPlayer(m_Player1);
                if (!IsGameOver)
                {
                    TurnOfPlayer(m_Player2);
                }
            }
            while (!IsGameOver);
        }

        private bool ValidInput(string i_Row, string i_Col, Player i_Player)
        {
            int row = 0, col = 0;
            bool goodInput = int.TryParse(i_Row, out row) && int.TryParse(i_Col, out col);
            if(goodInput)
            {
                row--;
                col--;
                goodInput = m_Game.SelectMove(row, col, i_Player.CellMark);
            }

            return goodInput;
        }

        private void ShowEmptyBoard()
        {
            Console.Clear();
            Console.WriteLine(m_NumberOfRowDisplay);
            Console.WriteLine(m_RowsDisplay);
            for(int i = 0; i < m_Game.SizeOfMatrix; i++)
            {
                Console.WriteLine("{0}{1}", i + 1, m_ColsDisplay);
                Console.WriteLine(m_RowsDisplay);
            }
        }

        private void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine(m_NumberOfRowDisplay);
            Console.WriteLine(m_RowsDisplay);
            m_ColsDisplay.Clear();
            for (int i = 0; i < m_Game.SizeOfMatrix; i++)
            {
                m_ColsDisplay.Append("|");
                for (int j = 0; j < m_Game.SizeOfMatrix; j++)
                {
                    if (m_Game.matrix[i, j] == eCell.X)
                    {
                        m_ColsDisplay.Append(" X |");
                    }
                    else if(m_Game.matrix[i, j] == eCell.O)
                    {
                        m_ColsDisplay.Append(" O |");
                    }
                    else
                    {
                        m_ColsDisplay.Append("   |");
                    }
                }
                Console.WriteLine("{0}{1}", i + 1, m_ColsDisplay);
                m_ColsDisplay.Clear();
                Console.WriteLine(m_RowsDisplay);
            }
        }
    }
}
