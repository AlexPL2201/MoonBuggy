using System.Collections.Generic;

namespace MoonBuggy {
    class GroundFactory : GameObjectFactory {
        public GroundFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObj GetGameObj(GameObjPlace objectPlace)
        {
            GameObj groundObject = new GroundObj() { Figure = GameSettings.Ground, GameObjectPlace = objectPlace, GameObjectType = GameObjType.GroundObj };
            return groundObject;

        }

        public List<GameObj> GetGround() {
            List<GameObj> ground = new List<GameObj> ();

            int startX = GameSettings.GroundStartXCoord;
            int starty = GameSettings.GroundStartYCoord;

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++) {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++) {
                    GameObjPlace objectPlace = new GameObjPlace() {XCoord = startX + x, YCoord = starty + y};
                    GameObj groundObj = GetGameObj(objectPlace);
                    ground.Add(groundObj);
                }
            }
            return ground;
        }
    }
}