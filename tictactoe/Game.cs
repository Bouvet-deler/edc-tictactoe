namespace tictactoe
{

    public class Game
    {
        public static readonly char emptyTile = ' ';
        private char _lastSymbol = emptyTile;
        private Board _board = new Board();

        public void Play(char symbol, int x, int y)
        {
            CheckForValidPlay(symbol, x, y);

            // update game state
            _lastSymbol = symbol;
            _board.PlayATileAt(x, y, symbol);
        }

        private void CheckForValidPlay(char symbol, int x, int y)
        {
            CheckIfPositionIsOnBoard(x);
            CheckIfPositionIsOnBoard(y);

            if (_lastSymbol == emptyTile && symbol == 'O')
            {
                throw new Exception("Invalid first player"); //TODO: Should implement a more specific exception type
            }
            //if not first move but player repeated
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            if (_board.GetTileAtPosition(x, y).Symbol != emptyTile)
            {
                throw new Exception("Invalid position");
            }
        }

        private static void CheckIfPositionIsOnBoard(int position)
        {
            if (position < 0 || position > 2)
            {
                throw new Exception($"Invalid value for position: {position}");
            }
        }

        private char CheckColumnForWinningSymbol(int columnNumber)
        {
            if (_board.GetTileAtPosition(0, columnNumber).Symbol != emptyTile &&
                _board.GetTileAtPosition(1, columnNumber).Symbol != emptyTile &&
                _board.GetTileAtPosition(2, columnNumber).Symbol != emptyTile)
            {
                if (_board.GetTileAtPosition(0, columnNumber).Symbol == _board.GetTileAtPosition(1, columnNumber).Symbol &&
                    _board.GetTileAtPosition(2, columnNumber).Symbol == _board.GetTileAtPosition(1, columnNumber).Symbol)
                {
                    return _board.GetTileAtPosition(0, columnNumber).Symbol;
                }
            }

            return emptyTile;
        }

        private char CheckRowForWinningSymbol(int rowNumber)
        {
            if (_board.GetTileAtPosition(rowNumber, 0).Symbol != emptyTile &&
                _board.GetTileAtPosition(rowNumber, 1).Symbol != emptyTile &&
                _board.GetTileAtPosition(rowNumber, 2).Symbol != emptyTile)
            {
                if (_board.GetTileAtPosition(rowNumber, 0).Symbol == _board.GetTileAtPosition(rowNumber, 1).Symbol &&
                    _board.GetTileAtPosition(rowNumber, 2).Symbol == _board.GetTileAtPosition(rowNumber, 1).Symbol)
                {
                    return _board.GetTileAtPosition(rowNumber, 0).Symbol;
                }
            }
            
            return emptyTile;
        }

        private char CheckDiagonalsForWinningSymbol()
        {
            if (_board.GetTileAtPosition(0, 0).Symbol != emptyTile &&
                _board.GetTileAtPosition(1, 1).Symbol != emptyTile &&
                _board.GetTileAtPosition(2, 2).Symbol != emptyTile)
            {
                if (_board.GetTileAtPosition(0, 0).Symbol == _board.GetTileAtPosition(1, 1).Symbol &&
                    _board.GetTileAtPosition(2, 2).Symbol == _board.GetTileAtPosition(1, 1).Symbol)
                {
                    return _board.GetTileAtPosition(1, 1).Symbol;
                }
            }
            if (_board.GetTileAtPosition(0, 2).Symbol != emptyTile &&
                _board.GetTileAtPosition(1, 1).Symbol != emptyTile &&
                _board.GetTileAtPosition(2, 0).Symbol != emptyTile)
            {
                if (_board.GetTileAtPosition(0, 2).Symbol == _board.GetTileAtPosition(1, 1).Symbol &&
                    _board.GetTileAtPosition(2, 0).Symbol == _board.GetTileAtPosition(1, 1).Symbol)
                {
                    return _board.GetTileAtPosition(1, 1).Symbol;
                }
            }
            return emptyTile;
        }

        public char DecideWhoWins() // duplicate code
        {
            var WinningSymbol = CheckRowForWinningSymbol(0);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            WinningSymbol = CheckRowForWinningSymbol(1);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            WinningSymbol = CheckRowForWinningSymbol(2);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;


            WinningSymbol = CheckColumnForWinningSymbol(0);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            WinningSymbol = CheckColumnForWinningSymbol(1);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            WinningSymbol = CheckColumnForWinningSymbol(2);
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            WinningSymbol = CheckDiagonalsForWinningSymbol();
            if (WinningSymbol != emptyTile)
                return WinningSymbol;

            return emptyTile;
        }
    }
}
