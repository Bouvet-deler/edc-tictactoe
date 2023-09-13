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
            Action wrongPlay = () => game.Play(Tile.TileSymbol.O, 0, 0);

            // Act
            var exception = Assert.Throws<Exception>(wrongPlay);
            // Assert
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            // Arrange
            game.Play(Tile.TileSymbol.X, 0, 0);

            // Act
            Action wrongPlay = () => game.Play(Tile.TileSymbol.X, 1, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            // Arrange
            game.Play(Tile.TileSymbol.X, 0, 0);

            // Arrange
            Action wrongPlay = () => game.Play(Tile.TileSymbol.O, 0, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(Tile.TileSymbol.X, 0, 0);
            game.Play(Tile.TileSymbol.O, 1, 0);

            Action wrongPlay = () => game.Play(Tile.TileSymbol.X, 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow() //TODO: Duplicate code (both in setup and test as a whole), introduce Theory instead if Fact. True for all tests below
        {
            // Act
            game.Play(Tile.TileSymbol.X, 0, 0);
            game.Play(Tile.TileSymbol.O, 1, 0);
            game.Play(Tile.TileSymbol.X, 0, 1);
            game.Play(Tile.TileSymbol.O, 1, 1);
            game.Play(Tile.TileSymbol.X, 0, 2);

            // Arrange
            var winner = game.Winner();

            // Assert
            Assert.Equal(Tile.TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(Tile.TileSymbol.X, 2, 2);
            game.Play(Tile.TileSymbol.O, 0, 0);
            game.Play(Tile.TileSymbol.X, 1, 0);
            game.Play(Tile.TileSymbol.O, 0, 1);
            game.Play(Tile.TileSymbol.X, 1, 1);
            game.Play(Tile.TileSymbol.O, 0, 2);

            var winner = game.Winner();

            Assert.Equal(Tile.TileSymbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Tile.TileSymbol.X, 1, 0);
            game.Play(Tile.TileSymbol.O, 0, 0);
            game.Play(Tile.TileSymbol.X, 1, 1);
            game.Play(Tile.TileSymbol.O, 0, 1);
            game.Play(Tile.TileSymbol.X, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Tile.TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Tile.TileSymbol.X, 0, 0);
            game.Play(Tile.TileSymbol.O, 1, 0);
            game.Play(Tile.TileSymbol.X, 2, 0);
            game.Play(Tile.TileSymbol.O, 1, 1);
            game.Play(Tile.TileSymbol.X, 2, 1);
            game.Play(Tile.TileSymbol.O, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Tile.TileSymbol.O, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Tile.TileSymbol.X, 2, 0);
            game.Play(Tile.TileSymbol.O, 0, 0);
            game.Play(Tile.TileSymbol.X, 2, 1);
            game.Play(Tile.TileSymbol.O, 0, 1);
            game.Play(Tile.TileSymbol.X, 2, 2);

            var winner = game.Winner();

            Assert.Equal(Tile.TileSymbol.X, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            // Arrange
            game.Play(Tile.TileSymbol.X, 0, 0);
            game.Play(Tile.TileSymbol.O, 2, 0);
            game.Play(Tile.TileSymbol.X, 1, 0);
            game.Play(Tile.TileSymbol.O, 2, 1);
            game.Play(Tile.TileSymbol.X, 1, 1);
            game.Play(Tile.TileSymbol.O, 2, 2);

            // Act
            var winner = game.Winner();
            // Assert
            Assert.Equal(Tile.TileSymbol.O, winner);
        }
    }
}
