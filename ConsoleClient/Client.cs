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
            Console.WriteLine("Please input your userName");
            string userName = Console.ReadLine();
            Console.WriteLine("Please input your question");
            string description = Console.ReadLine();
            SubmitQuestionInput question = new SubmitQuestionInput(description);
            Console.WriteLine("Please input your answer, one answer per input, q to end");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer.Equals("q"))
                {
                    break;
                }

                if (answer.EndsWith('+'))
                {
                    question.AnswerDescriptionList.Add(new Tuple<string, bool>(answer.Substring(0, answer.Length - 1), true));
                }
                else
                {
                    question.AnswerDescriptionList.Add(new Tuple<string, bool>(answer, false));
                }
            }
            
            if (question.AnswerDescriptionList.Count == 0)
            {
                throw new InvalidOperationException("No answer provided");
            }

            Manager.SubmitQuestion(userName, question);
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
            AnswerQuestionInput questionAnswerInput = new AnswerQuestionInput(q.QuestionId, uId.ToString(), new List<int>(answer));
            Manager.AnswerQuestion(questionAnswerInput);
            Console.WriteLine(Manager.GetQuestionStat(q.QuestionId).ToString());
        }

    }
}
