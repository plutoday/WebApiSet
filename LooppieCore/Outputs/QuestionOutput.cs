using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LooppieCore
{
    public class QuestionOutput
    {
        public string QuestionDescription { get; set; }
        public Guid QuestionId { get; set; }
        public List<AnswerOutput> AnswerList { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<int> Tags { get; set; }

        public QuestionOutput(Question question)
        {
            QuestionId = question.QuestionId;
            QuestionDescription = question.Description;
            AnswerList = question.Answers.Select(a => new AnswerOutput(a.Description, a.IsCorrect)).ToList();
            Category = question.Category;
            SubCategory = question.SubCategory;
            Tags = new List<int>();
        }

    }
}
