using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contrat;
using LooppieCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class QuestionController : ControllerBase
    {
        public Manager Manager { get; set; }

        public QuestionController()
        {
            Manager = Manager.GetManagerInstance();
        }

        // GET: api/Question
        [HttpGet("questions")]
        public GetQuestionsResponse Get([FromHeader]Guid userId)
        {
           List<Question> questions= new List<Question>(Manager.GetQuestions());
            return new GetQuestionsResponse(questions.Select(q => new QuestionOutput(q)).ToList());
        }

        // POST: api/Question
        [HttpPost("question")]
        public SubmitQuestionResponse Post([FromBody] SubmitQuestionRequest request)
        {
            QuestionInput questionInput = new QuestionInput(request.Description, request.Answers);
            Manager.SubmitQuestion(request.SubmitterId, questionInput);
            return new SubmitQuestionResponse();
        }

        // POST: api/Question
        [HttpPost("answer")]
        public AnswerQuestionResponse Post([FromBody] AnswerQuestionRequest request)
        {
            QuestionAnswerInput input = new QuestionAnswerInput(request.QuestionId, request.RespondentId, request.ChosenIndex);
            Manager.AnswerQuestion(input);
            return new AnswerQuestionResponse();

        }
    }
}
