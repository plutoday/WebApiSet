using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class QuestionAnswerRecord
    {
        public Guid ID { get; set; }
        public string Answerer { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerIndicesString { get; set; }
        public DateTime AnswerRecordCreateTime { get; set; }

        public bool Anonymous { get; set; }

        public QuestionAnswerRecord(string answerer, Guid questionId, List<int> answerIndices)
        {
            this.Answerer = answerer;
            this.QuestionId = questionId;
            this.AnswerIndicesString = string.Join('-', answerIndices);
            AnswerRecordCreateTime = DateTime.Now;
        }

        public QuestionAnswerRecord()
        {
            AnswerRecordCreateTime = DateTime.Now;
        }


    }
}
