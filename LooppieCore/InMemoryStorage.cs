using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LooppieCore
{
    public class InMemoryStorage : IStorage
    {
        public Dictionary<Guid, User> Users { get; set; }
        public List<Question> NewQuestions { get; set; }
        public List<QuestionAnswerRecord> AnswerRecords { get; set; }
        public List<Question> ExistingQuestions { get; set; }

        public InMemoryStorage()
        {
            Guid id = new Guid("2f725194-0902-4aab-b724-e5eeeddb58db");
            Users = new Dictionary<Guid, User>();
            Users.Add(id, new User(id));
            NewQuestions = new List<Question>();
            AnswerRecords = new List<QuestionAnswerRecord>();
            ExistingQuestions = new List<Question>();
            ExistingQuestions.Add(new Question(id, "how are you?", new List<Answer>()
            {
                new Answer("good"), new Answer("not good")
            }));
            ExistingQuestions.Add(new Question(id, "what is your name?", new List<Answer>()
            {
                new Answer("dog"), new Answer("pig")
            }));
        }

        public void CreateAnswerRecord(QuestionAnswerRecord record)
        {
            AnswerRecords.Add(record);
        }

        public void CreateQuestion(Question question)
        {
            NewQuestions.Add(question);
        }

        public void CreateUser(User user)
        {
            Users.Add(user.UserId, user);
        }

        public List<Question> GetAllQuestions()
        {
            return NewQuestions;
        }

        public User GetUserById(Guid id)
        {
            return Users[id];
        }

        public QuestionStat GetQuestionStat(Guid questionId)
        {
            var question = NewQuestions.First(q => q.QuestionId == questionId);
            var records = AnswerRecords.Where(r => r.QuestionId == questionId).ToList();
            QuestionStat questionStat = new QuestionStat(question, records);
            return questionStat;
        }
    }
}
