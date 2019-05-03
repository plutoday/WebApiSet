using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class AnswerOutput
    {
        public AnswerOutput(string description, bool isCorrect = false)
        {
            Description = description;
            IsCorrect = isCorrect;
        }

        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}
