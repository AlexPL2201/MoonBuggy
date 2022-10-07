namespace MoonBuggy{
    class Program {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static Thread uIThread;


        static void Main(string[] args) {
            GameMenu gameMenu = new GameMenu();
            bool _isMenu = true;
            do{
                int selectedIndex = gameMenu.RunMenu();
                switch (selectedIndex){
                    case 0:
                        Initialize();
                        gameEngine.Run();
                    break;
                    case 1:
                        break;
                    case 2:
                        _isMenu = false;
                        break;
                }
            } while(_isMenu);
        }

        public static void Initialize() {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            KeyBoard();
        }

        public static void KeyBoard() {
            gameEngine.OnSpacePressed += (obj, arg) => gameEngine.CalculateJumpBuggy();
            Thread uIThread = new Thread(gameEngine.StartListning);
            uIThread.Start();
        }
    }
}