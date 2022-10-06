using System.Text;


namespace MoonBuggy {
    class ScreenRender {
        int _screenWidth;
        int _screenHeight;
        char[,] _screenMatrix;

        public ScreenRender(GameSettings gameSettings) {
            _screenWidth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _screenMatrix = new char [gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            // Console.WindowHeight = gameSettings.ConsoleHeight;
            // Console.WindowWidth = gameSettings.ConsoleWidth;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

        }

        public void Render(Scene scene) {
            Console.SetCursorPosition(0, 0);
            AddListForRendering(scene.ground);
            AddGameObjectForRendering(scene.buggy);
            AddGameObjectForRendering(scene.obstruction);

//          Хотя класс System.String предоставляет нам широкую функциональность по работе со строками, 
//          все таки он имеет свои недостатки. Прежде всего, объект String представляет собой неизменяемую строку.
//          Когда мы выполняем какой-нибудь метод класса String, система создает новый объект в памяти с выделением 
//          ему достаточного места. Удаление первого символа - не самая затратная операция. Однако когда подобных операций 
//          множество, а объем текста, для которого надо выполнить данные операции, также не самый маленький, то 
//          издержки при потере производительности становятся более существенными. Чтобы выйти из этой ситуации во 
//          фреймворк .NET был добавлен новый класс StringBuilder, который находится в пространстве имен System.Text.
//          Этот класс представляет динамическую строку.

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWidth; x++) {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);

        }

        public void AddGameObjectForRendering(GameObj gameObj) {
            if (gameObj.GameObjectPlace.YCoord < _screenMatrix.GetLength(0) && gameObj.GameObjectPlace.XCoord < _screenMatrix.GetLength(1)) {
                _screenMatrix[gameObj.GameObjectPlace.YCoord, gameObj.GameObjectPlace.XCoord] = gameObj.Figure;
            }
            else {
                ;// _screenMatrix[gameObj.GameObjectPlace.YCoord, gameObj.GameObjectPlace.XCoord] = ' ';
            }
        }

        public void AddListForRendering(List<GameObj> gameObjs) {
            foreach (GameObj gameObj in gameObjs) {
                AddGameObjectForRendering(gameObj);
            }
        }

        public void ClearScene() {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWidth; x++) {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
    }
}