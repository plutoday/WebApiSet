using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class Question : IComparable<Question>
    {
        public Guid QuestionId { get; set; }
        public Guid SubmitterId { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
       // public List<int> Tags { get; set; }
        public List<Answer> Answers { get; set; }
        public int HotRank { get; set; }
        public DateTime QuestionCreateTime { get; set; }



        public Question(Guid submitterId, string description, List<Answer> answers)
        {
            SubmitterId = submitterId;
            Description = description;
            Answers = new List<Answer>(answers);
            QuestionId = Guid.NewGuid();
            //Tags = new List<int>();
            //Tags.Add(new Tag(TagEnum.People));
            QuestionCreateTime = DateTime.Now;
        }

        public Question()
        {
 
            Answers = new List<Answer>();
            QuestionCreateTime = DateTime.Now;

        }

        public override string ToString()
        {
            StringBuilder question = new StringBuilder(Description);
            for (int i = 0; i < Answers.Count; i++)
            {
                question.Append($"{i}.{Answers[i].Description}");
            }
            return question.ToString();
        }

        public int CompareTo(Question other)
        {
            return this.HotRank - other.HotRank;
        }
    }


}
