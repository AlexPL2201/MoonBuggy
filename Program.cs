namespace MoonBuggy{
    class Program {
        static GameEngine gameEngine;
        static GameSettings gameSettings;


        static void Main(string[] args) {
            Initialize();
            // Меню проги
            gameEngine.Run();
        }

        public static void Initialize() {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
        }
    }
}