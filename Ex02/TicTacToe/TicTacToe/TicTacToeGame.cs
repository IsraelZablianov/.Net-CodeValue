using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// default cell equals to zero 
    /// in our case empty
    /// </summary>
    public enum eCell
    {
        X = 1,
        O = 2,
        Empty = 0
    }

    class TicTacToeGame
    {
        private const int K_SizeOfMatrix = 3;
        private eCell[,] m_matrix = new eCell[K_SizeOfMatrix, K_SizeOfMatrix];

        public eCell[,] matrix
        {
            get
            {
                return m_matrix;
            }
        }

        public int SizeOfMatrix
        {
            get
            {
                return K_SizeOfMatrix;
            }
        }

        public bool SelectMove(int i_Row, int i_Col, eCell i_PlayerMark)
        {
            bool legal = checkIfLegal(i_Row, i_Col);
            if(legal)
            {
                m_matrix[i_Row, i_Col] = i_PlayerMark;
            }

            return legal;
        }

        private bool checkIfLegal(int i_Row, int i_Col)
        {
            return i_Row < K_SizeOfMatrix && i_Row >= 0 && i_Col < K_SizeOfMatrix && i_Col >= 0 && CheckIfEmptyCell(i_Row, i_Col);
        }

        private bool CheckIfEmptyCell(int i_Row, int i_Col)
        {
            return m_matrix[i_Row, i_Col] == eCell.Empty;
        }

        public bool CheckIfMatrixFull()
        {
            bool full = true;
            foreach (eCell cell in m_matrix)
            {
                if(cell == eCell.Empty)
                {
                    full = false;
                    break;
                }
            }

            return full;
        }

        public bool CheckIfWin(eCell i_PlayerMark)
        {
            return CheckIfWinByRows(i_PlayerMark) || CheckIfWinByCols(i_PlayerMark) || CheckIfWinByDiagonal(i_PlayerMark);
        }

        private bool CheckIfWinByRows(eCell i_PlayerMark)
        {
            int countMarks = 0;
            bool win = false;
            for(int i = 0; i < K_SizeOfMatrix && !win; i++)
            {
                for (int j = 0; j < K_SizeOfMatrix; j++)
                {
                    if(m_matrix[i,j] == i_PlayerMark)
                    {
                        countMarks++;
                    }
                }

                if (countMarks == K_SizeOfMatrix)
                {
                    win = true;
                }
                else
                {
                    countMarks = 0;
                }
            }

            return win;
        }

        private bool CheckIfWinByCols(eCell i_PlayerMark)
        {
            int countMarks = 0;
            bool win = false;
            for (int i = 0; i < K_SizeOfMatrix && !win; i++)
            {
                for (int j = 0; j < K_SizeOfMatrix; j++)
                {
                    if (m_matrix[j, i] == i_PlayerMark)
                    {
                        countMarks++;
                    }
                }

                if (countMarks == K_SizeOfMatrix)
                {
                    win = true;
                }
                else
                {
                    countMarks = 0;
                }
            }

            return win;
        }

        private bool CheckIfWinByDiagonal(eCell i_PlayerMark)
        {
            int countMarksMainDiagonal = 0;
            int countMarksSecondDiagonal = 0;
            bool win = false;
            for (int j = 0; j < K_SizeOfMatrix; j++)
            {
                if (m_matrix[j, j] == i_PlayerMark)
                {
                    countMarksMainDiagonal++;
                }

                if (m_matrix[j, K_SizeOfMatrix - 1 - j] == i_PlayerMark)
                {
                    countMarksSecondDiagonal++;
                }
            }

            if (countMarksMainDiagonal == K_SizeOfMatrix || countMarksSecondDiagonal == K_SizeOfMatrix)
            {
                win = true;
            }

            return win;
        }
    }
}
