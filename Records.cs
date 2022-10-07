namespace MoonBuggy {
    class Records {
        public void recall() {
            // StreamReader _Read = new StreamReader("base.txt");
            string path = @"/Users/sasha/Desktop/Конспекты/Технологии разработки современных программных комплексов/MoonBuggy/Base.txt";
            string[] readText = File.ReadAllLines(path);

            int[] newarr = new int[1000];
            for (int i = 0; i < readText.Length; i++ )
            {
                int n = 0;
                string text = readText[i].ToString();
                for (int j = 0; j < text.Length; j++){
                    n += (int)(text[j] - '0');
                    if (j != text.Length -1){
                    n *= 10;
                    }
                }
                newarr[i] = n;

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