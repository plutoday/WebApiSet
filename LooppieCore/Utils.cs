using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LooppieCore
{
    public static class Utils
    {
        public static Domain.Question ToDomainQuestion(this Question question)
        {
           Domain.Question domainQuestion = new Domain.Question() {
               QuestionId = question.QuestionId,
               Submitter = question.UserName,
               Description = question.Description,
               Category = question.Category.ToString(),
               SubCategory = question.SubCategory.ToString(),
               Answers = question.Answers.Select(a => ToDomainAnswer(a)).ToList(),
               HotRank = question.HotRank,
               QuestionCreateTime = question.QuestionCreateTime

           };

            return domainQuestion;
        }

        public static Domain.Answer ToDomainAnswer(this Answer answer)
        {
            Domain.Answer domainAnswer = new Domain.Answer() {
                AnswerId = answer.AnswerId,
                Description = answer.Description,
                HitCount = answer.HitCount,
                Explanation = answer.Explanation,
                IsCorrect = answer.IsCorrect
            };
            return domainAnswer;
        }

        public static Domain.User ToDomainUser(this User user)
        {
            Domain.User domainUser = new Domain.User() {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ActiveUser = user.ActiveUser,
                UserCreateTime = user.UserCreateTime
    };

            return domainUser;
        }

        public static Domain.QuestionAnswerRecord ToDomainQaRecord(this QuestionAnswerRecord record)
        {
            Domain.QuestionAnswerRecord domainQaRecord = new Domain.QuestionAnswerRecord() {
                ID = record.ID,
                Answerer = record.Answerer,
                QuestionId = record.QuestionId,
                Answer = int.Parse(record.AnswerIndicesString.Substring(0, 1)),
                AnswerRecordCreateTime = record.AnswerRecordCreateTime,
                Anonymous = record.Anonymous
            };
            return domainQaRecord;
        }

        public static Question ToQuestion(this Domain.Question domainQuestion)
        {
            Question question = new Question()
            {
                QuestionId = domainQuestion.QuestionId,
                UserName = domainQuestion.Submitter,
                Description = domainQuestion.Description,
                Category = (Category)Enum.Parse(typeof(Category), domainQuestion.Category),
                SubCategory = (SubCategory)Enum.Parse(typeof(SubCategory), domainQuestion.SubCategory),
                Answers = domainQuestion.Answers.Select(a => ToAnswer(a)).ToList(),
                HotRank = domainQuestion.HotRank,
                QuestionCreateTime = domainQuestion.QuestionCreateTime

            };

            return question;
        }

        public static Answer ToAnswer(this Domain.Answer domainAnswer)
        {
            Answer answer = new Answer()
            {
                AnswerId = domainAnswer.AnswerId,
                Description = domainAnswer.Description,
                HitCount = domainAnswer.HitCount,
                Explanation = domainAnswer.Explanation,
                IsCorrect = domainAnswer.IsCorrect
            };
            return answer;
        }

        public static User ToUser(this Domain.User domainUser)
        {
            User user = new User()
            {
                UserId = domainUser.UserId,
                UserName = domainUser.UserName,
                Email = domainUser.Email,
                FirstName = domainUser.FirstName,
                LastName = domainUser.LastName,
                ActiveUser = domainUser.ActiveUser,
                UserCreateTime = domainUser.UserCreateTime
            };

            return user;
        }

        public static QuestionAnswerRecord ToQaRecord(this Domain.QuestionAnswerRecord domainQaRecord)
        {
            QuestionAnswerRecord qaRecord = new QuestionAnswerRecord()
            {
                ID = domainQaRecord.ID,
                Answerer = domainQaRecord.Answerer,
                QuestionId = domainQaRecord.QuestionId,
                AnswerIndicesString = domainQaRecord.Answer.ToString(),
                AnswerRecordCreateTime = domainQaRecord.AnswerRecordCreateTime,
                Anonymous = domainQaRecord.Anonymous
            };
            return qaRecord;
        }
    }
}
