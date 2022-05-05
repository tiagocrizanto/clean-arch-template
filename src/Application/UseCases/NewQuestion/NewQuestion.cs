using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Upstack.Faq.Domain;
using Upstack.Faq.Domain.Question;

namespace Upstack.Faq.Application.UseCases.NewQuestion
{
    public class NewQuestion : IRequestHandler<NewQuestionInput, NewQuestionOutput>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<NewQuestion> _logger;

        public NewQuestion(IQuestionRepository questionRepository,
            ILogger<NewQuestion> logger)
        {
            _questionRepository = questionRepository;
            _logger = logger;
        }

        public async Task<NewQuestionOutput> Handle(NewQuestionInput request, CancellationToken cancellationToken)
        {
            var output = new NewQuestionOutput();

            try
            {
                _logger.LogInformation("Starting NewQuestion");

                var question = new Questions
                {
                    Answer = request.Answer,
                    Question = request.Question
                };

                await _questionRepository.AddQuestion(question);

                output.IsValid = true;

                _logger.LogInformation("NewQuestion ended with success");
            }
            catch (System.Exception ex)
            {
                output.IsValid = false;
                _logger.LogError(ex, "Error on NewQuestion");
            }

            return output;
        }
    }
}
