using LooppieCore;
using System.Collections.Generic;

namespace Contrat
{
    public class GetQuestionsResponse
    {
        public List<QuestionOutput> Questions { get; set; }

        public GetQuestionsResponse(List<QuestionOutput> questions)
        {
            Questions = new List<QuestionOutput>(questions);
        }
    }
}
