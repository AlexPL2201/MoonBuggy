namespace MoonBuggy {
    class Scene {
        public List <GameObj> ground;
        public GameObj buggy;
        // GameObj _alien;
        public GameObj obstruction;
        private GameSettings _gameSettings;
        // public GameObj score;

        private static Scene _scene;

        private Scene(GameSettings gameSettings) {
            _gameSettings = gameSettings;
            ground = new GroundFactory(_gameSettings).GetGround();
            obstruction = new ObstructionFactory(_gameSettings).GetGameObj();
            buggy = new BuggyFactory(_gameSettings).GetGameObj();
            // score = new Score()
        }

        public static Scene GetScene(GameSettings gameSettings) {
            // if (_scene == null) {
            _scene = new Scene(gameSettings);
            // }
            return _scene;
        }
    }
}