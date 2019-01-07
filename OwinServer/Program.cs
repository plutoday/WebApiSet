using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OwinServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            string host = "http://*:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: host))
            {
                try
                {
                    // Create HttpCient and make a request to api/values 
                    HttpClient client = new HttpClient();

                    var response = client.GetAsync(baseAddress + "questions").Result;

                    Console.WriteLine(response);
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }
    }
}
