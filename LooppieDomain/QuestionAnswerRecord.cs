using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore.Domain
{
   public class QuestionAnswerRecord
    {
        public Guid ID { get; set; }
        public Guid AnswererId { get; set; }
        public Guid QuestionId { get; set; }
        public int Answer { get; set; }
    }
}
