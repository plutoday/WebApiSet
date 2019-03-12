﻿using System;
using System.Collections.Generic;

namespace LooppieCore.Domain
{
    public class Question 
    {
            public Guid QuestionId { get; set; }
            public Guid SubmitterId { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
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

        }

    }
    }
