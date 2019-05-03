using System;
using System.Collections.Generic;
using System.Text;

namespace Contrat
{
    public class GetQaRecordsRequest
    {
        public string UserName { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
