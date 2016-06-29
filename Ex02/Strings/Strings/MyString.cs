using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class MyString
    {
        private string m_String = string.Empty;
        private string[] m_ArrayOfWords;
        private readonly char r_Seperator = ' ';
        private bool m_EmptyString;

        public MyString()
        {
        }

        public string String
        {
            get
            {
                return m_String;
            }
            set
            {
                m_String = value;
                m_String = m_String.Trim();
                if(m_String == string.Empty)
                {
                    m_EmptyString = true;
                }

                m_ArrayOfWords = m_String.Split(r_Seperator);
            }
        }

        public string ArrayOfWords
        {
            get
            {
                return string.Join(r_Seperator.ToString(), m_ArrayOfWords); ;
            }
        }

        public int NumberOfWords
        {
            get
            {
                int length = 0;
                if (!m_EmptyString)
                {
                    length = m_ArrayOfWords.Length;
                }

                return length;        
            }
        }

        public void ReverseString()
        {
            if (!m_EmptyString)
            {
                Array.Reverse(m_ArrayOfWords);
            }
        }

        public void SortString()
        {
            if (!m_EmptyString)
            {
                Array.Sort(m_ArrayOfWords);
            }
        }
    }
}
