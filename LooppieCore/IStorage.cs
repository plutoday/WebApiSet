using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public interface IStorage
    {
        void CreateUser(User user);
        User GetUserById(Guid id);
        void CreateQuestion(Question question);
        void CreateAnswerRecord(QuestionAnswerRecord record);
        List<Question> GetAllQuestions();
        QuestionStat GetQuestionStat(Guid questionId);
    
    }
}
