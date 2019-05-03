using System;
using System.Collections.Generic;

namespace Contrat
{
    public class SubmitQuestionRequest
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public string Description { get; set; }
        public List<AnswerReq> Answers { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }   
    
    public class AnswerReq
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
