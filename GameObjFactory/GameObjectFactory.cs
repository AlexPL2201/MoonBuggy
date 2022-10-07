namespace MoonBuggy {
    abstract class GameObjectFactory {
        public GameSettings GameSettings { get; set; }
        public abstract GameObj GetGameObj(ref GameObjPlace objectPlace);

        public GameObjectFactory(GameSettings gameSettings) {
            GameSettings = gameSettings;
        }
    }
}