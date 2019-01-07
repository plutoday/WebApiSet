using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    class QuestionList
    {
        public Guid ListId { get; set; }
        public User Creator { get; set; }
        public List<Question> Questions { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
