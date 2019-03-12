using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class QuestionAnswerRecord
    {
        public Guid ID { get; set; }
        public Guid AnswererId { get; set; }
        public Guid QuestionId { get; set; }
        public int Answer { get; set; }
        public DateTime AnswerRecordCreateTime { get; set; }

        public bool Anonymous { get; set; }

        public QuestionAnswerRecord(Guid answererId, Guid questionId, int answer)
        {
            this.AnswererId = answererId;
            this.QuestionId = questionId;
            this.Answer = answer;
            AnswerRecordCreateTime = DateTime.Now;
        }

        public QuestionAnswerRecord()
        {
            AnswerRecordCreateTime = DateTime.Now;
        }


    }
}
