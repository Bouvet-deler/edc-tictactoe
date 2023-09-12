using System; //TODO: Dead code, remove
using Xunit;
using tictactoe;

namespace tictactoeTests
{
    public class GameShould
    {
        private Game game;

        public GameShould()
        {
            game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            // Arrange
            Action wrongPlay = () => game.MakeMove(0, 0, Symbol.O);

            // Act
            var exception = Assert.Throws<Exception>(wrongPlay);
            // Assert
            Assert.Equal("Invalid first player", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow() //TODO: Bad name, introduce theory to also test O twice
        {
            // Arrange
            game.MakeMove(0, 0, Symbol.X);

            // Act
            Action wrongPlay = () => game.MakeMove(1, 0, Symbol.X);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition() //TODO: Duplicate code, does about the same as the one below
        {
            // Arrange
            game.MakeMove(0, 0, Symbol.X);

            // Arrange
            Action wrongPlay = () => game.MakeMove(0, 0, Symbol.O);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.MakeMove(0, 0, Symbol.X);
            game.MakeMove(1, 0, Symbol.O);

            Action wrongPlay = () => game.MakeMove(0, 0, Symbol.X);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow() //TODO: Duplicate code, use Theory?
        {
            // Act //TODO: Comment not needed and actually wrong, Duplicate code
            game.MakeMove(0, 0, Symbol.X);
            game.MakeMove(1, 0, Symbol.O);
            game.MakeMove(0, 1, Symbol.X);
            game.MakeMove(1, 1, Symbol.O);
            game.MakeMove(0, 2, Symbol.X);

            // Arrange //TODO: Comment not needed and actually wrong,
            var winner = game.CheckWinner();

            // Assert //TODO: Comment not needed and actually wrong,
            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow() //TODO: Duplicate code, use Theory?
        {
            game.MakeMove(2, 2, Symbol.X);
            game.MakeMove(0, 0, Symbol.O);
            game.MakeMove(1, 0, Symbol.X);
            game.MakeMove(0, 1, Symbol.O);
            game.MakeMove(1, 1, Symbol.X);
            game.MakeMove(0, 2, Symbol.O);

            var winner = game.CheckWinner();

            Assert.Equal(Symbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow() //TODO: Duplicate code, use Theory?
        {
            game.MakeMove(1, 0, Symbol.X);
            game.MakeMove(0, 0, Symbol.O);
            game.MakeMove(1, 1, Symbol.X);
            game.MakeMove(0, 1, Symbol.O);
            game.MakeMove(1, 2, Symbol.X);

            var winner = game.CheckWinner();

            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow() //TODO: Duplicate code, use Theory?
        {
            game.MakeMove(0, 0, Symbol.X);
            game.MakeMove(1, 0, Symbol.O);
            game.MakeMove(2, 0, Symbol.X);
            game.MakeMove(1, 1, Symbol.O);
            game.MakeMove(2, 1, Symbol.X);
            game.MakeMove(1, 2, Symbol.O);

            var winner = game.CheckWinner();

            Assert.Equal(Symbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow() //TODO: Duplicate code, use Theory?
        {
            game.MakeMove(2, 0, Symbol.X);
            game.MakeMove(0, 0, Symbol.O);
            game.MakeMove(2, 1, Symbol.X);
            game.MakeMove(0, 1, Symbol.O);
            game.MakeMove(2, 2, Symbol.X);

            var winner = game.CheckWinner();

            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow() //TODO: Duplicate code, use Theory?
        {
            // Arrange
            game.MakeMove(0, 0, Symbol.X);
            game.MakeMove(2, 0, Symbol.O);
            game.MakeMove(1, 0, Symbol.X);
            game.MakeMove(2, 1, Symbol.O);
            game.MakeMove(1, 1, Symbol.X);
            game.MakeMove(2, 2, Symbol.O);

            // Act
            var winner = game.CheckWinner();
            // Assert
            Assert.Equal(Symbol.O, winner);
        }
    }
}
