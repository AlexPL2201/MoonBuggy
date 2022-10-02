namespace MoonBuggy {
    abstract class GameObjectFactory {
        public GameSettings GameSettings { get; set; }
        public abstract GameObj GetGameObj(GameObjPlace objectPlace);

        public GameObjectFactory(GameSettings gameSettings) {
            GameSettings = gameSettings;
        }
    }
}