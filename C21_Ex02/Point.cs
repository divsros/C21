using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    struct Point
    {
        private int x;
        private int y;


        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public void SetPoint(int i_X, int i_Y)
        {
            this.x = i_X;
            this.y = i_Y;
        }
        public void AddValues(int i_X, int i_Y)
        {
            this.x += i_X;
            this.y += i_Y;
        }


    }
}
