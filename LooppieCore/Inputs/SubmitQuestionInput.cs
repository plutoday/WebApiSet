using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class SubmitQuestionInput
    {
        public string QuestionDescription { get; set; }
        public List<Tuple<string, bool>> AnswerDescriptionList { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public SubmitQuestionInput(string description)
            : this(description, new List<Tuple<string, bool>>())
        {
        }

        public SubmitQuestionInput(string description, List<Tuple<string, bool>> answers)
            : this(description, answers, new Dictionary<string, string>())
        {
        }

        public SubmitQuestionInput(string description, List<Tuple<string, bool>> answers, Dictionary<string, string> properties)
        {
            QuestionDescription = description;
            AnswerDescriptionList = new List<Tuple<string, bool>>(answers);
            if (properties == null)
            {
                Properties = new Dictionary<string, string>();
            }
            else
            {
                Properties = new Dictionary<string, string>(properties);
            }
        }

    }
}
