namespace MoonBuggy {
    class Records {
        public void recall() {
            // StreamReader _Read = new StreamReader("base.txt");
            string path1 = Directory.GetCurrentDirectory();
            string path2 = "/Base.txt";
            string[] readText = File.ReadAllLines(path1 + path2);

            int[] newarr = new int[1000];
            for (int i = 0; i < readText.Length; i++ )
            {
                string text = readText[i].ToString();
                newarr[i] = int.Parse(text);

            }
            Array.Sort(newarr);
            Array.Reverse(newarr);
            Console.WriteLine("id   Score");
            for (int i = 0; i < 20; i++ )
            {
                if (newarr[i] != 0) {
                    Console.WriteLine($"{i + 1} --> {newarr[i]}");
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");

        }

        public void recnew(int score) {
            StreamWriter _Write = new StreamWriter("base.txt", true);
            _Write.WriteLine(score);
            _Write.Close();
        }
    }
}