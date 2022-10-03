namespace MoonBuggy {
    class GameEngine {
        private bool _isNotOver;
        private Scene _scene;
        private static GameEngine _gameEngine;
        private ScreenRender _screenRender;
        private GameSettings _gameSettings;

        private GameEngine() {

        }

        public static GameEngine GetGameEngine(GameSettings gameSettings) {
            if (_gameEngine == null) {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }

        private GameEngine(GameSettings gameSettings) {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _screenRender = new ScreenRender(gameSettings);
        }

        public void Run() {
            do {
                _screenRender.ClearScene();
                _screenRender.Render(_scene);
                Thread.Sleep(_gameSettings.GameSpeed);

            } while(_isNotOver);
        }
    }
}