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
            Action wrongPlay = () => game.Play(Symbol.O, 0, 0);

            // Act
            var exception = Assert.Throws<Exception>(wrongPlay);
            // Assert
            Assert.Equal("Invalid first player", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow() //TODO: Bad name, introduce theory to also test O twice
        {
            // Arrange
            game.Play(Symbol.X, 0, 0);

            // Act
            Action wrongPlay = () => game.Play(Symbol.X, 1, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition() //TODO: Duplicate code, does about the same as the one below
        {
            // Arrange
            game.Play(Symbol.X, 0, 0);

            // Arrange
            Action wrongPlay = () => game.Play(Symbol.O, 0, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(Symbol.X, 0, 0);
            game.Play(Symbol.O, 1, 0);

            Action wrongPlay = () => game.Play(Symbol.X, 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message); //TODO: Magic number
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow() //TODO: Duplicate code, use Theory?
        {
            // Act //TODO: Comment not needed and actually wrong, Duplicate code
            game.Play(Symbol.X, 0, 0);
            game.Play(Symbol.O, 1, 0);
            game.Play(Symbol.X, 0, 1);
            game.Play(Symbol.O, 1, 1);
            game.Play(Symbol.X, 0, 2);

            // Arrange //TODO: Comment not needed and actually wrong,
            var winner = game.Winner();

            // Assert //TODO: Comment not needed and actually wrong,
            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow() //TODO: Duplicate code, use Theory?
        {
            game.Play(Symbol.X, 2, 2);
            game.Play(Symbol.O, 0, 0);
            game.Play(Symbol.X, 1, 0);
            game.Play(Symbol.O, 0, 1);
            game.Play(Symbol.X, 1, 1);
            game.Play(Symbol.O, 0, 2);

            var winner = game.Winner();

            Assert.Equal(Symbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow() //TODO: Duplicate code, use Theory?
        {
            game.Play(Symbol.X, 1, 0);
            game.Play(Symbol.O, 0, 0);
            game.Play(Symbol.X, 1, 1);
            game.Play(Symbol.O, 0, 1);
            game.Play(Symbol.X, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow() //TODO: Duplicate code, use Theory?
        {
            game.Play(Symbol.X, 0, 0);
            game.Play(Symbol.O, 1, 0);
            game.Play(Symbol.X, 2, 0);
            game.Play(Symbol.O, 1, 1);
            game.Play(Symbol.X, 2, 1);
            game.Play(Symbol.O, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Symbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow() //TODO: Duplicate code, use Theory?
        {
            game.Play(Symbol.X, 2, 0);
            game.Play(Symbol.O, 0, 0);
            game.Play(Symbol.X, 2, 1);
            game.Play(Symbol.O, 0, 1);
            game.Play(Symbol.X, 2, 2);

            var winner = game.Winner();

            Assert.Equal(Symbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow() //TODO: Duplicate code, use Theory?
        {
            // Arrange
            game.Play(Symbol.X, 0, 0);
            game.Play(Symbol.O, 2, 0);
            game.Play(Symbol.X, 1, 0);
            game.Play(Symbol.O, 2, 1);
            game.Play(Symbol.X, 1, 1);
            game.Play(Symbol.O, 2, 2);

            // Act
            var winner = game.Winner();
            // Assert
            Assert.Equal(Symbol.O, winner);
        }
    }
}
