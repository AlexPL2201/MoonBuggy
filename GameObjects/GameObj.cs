namespace MoonBuggy{
    abstract class GameObj {
        public GameObjPlace GameObjectPlace { get; set; }
        public char Figure { get; set; }
        public GameObjType GameObjectType { get; set; }
    }
}
