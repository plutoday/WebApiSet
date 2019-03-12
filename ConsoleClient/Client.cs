using LooppieCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClient
{
    public class Client
    {
        public Manager Manager { get; set; }

        public Client()
        {
            Manager = Manager.GetManagerInstance();
        }

        public void GetUId()
        {
            Console.WriteLine(Manager.CreateUser()); 
        }

        public void SubmitQuestion()
        {
            Console.WriteLine("Please input your id");
            Guid id = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Please input your question");
            string description = Console.ReadLine();
            QuestionInput question = new QuestionInput(description);
            Console.WriteLine("Please input your answer, one answer per input, q to end");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer.Equals("q"))
                {
                    break;
                }

                question.AnswerDescriptionList.Add(answer);
            }
            
            if (question.AnswerDescriptionList.Count == 0)
            {
                throw new InvalidOperationException("No answer provided");
            }

            Manager.SubmitQuestion(id, question);
        }

        public void ShowQuestion(int index)
        {
            var questions = Manager.GetQuestions();
            Console.WriteLine(questions[index].ToString());
        }


        public void AnswerQuestion(int index)
        {
            var questions = Manager.GetQuestions();
            Question q = questions[index];
            Console.WriteLine(q.ToString());
            Console.WriteLine("Please input your id");
            Guid uId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Please input your answer number");
              int  answer = int.Parse(Console.ReadLine());

            if (answer == int.MaxValue)
            {
                throw new InvalidOperationException("No answer provided");
            }
            QuestionAnswerInput questionAnswerInput = new QuestionAnswerInput(q.QuestionId, uId, answer);
            Manager.AnswerQuestion(questionAnswerInput);
            Console.WriteLine(Manager.GetQuestionStat(q.QuestionId).ToString());


        }

    }
}
