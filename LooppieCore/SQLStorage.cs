using LooppieCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LooppieCore
{
    public class SQLStorage : IStorage
    {
        private LooppieContext _dbContext = new LooppieContext();
       


        public void CreateAnswerRecord(QuestionAnswerRecord record)
        {
            Domain.QuestionAnswerRecord domainQaRecord = record.ToDomainQaRecord();
            _dbContext.QuestionAnswerRecord.Add(domainQaRecord);
            _dbContext.SaveChanges();
        }

        public void CreateQuestion(Question question)
        {
            _dbContext.Question.Add(question.ToDomainQuestion());
            _dbContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            _dbContext.User.Add(user.ToDomainUser());
            _dbContext.SaveChanges();
        }

        public List<Question> GetAllQuestions()
        {
            try
            {
                var list = new List<Question>();
                foreach (var q in _dbContext.Question.Include(q => q.Answers).ToList())
                {
                    list.Add(q.ToQuestion());
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public QuestionStat GetQuestionStat(Guid questionId)
        {
            Question question = _dbContext.Question.First(q => q.QuestionId == questionId).ToQuestion();
            List<QuestionAnswerRecord> records = _dbContext.QuestionAnswerRecord.Where(r => r.QuestionId == questionId).Select(r =>r.ToQaRecord()).ToList();
            QuestionStat questionStat = new QuestionStat(question, records);
            return questionStat;
        }

        public User GetUserById(Guid id)
        {
            return _dbContext.User.Find(id).ToUser();
        }

    }
}
