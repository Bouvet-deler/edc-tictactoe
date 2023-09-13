using System;
using Xunit;
using tictactoe;

namespace tictactoeTests
{
    public class GameShould //TODO: Comment code smell (arrange act assert)
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
            Action wrongPlay = () => game.Play(TileSymbol.O, 0, 0);

            // Act
            var exception = Assert.Throws<Exception>(wrongPlay);
            // Assert
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            // Arrange
            game.Play(TileSymbol.X, 0, 0);

            // Act
            Action wrongPlay = () => game.Play(TileSymbol.X, 1, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            // Arrange
            game.Play(TileSymbol.X, 0, 0);

            // Arrange
            Action wrongPlay = () => game.Play(TileSymbol.O, 0, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(TileSymbol.X, 0, 0);
            game.Play(TileSymbol.O, 1, 0);

            Action wrongPlay = () => game.Play(TileSymbol.X, 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow() //TODO: Duplicate code (both in setup and test as a whole), introduce Theory instead if Fact. True for all tests below
        {
            // Act
            game.Play(TileSymbol.X, 0, 0);
            game.Play(TileSymbol.O, 1, 0);
            game.Play(TileSymbol.X, 0, 1);
            game.Play(TileSymbol.O, 1, 1);
            game.Play(TileSymbol.X, 0, 2);

            // Arrange
            var winner = game.CheckWinner();

            // Assert
            Assert.Equal(TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(TileSymbol.X, 2, 2);
            game.Play(TileSymbol.O, 0, 0);
            game.Play(TileSymbol.X, 1, 0);
            game.Play(TileSymbol.O, 0, 1);
            game.Play(TileSymbol.X, 1, 1);
            game.Play(TileSymbol.O, 0, 2);

            var winner = game.CheckWinner();

            Assert.Equal(TileSymbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(TileSymbol.X, 1, 0);
            game.Play(TileSymbol.O, 0, 0);
            game.Play(TileSymbol.X, 1, 1);
            game.Play(TileSymbol.O, 0, 1);
            game.Play(TileSymbol.X, 1, 2);

            var winner = game.CheckWinner();

            Assert.Equal(TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(TileSymbol.X, 0, 0);
            game.Play(TileSymbol.O, 1, 0);
            game.Play(TileSymbol.X, 2, 0);
            game.Play(TileSymbol.O, 1, 1);
            game.Play(TileSymbol.X, 2, 1);
            game.Play(TileSymbol.O, 1, 2);

            var winner = game.CheckWinner();

            Assert.Equal(TileSymbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(TileSymbol.X, 2, 0);
            game.Play(TileSymbol.O, 0, 0);
            game.Play(TileSymbol.X, 2, 1);
            game.Play(TileSymbol.O, 0, 1);
            game.Play(TileSymbol.X, 2, 2);

            var winner = game.CheckWinner();

            Assert.Equal(TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            // Arrange
            game.Play(TileSymbol.X, 0, 0);
            game.Play(TileSymbol.O, 2, 0);
            game.Play(TileSymbol.X, 1, 0);
            game.Play(TileSymbol.O, 2, 1);
            game.Play(TileSymbol.X, 1, 1);
            game.Play(TileSymbol.O, 2, 2);

            // Act
            var winner = game.CheckWinner();
            // Assert
            Assert.Equal(TileSymbol.O, winner);
        }
    }
}
