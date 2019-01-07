using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class QuestionStat
    {
        public Question Question { get; set; }
        public List<QuestionAnswerRecord> Records { get; set; }

        public QuestionStat(Question question, List<QuestionAnswerRecord> records)
        {
            Question = question;
            Records = records;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Question.Description);
            builder.Append(" ");
            builder.Append("/n");
            int [] array = new int [Question.Answers.Count];
            foreach (QuestionAnswerRecord record in Records)
            {
               array [record.Answer]++;
            }
            foreach (var item in array)
            {
                builder.Append(item.ToString());
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
}
