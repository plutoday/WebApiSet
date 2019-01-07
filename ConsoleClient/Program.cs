using LooppieCore;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.GetUId();
            c.SubmitQuestion();
            c.ShowQuestion();
            c.AnswerQuestion();
            Console.ReadLine();

        }


    }
}
