using LooppieCore.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contrat
{
    public class GetQaRecordsResponse
    {
        public List<QaRecordOutput> Records { get; set; }

        public GetQaRecordsResponse(List<QaRecordOutput> records)
        {
            Records = new List<QaRecordOutput>(records);
        }
    }
}
