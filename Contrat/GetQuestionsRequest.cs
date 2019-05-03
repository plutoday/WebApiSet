using System;
using System.Collections.Generic;
using System.Text;

namespace Contrat
{
    public class GetQuestionsRequest
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
