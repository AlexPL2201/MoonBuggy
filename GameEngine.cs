namespace MoonBuggy {
    class GameEngine {
        public bool _isNotOver;
        private Scene _scene;
        private ScreenRender _screenRender;
        private GameSettings _gameSettings;
        public event EventHandler OnSpacePressed;


        
        public static GameEngine GetGameEngine(GameSettings gameSettings) {
            // if (_gameEngine == null) {
            GameEngine _gameEngine = new GameEngine(gameSettings);
            // }
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
                // Console.WriteLine(_screenRender._score); // !!!!!! обращение к счёту
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

        public void CalculateJumpBuggy() {
            _scene.buggy.GameObjectPlace.YCoord--;
            Thread.Sleep(100);
            _scene.buggy.GameObjectPlace.YCoord--;
            Thread.Sleep(400);
            _scene.buggy.GameObjectPlace.YCoord++;
            Thread.Sleep(100);
            _scene.buggy.GameObjectPlace.YCoord++;    
        }

        public void StartListning() {
            while (_isNotOver) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.Spacebar)) {
                    Console.Beep();
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}