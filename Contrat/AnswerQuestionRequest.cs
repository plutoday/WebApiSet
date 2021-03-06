﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contrat
{
    public class AnswerQuestionRequest
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public Guid QuestionId { get; set; }
        public List<int> ChosenIndices { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
