using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore.Domain
{
   public class Answer
    {
        public Guid AnswerId { get; set; }
        public string Description { get; set; }
        //public List<Tag> Tags { get; set; }
        public int HitCount { get; set; }
        public string Explanation { get; set; }
        public bool IsCorrect { get; set; }
    }
}
