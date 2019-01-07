using System;
using System.Collections.Generic;
using System.Text;

namespace Contrat
{
    public class AnswerQuestionRequest
    {
        public Guid RespondentId { get; set; }
        public Guid QuestionId { get; set; }
        public int ChosenIndex { get; set; }
    }
}
