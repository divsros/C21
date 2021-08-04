using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    public class Player
    {
        private int points;
        private char sign;
        public  Player(char i_Sign='X', int i_Points = 0)
        {
            sign = i_Sign;
            points = i_Points;
        }
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
        public char Sign
        {
            get
            {
                return sign;
            }
            set
            {
                if (value == 'X' || value == 'O')
                    sign = value;
            }
        }
    }
}