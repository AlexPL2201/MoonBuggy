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
                CalculateMoveObstruction();

            } while(_isNotOver);
        }

        public void CalculateMoveObstruction() {
            if (_scene.obstruction.GameObjectPlace.XCoord > 1) {
                if (_scene.obstruction.GameObjectPlace.XCoord == _scene.buggy.GameObjectPlace.XCoord && _scene.obstruction.GameObjectPlace.YCoord == _scene.buggy.GameObjectPlace.YCoord) {
                    _isNotOver = false;
                }

                _scene.obstruction.GameObjectPlace.XCoord--;
            }
            else {
                _scene.obstruction.GameObjectPlace.XCoord = _gameSettings.ConsoleWidth;
            }
        }
    }
}