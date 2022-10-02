namespace MoonBuggy {
    class Scene {
        List <GameObj> _ground;
        GameObj _buggy;
        GameObj _alien;
        GameObj _obstruction;
        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene(GameSettings gameSettings) {
            _gameSettings = gameSettings;
            _ground = new GroundFactory(_gameSettings).GetGround();
            _buggy = new BuggyFactory(_gameSettings).GetGameObj();
        }

        public static Scene GetScene(GameSettings gameSettings) {
            if (_scene == null) {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }
    }
}