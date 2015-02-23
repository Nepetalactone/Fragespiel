using System;
using System.Xml.Serialization;

namespace Fragespiel
{
    public class QuestionAnswerPair
    {
        public String Question { get; set; }
        public String Answer { get; set; }
        public String Topic { get; set; }

        [XmlIgnore]
        public bool isTaken { get; set; }
        public QuestionAnswerPair()
        {

        }

        public QuestionAnswerPair(String question, String answer, String topic)
        {
            Question = question;
            Answer = answer;
            Topic = topic;
            isTaken = false;
        }
    }
}
