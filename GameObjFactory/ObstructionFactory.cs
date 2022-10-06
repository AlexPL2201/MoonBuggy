namespace MoonBuggy {
    class ObstructionFactory: GameObjectFactory {
        public ObstructionFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObj GetGameObj(GameObjPlace objectPlace)
        {
            GameObj ObstructionObject = new Obstruction() {Figure = GameSettings.Obstruction, GameObjectPlace = objectPlace, GameObjectType = GameObjType.Obstruction};
            return ObstructionObject;
        }

        public GameObj GetGameObj() {
            GameObjPlace place = new GameObjPlace() { XCoord = GameSettings.ObstructionStartXCoord, YCoord = GameSettings.ObstructionStartYCoord };
            GameObj gameObj = GetGameObj(place);
            return gameObj;
        }
    }
}