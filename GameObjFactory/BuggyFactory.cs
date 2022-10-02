namespace MoonBuggy {
    class BuggyFactory: GameObjectFactory {
        public BuggyFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObj GetGameObj(GameObjPlace objectPlace)
        {
            GameObj gameObj = new BuggyObj() { Figure = GameSettings.Buggy, GameObjectPlace = objectPlace, GameObjectType = GameObjType.Buggy };

            return gameObj;
        }

        public GameObj GetGameObj() {
            GameObjPlace place = new GameObjPlace() { XCoord = GameSettings.PlayerBuggyStartXCoord, YCoord = GameSettings.PlayerBuggyStartYCoord };
            GameObj gameObj = GetGameObj(place);
            return gameObj;
        }
    }
}