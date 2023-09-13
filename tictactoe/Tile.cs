namespace tictactoe
{
    public class Tile //TODO: Large class (file). Move to separate file
    {
        public Position Position { get; set; }

        public int X { get; set; } //TODO: Primitive obsession
        public int Y { get; set; } //TODO: Primitive obsession
        public char Symbol { get; set; }
    }
}
