using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class QuestionAnswerInput
    {
        public Guid QuestionId { get; set; }

        public Guid RespondentId { get; set; }

        public int ChosenIndex { get; set; }

        public QuestionAnswerInput(Guid questionId, Guid respondentId, int chosenIndex)
        {
            QuestionId = questionId;
            RespondentId = respondentId;
            ChosenIndex = chosenIndex;
        }
    }
}
