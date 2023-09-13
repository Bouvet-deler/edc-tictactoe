using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Position
    {
        private int _row;
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                if (value < 0 || value > 2)
                    throw new ArgumentException("Invalid value for row");

                _row = value;
            }
        }


        private int _column;
        public int Column 
        { 
            get
            {
                return _column;
            }
            set
            {
                if (value < 0 || value > 2)
                    throw new ArgumentException("Invalid value for column");

                _column = value;
            }
        }
    }
}
