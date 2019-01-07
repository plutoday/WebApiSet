using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class QuestionInput
    {
        public string QuestionDescription { get; set; }
        public List<string> AnswerDescriptionList { get; set; }

        public QuestionInput(string description)
        {
            QuestionDescription = description;
            AnswerDescriptionList = new List<string>();
        }

        public QuestionInput(string description, List<string> answers)
        {
            QuestionDescription = description;
            AnswerDescriptionList = new List<string>(answers);
        }

    }
}
