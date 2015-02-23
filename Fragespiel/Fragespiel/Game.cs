using System;
using System.Linq;

namespace Fragespiel
{
    class Game
    {
        private Player[] _players;
        private QuestionPool _questionPool;

        public Game(QuestionPool questionPool)
        {
            _questionPool = questionPool;
        }
        public void Start()
        {
            InitPlayers();
            bool isOver = false;

            while (!isOver)
            {
                foreach (Player player in _players)
                {
                    Console.Clear();
                    Console.WriteLine("{0}, wählen Sie bitte ein Thema", player.Name);

                    foreach (String topic in _questionPool.GetTopics())
                    {
                        Console.WriteLine(topic);
                    }

                    String choice = Console.ReadLine();
                    Console.Clear();

                    QuestionAnswerPair question = _questionPool.GetRandomQuestion(choice);

                    if (question == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Keine Fragen mehr übrig");
                        ShowPoints();
                        isOver = true;
                        break;
                    }

                    Console.WriteLine(question.Question);

                    Console.WriteLine("Richtig oder Falsch");
                    String rightWrong = Console.ReadLine();

                    if (rightWrong == "r" || rightWrong == "richtig")
                    {
                        Console.Clear();
                        Console.WriteLine("Richtig!");
                        player.Points++;
                        ShowPoints();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Falsch, die richtige Antwort wäre: " + question.Answer);
                        ShowPoints();
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowPoints()
        {
            foreach (Player player in _players)
            {
                Console.WriteLine(player.Name + ": " + player.Points);
            }
        }

        public void InitPlayers()
        {
            Console.WriteLine(@"Geben Sie nacheinander alle Spielernamen getrennt von einem Leerzeichen ein, und bestätigen Sie mit ENTER");
            _players = (from player in Console.ReadLine().Split(' ')
                        select new Player(player)).ToArray();
        }
    }
}
