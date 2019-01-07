using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LooppieCore
{
    public class Manager
    {
        IStorage storage = new SQLStorage();
        private Manager()
        {
            
        }

        private static readonly Manager _manager = new Manager();

        public static Manager GetManagerInstance()
        {
            return _manager;
        }

        public void SubmitQuestion(Guid userId, QuestionInput questionInput)
        {
            Guid questionId = Guid.NewGuid();
            List<Answer> inputAnswers = new List<Answer>();
            foreach (string answer in questionInput.AnswerDescriptionList)
            {
                Answer newAnswer = new Answer(answer);
                inputAnswers.Add(newAnswer);
            } 
            Question question = new Question(userId, questionInput.QuestionDescription, inputAnswers);
            storage.CreateQuestion(question);
        }

        public void AnswerQuestion(QuestionAnswerInput input)
        {
            QuestionAnswerRecord record = new QuestionAnswerRecord(input.RespondentId, input.QuestionId, input.ChosenIndex);
            storage.CreateAnswerRecord(record);
        }

        public Guid CreateUser()
        {
            User user = new User();
            storage.CreateUser(user);
            return user.UserId;
        }

        public List<Question> GetQuestions()
        {
            return storage.GetAllQuestions();
        }

        public QuestionStat GetQuestionStat(Guid questionId)
        {
            return storage.GetQuestionStat(questionId);
        }
    }
}

