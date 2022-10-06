namespace MoonBuggy{
    class Program {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static UIConroller uIConroller;


        static void Main(string[] args) {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize() {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            
        }
    }
}