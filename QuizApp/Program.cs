namespace QuizApp
{
    
    class Question
    {
        public int id { get; set; }
        public string pytanie { get; set; }
        public int poprawna { get; set; }
        public string Odpowiedz1 { get; set; }
        public string Odpowiedz2 { get; set; }
        public string Odpowiedz3 { get; set; }
        public string Odpowiedz4 { get; set; }
        public Question(int id,string pytanie, int poprawna, string Odpowiedz1, string Odpowiedz2, string Odpowiedz3, string Odpowiedz4)
        {
            this.id = id;
            this.pytanie = pytanie;
            this.poprawna = poprawna;
            this.Odpowiedz1 = Odpowiedz1;
            this.Odpowiedz2 = Odpowiedz2;
            this.Odpowiedz3 = Odpowiedz3;
            this.Odpowiedz4 = Odpowiedz4;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            int maxPytan = 5;

            bool repeat = true;
            int highestscore = 0;
            while (repeat)
            {


                Console.Clear();
                Console.WriteLine($"Witaj w Quizzie Informatycznym! Obecny najwyższy wynik: {highestscore}/{maxPytan}");
                Console.WriteLine("Wybierz daną opcje i wciśnij enter");
                Console.WriteLine("1. Rozpocznij quiz");
                Console.WriteLine("2. Wyjdz");
                Console.WriteLine("Twój wybór:");
                 int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        List<Question> questions = new List<Question>();

                        StreamReader file = new StreamReader("C:\\Users\\danypolska\\source\\repos\\QuizApp\\QuizApp\\pytania.txt");
                        file.ReadLine(); 
                        while (!file.EndOfStream)
                        {
                            string[] words = file.ReadLine().Split(';');
                            
                                Question newquestion = new Question(Convert.ToInt16(words[0]), words[1], Convert.ToInt16(words[2]), words[3], words[4], words[5], words[6]);
                                questions.Add(newquestion);
                            

                        }
                        file.Close();
                        int i = 0;
                        int punkty = 0;

                        while (i < maxPytan)
                        {
                            Console.Clear();
 Random randomQuestion = new Random();
                        int q = randomQuestion.Next(questions.Count);
                        Question question = questions[q];
                        int odp = question.poprawna;
                        Console.WriteLine(question.pytanie+":");
                        Console.WriteLine("1. " + question.Odpowiedz1);
                        Console.WriteLine("2. " + question.Odpowiedz2);
                        Console.WriteLine("3. " + question.Odpowiedz3);
                        Console.WriteLine("4. " + question.Odpowiedz4);

                        Console.WriteLine("");
                        Console.WriteLine("Twoja odpowiedź:");
                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        if(choice2 == odp)
                        {
                            Console.WriteLine("Dobra Odpowiedz!");
                                punkty++;
                                i++;
                                Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Zła odpowiedź");
                                i++;
                                Console.ReadKey();
                        }

                        }
                       if(highestscore < punkty)
                        {
                            highestscore = punkty;
                        }
                        
                        break;
                    case 2:
                        repeat = false;

                        break;

                }
            }
        }
     
      
    }
}