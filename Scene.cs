namespace MoonBuggy {
    class Scene {
        public List <GameObj> ground;
        public GameObj buggy;
        // GameObj _alien;
        // GameObj _obstruction;
        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene(GameSettings gameSettings) {
            _gameSettings = gameSettings;
            ground = new GroundFactory(_gameSettings).GetGround();
            buggy = new BuggyFactory(_gameSettings).GetGameObj();
        }

        public static Scene GetScene(GameSettings gameSettings) {
            if (_scene == null) {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }
    }
}