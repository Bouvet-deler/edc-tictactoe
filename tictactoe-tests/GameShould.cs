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
            Action wrongPlay = () => game.Play(Constants.Circle, 0, 0);

            // Act
            var exception = Assert.Throws<Exception>(wrongPlay);
            // Assert
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            // Arrange
            game.Play(Constants.Cross, 0, 0);

            // Act
            Action wrongPlay = () => game.Play(Constants.Cross, 1, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            // Arrange
            game.Play(Constants.Cross, 0, 0);

            // Arrange
            Action wrongPlay = () => game.Play(Constants.Circle, 0, 0);

            // Assert
            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(Constants.Cross, 0, 0);
            game.Play(Constants.Circle, 1, 0);

            Action wrongPlay = () => game.Play(Constants.Cross, 0, 0);

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow() //TODO: Duplicate code (both in setup and test as a whole), introduce Theory instead if Fact. True for all tests below
        {
            // Act
            game.Play(Constants.Cross, 0, 0);
            game.Play(Constants.Circle, 1, 0);
            game.Play(Constants.Cross, 0, 1);
            game.Play(Constants.Circle, 1, 1);
            game.Play(Constants.Cross, 0, 2);

            // Arrange
            var winner = game.Winner();

            // Assert
            Assert.Equal(Constants.Cross, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(Constants.Cross, 2, 2);
            game.Play(Constants.Circle, 0, 0);
            game.Play(Constants.Cross, 1, 0);
            game.Play(Constants.Circle, 0, 1);
            game.Play(Constants.Cross, 1, 1);
            game.Play(Constants.Circle, 0, 2);

            var winner = game.Winner();

            Assert.Equal(Constants.Circle, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Constants.Cross, 1, 0);
            game.Play(Constants.Circle, 0, 0);
            game.Play(Constants.Cross, 1, 1);
            game.Play(Constants.Circle, 0, 1);
            game.Play(Constants.Cross, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Constants.Cross, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(Constants.Cross, 0, 0);
            game.Play(Constants.Circle, 1, 0);
            game.Play(Constants.Cross, 2, 0);
            game.Play(Constants.Circle, 1, 1);
            game.Play(Constants.Cross, 2, 1);
            game.Play(Constants.Circle, 1, 2);

            var winner = game.Winner();

            Assert.Equal(Constants.Circle, winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(Constants.Cross, 2, 0);
            game.Play(Constants.Circle, 0, 0);
            game.Play(Constants.Cross, 2, 1);
            game.Play(Constants.Circle, 0, 1);
            game.Play(Constants.Cross, 2, 2);

            var winner = game.Winner();

            Assert.Equal(Constants.Cross, winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            // Arrange
            game.Play(Constants.Cross, 0, 0);
            game.Play(Constants.Circle, 2, 0);
            game.Play(Constants.Cross, 1, 0);
            game.Play(Constants.Circle, 2, 1);
            game.Play(Constants.Cross, 1, 1);
            game.Play(Constants.Circle, 2, 2);

            // Act
            var winner = game.Winner();
            // Assert
            Assert.Equal(Constants.Circle, winner);
        }
    }
}
