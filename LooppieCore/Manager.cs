using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LooppieCore.Outputs;

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

        public void SubmitQuestion(string userName, SubmitQuestionInput questionInput)
        {
            Guid questionId = Guid.NewGuid();
            List<Answer> inputAnswers = new List<Answer>();
            foreach (var answer in questionInput.AnswerDescriptionList)
            {
                Answer newAnswer = new Answer(answer.Item1, answer.Item2);
                inputAnswers.Add(newAnswer);
            } 
            Question question = new Question(userName, questionInput.QuestionDescription, inputAnswers);
            if (questionInput.Properties.ContainsKey("category")) {
                question.Category = (Category)Enum.Parse(typeof(Category), questionInput.Properties["category"]);
            }
            storage.CreateQuestion(question);
        }

        public void AnswerQuestion(AnswerQuestionInput input)
        {
            QuestionAnswerRecord record = new QuestionAnswerRecord(input.UserName, input.QuestionId, input.ChosenIndices);
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

        public List<Question> GetQuestions(Dictionary<string, string> properties)
        {
            IEnumerable<Question> allQuestions = storage.GetAllQuestions();
            if (properties.ContainsKey("category"))
            {
                allQuestions = allQuestions.Where(q => q.Category.ToString()
                .Contains(properties["category"], StringComparison.InvariantCultureIgnoreCase));
            }
            if (properties.ContainsKey("count"))
            {
                int count;
                int.TryParse(properties["count"], out count);
                allQuestions = allQuestions.Take(count);
            }
            return allQuestions.ToList();
        }

        public QuestionStat GetQuestionStat(Guid questionId)
        {
            return storage.GetQuestionStat(questionId);
        }

        public List<QaRecordOutput> GetQaRecords(string userName, Dictionary<string, string> properties)
        {
            return storage.GetQaRecords(userName).Select(r => GetQaRecordOutput(r)).ToList();
        }

        private QaRecordOutput GetQaRecordOutput(QuestionAnswerRecord record)
        {
            var question = storage.GetQuestion(record.QuestionId);
            var indices = record.AnswerIndicesString.Split('-').Select(s => int.Parse(s)).ToList();
            var output = new QaRecordOutput(question, indices);

            return output;
        }
    }
}

