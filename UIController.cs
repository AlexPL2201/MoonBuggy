namespace MoonBuggy {
    class UIConroller {
        public event EventHandler OnSpacePressed;
        public void StartListning() {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key.Equals(ConsoleKey.Spacebar)) {
                OnSpacePressed?.Invoke(this, new EventArgs());
            }
        }
    }
}