using System;
using System.Collections.Generic;

namespace Contrat
{
    public class SubmitQuestionRequest
    {
        public Guid SubmitterId { get; set; }
        public string Description { get; set; }
        public List<string> Answers { get; set; }

    }
}
