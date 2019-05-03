using LooppieCore;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            Client c = new Client();
            //c.GetUId();
            c.SubmitQuestion();
            Console.WriteLine("Please input the index of the question you want answer");
            index = int.Parse(Console.ReadLine());
            c.ShowQuestion(index);
            c.AnswerQuestion(index);
            Console.ReadLine();

        }


    }
}
