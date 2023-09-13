using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace tictactoe
{

    public class Game
    {
        private char _lastSymbol = Constants.EMPTYTILE;
        private Board _board = new(); 

        public void Play(char symbol, int x, int y) //TODO: Introduce assertion
        {
            ValidatePlay(symbol, x, y);

            // update game state
            _lastSymbol = symbol;
            _board.AddSymbolAtTile(x, y, symbol);
        }

        private void ValidatePlay(char symbol, int x, int y)
        {
            // if first move
            if (_lastSymbol == Constants.EMPTYTILE) //Todo: Complicated if statements, and not really related
            {
                //if player is X //TODO: Comment, it's wrong
                if (symbol == 'O')
                {
                    throw new Exception("Invalid first player"); //TODO: Should implement a more specific exception type
                }
            }
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            else if (_board.GetTileAtPosition(x, y).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }

            if ((x is < 0 or > Constants.BOARDSIZE-1) | (y is < 0 or > Constants.BOARDSIZE-1))
            {
                throw new Exception("Invalid position on board");
            }
        }

        public char DecideWinner() //TODO: magic numbers all over (row number, column number, empty tile, 
        {   //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.GetTileAtPosition(0, 0).Symbol != ' ' &&
               _board.GetTileAtPosition(0, 1).Symbol != ' ' &&
               _board.GetTileAtPosition(0, 2).Symbol != ' ')
            {
                //if first row is full with same symbol
                if (_board.GetTileAtPosition(0, 0).Symbol ==
                    _board.GetTileAtPosition(0, 1).Symbol &&
                    _board.GetTileAtPosition(0, 2).Symbol ==
                    _board.GetTileAtPosition(0, 1).Symbol)
                {
                    return _board.GetTileAtPosition(0, 0).Symbol;
                }
            }

            //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.GetTileAtPosition(1, 0).Symbol != ' ' &&
               _board.GetTileAtPosition(1, 1).Symbol != ' ' &&
               _board.GetTileAtPosition(1, 2).Symbol != ' ')
            {
                //if middle row is full with same symbol
                if (_board.GetTileAtPosition(1, 0).Symbol ==
                    _board.GetTileAtPosition(1, 1).Symbol &&
                    _board.GetTileAtPosition(1, 2).Symbol ==
                    _board.GetTileAtPosition(1, 1).Symbol)
                {
                    return _board.GetTileAtPosition(1, 0).Symbol;
                }
            }

            //if the positions in first row are taken //TODO: Comment code smell, and comment is incorrect, duplicate code
            if (_board.GetTileAtPosition(2, 0).Symbol != ' ' &&
               _board.GetTileAtPosition(2, 1).Symbol != ' ' &&
               _board.GetTileAtPosition(2, 2).Symbol != ' ')
            {
                //if middle row is full with same symbol
                if (_board.GetTileAtPosition(2, 0).Symbol ==
                    _board.GetTileAtPosition(2, 1).Symbol &&
                    _board.GetTileAtPosition(2, 2).Symbol ==
                    _board.GetTileAtPosition(2, 1).Symbol)
                {
                    return _board.GetTileAtPosition(2, 0).Symbol;
                }
            }

            return ' ';
        }
    }
}
