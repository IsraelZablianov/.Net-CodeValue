using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        private readonly eCell r_CellMark;
        private string m_Name;

        public Player(eCell i_CellMark, string I_Name)
        {
            r_CellMark = i_CellMark;
            m_Name = I_Name;
        }

        public eCell CellMark
        {
            get
            {
                return r_CellMark;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
    }
}
