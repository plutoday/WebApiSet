using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore.Outputs
{
    public class QaRecordOutput : QuestionOutput
    {
        public QaRecordOutput(Question question, List<int> answeredIndices) : base(question)
        {
            AnsweredIndices = new List<int>(answeredIndices);
        }

        public List<int> AnsweredIndices { get; set; }
    }
}
