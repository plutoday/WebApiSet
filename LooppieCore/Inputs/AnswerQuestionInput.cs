using System;
using System.Collections.Generic;

namespace LooppieCore
{
    public class AnswerQuestionInput
    {
        public Guid QuestionId { get; set; }

        public string UserName { get; set; }

        public List<int> ChosenIndices { get; set; }

        public AnswerQuestionInput(Guid questionId, string userName, List<int> chosenIndices)
        {
            QuestionId = questionId;
            UserName = userName;
            ChosenIndices = chosenIndices;
        }
    }
}
