namespace MoonBuggy {
    class GameEngine {
        private bool _isNotOver;
        private Scene _scene;
        private static GameEngine _gameEngine;
        private ScreenRender _screenRender;

        private GameEngine() {

        }

        public static GameEngine GetGameEngine(GameSettings gameSettings) {
            if (_gameEngine == null) {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }

        private GameEngine(GameSettings gameSettings) {
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _screenRender = new ScreenRender(gameSettings);
        }

        public void Run() {
            do {
                _screenRender.Render(_scene);


            } while(_isNotOver);
        }
    }
}