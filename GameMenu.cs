namespace MoonBuggy
{
    public class GameMenu
    {
        private int _SelectedIndex;
        private string[] _Options = {"Играть", "инфа", "Завершить"};
        private string _Prompt;
        private GameSettings _gameSettings;
        
        public GameMenu(){
            _Prompt = @"
███    ███  ██████   ██████  ███    ██   ██████  ██    ██  ██████   ██████ ██    ██
████  ████ ██    ██ ██    ██ ████   ██   ██   ██ ██    ██ ██       ██       ██  ██
██ ████ ██ ██    ██ ██    ██ ██ ██  ██   ██████  ██    ██ ██   ███ ██   ███  ████
██  ██  ██ ██    ██ ██    ██ ██  ██ ██   ██   ██ ██    ██ ██    ██ ██    ██   ██
██      ██  ██████   ██████  ██   ████   ██████   ██████   ██████   ██████    ██ ";
            _SelectedIndex = 0;
        }

        public void DisplayOptions(){
            Console.WriteLine(_Prompt);
            const int width = 35;
            const int height = 15;
            for (int i = 0; i < _Options.Length; i++){
            Console.SetCursorPosition(width, height + i);
                string currentOption = _Options[i];
                string prefix;
                if (i == _SelectedIndex){
                    prefix = "*"; 
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                } else{
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Console.SetCursorPosition(_gameSettings.ConsoleWidth/2,_gameSettings.ConsoleHeight/2 + i);
                Console.Write($"{prefix} {currentOption}");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public int RunMenu(){
            ConsoleKey keyPressed;
            do {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow){
                    _SelectedIndex--;
                    if (_SelectedIndex == -1){ 
                        _SelectedIndex = _Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow){
                    _SelectedIndex++;
                    if (_SelectedIndex == _Options.Length){ 
                        _SelectedIndex = 0;
                    }
                }
            } while(keyPressed != ConsoleKey.Enter);
            Console.Clear();
            return _SelectedIndex;
        }
    }
}