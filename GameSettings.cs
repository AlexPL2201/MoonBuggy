namespace MoonBuggy {
    class GameSettings {
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHeight { get; set; } = 30;

        public int PlayerBuggyStartXCoord { get; set; } = 20;
        public int PlayerBuggyStartYCoord { get; set; } = 21;
        // public List<char> Buggy = new List<char>() {'o', '=', 'o'};
        public char Buggy { get; set; } = 'o';

        public int GroundStartXCoord { get; set; } = 1;
        public int GroundStartYCoord { get; set; } = 21;
        public char Ground { get; set; } = '_';  
        public int NumberOfGroundRows { get; set; } = 2;
        public int NumberOfGroundColls { get; set; } = 80;

        public char Obstruction { get; set; } = '|';
        public int ObstructionStartXCoord { get; set; } = 60;
        public int ObstructionStartYCoord { get; set; } = 21;

        public int GameSpeed { get; set; } = 100;
    }
}