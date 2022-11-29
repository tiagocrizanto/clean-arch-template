using Company.Project.Api.Transport.Request;
using Company.Project.Application.UseCases.LoadQuestions;
using Company.Project.Application.UseCases.NewQuestion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Company.Project.Api.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("load-questions")]
        [SwaggerOperation("Load all questions")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoadQuestions(CancellationToken cancellationToken)
        {
            var input = new LoadQuestionsInput();
            var output = await _mediator.Send(input, cancellationToken);

            if (output.IsValid)
            {
                return Ok(output);
            }

            return BadRequest();
        }

        [HttpPost("new-question")]
        [SwaggerOperation("Insert new question")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoadQuestions([FromQuery] NewQuestionRequest newQuestion)
        {
            var input = new NewQuestionInput
            {
                Answer = newQuestion.Answer,
                Question = newQuestion.Question
            };
            var output = await _mediator.Send(input).ConfigureAwait(false);

            if (output.IsValid)
            {
                return Ok(output);
            }

            return BadRequest();
        }
    }
}
