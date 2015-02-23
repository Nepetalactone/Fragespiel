using System;
using System.IO;

namespace Fragespiel
{
    class Program
    {
        private static QuestionPool _questionPool;
        private static Game _game;
        static void Main(string[] args)
        {
            bool isQuit = false;
            _questionPool = new QuestionPool();
            do
            {
                Console.WriteLine("Wenn Sie eine neue Frage eingeben wollen, drücken Sie 'f' und bestätigen Sie.");
                Console.WriteLine("Wenn Sie ein neues Spiel starten wollen, drücken Sie 's' und bestätigen Sie.");
                Console.WriteLine("Wenn Sie das Program beenden wollen, drücken sie 'q' und bestätigen Sie");
                switch (Console.ReadLine().ToLower())
                {
                    case "f":
                        Console.Clear();
                        AddNewQuestion();
                        break;
                    case "s":
                        Console.Clear();
                        _game = new Game(_questionPool);
                        _game.Start();
                        break;
                    case "q":
                        isQuit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Eingabe nicht verstanden");
                        break;
                }
            } while (!isQuit);
        }

        private static void AddNewQuestion()
        {
            Console.Clear();
            Console.WriteLine("Geben Sie eine neue Frage ein");
            String question = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Geben Sie die dazugehörende Antwort ein");
            String answer = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Geben Sie das Themengebiet ein");
            String topic = Console.ReadLine();
            Console.Clear();

            QuestionAnswerPair q = new QuestionAnswerPair(question, answer, topic);
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(q.GetType());
            TextWriter writer = new StreamWriter(topic + Guid.NewGuid() + ".xml");
            x.Serialize(writer, q);

            _questionPool.Add(question, answer, topic);
        }
    }
}
