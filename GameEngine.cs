namespace MoonBuggy {
    class GameEngine {
        private bool _isNotOver;
        private Scene _scene;
        private static GameEngine _gameEngine;
        private ScreenRender _screenRender;
        private GameSettings _gameSettings;
        private UIConroller _uIConroller;

        // объявление новой переменной (булевой), для

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
            Thread uIThread;
            do {
                _screenRender.ClearScene();
                _screenRender.Render(_scene);
                Thread.Sleep(_gameSettings.GameSpeed);
                _uIConroller = new UIConroller();
                _uIConroller.OnSpacePressed += (obj, arg) => _gameEngine.CalculateJumpBuggy();
                uIThread = new Thread(_uIConroller.StartListning);
                uIThread.Start();
                CalculateMoveObstruction();
            } while(_isNotOver);
            uIThread.Interrupt();
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

        public void CalculateJumpBuggy() {
            _scene.buggy.GameObjectPlace.YCoord--;
            Thread.Sleep(100);
            _scene.buggy.GameObjectPlace.YCoord--;
            Thread.Sleep(400);
            _scene.buggy.GameObjectPlace.YCoord++;
            Thread.Sleep(100);
            _scene.buggy.GameObjectPlace.YCoord++;    
        }
    }
}