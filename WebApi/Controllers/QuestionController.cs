using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contrat;
using LooppieCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    public class QuestionController : ControllerBase
    {
        public Manager Manager { get; set; }

        public QuestionController()
        {
            Manager = Manager.GetManagerInstance();
        }
        
        [HttpGet("allquestions")]
        public GetQuestionsResponse GetAllQuestions()
        {
           List<Question> questions= new List<Question>(Manager.GetQuestions());
            return new GetQuestionsResponse(questions.Select(q => new QuestionOutput(q)).ToList());
        }

        [HttpPost("getquestions")]
        public GetQuestionsResponse GetQuestions([FromBody]GetQuestionsRequest request)
        {
            List<Question> questions = Manager.GetQuestions(request.Properties);
            return new GetQuestionsResponse(questions.Select(q => new QuestionOutput(q)).ToList());
        }
        
        [HttpPost("question")]
        public SubmitQuestionResponse SubmitQuestion([FromBody]SubmitQuestionRequest request)
        {
            SubmitQuestionInput questionInput = new SubmitQuestionInput(request.Description, 
                request.Answers.Select(a => new Tuple<string, bool>(a.Answer, a.IsCorrect)).ToList(), request.Properties);
            Manager.SubmitQuestion(request.UserName, questionInput);
            return new SubmitQuestionResponse();
        }
        
        [HttpPost("answer")]
        public AnswerQuestionResponse AnswerQuestion([FromBody]AnswerQuestionRequest request)
        {
            AnswerQuestionInput input = new AnswerQuestionInput(request.QuestionId, request.UserName, request.ChosenIndices);
            Manager.AnswerQuestion(input);
            return new AnswerQuestionResponse();
        } 

        [HttpPost("getqarecords")]
        public GetQaRecordsResponse GetQaRecords([FromBody]GetQaRecordsRequest request)
        {
            var records = Manager.GetQaRecords(request.UserName, request.Properties);
            return new GetQaRecordsResponse(records);
        }
    }
}
