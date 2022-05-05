using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Upstack.Faq.Domain.Question;

namespace Upstack.Faq.Application.UseCases.LoadQuestions
{
    public class LoadQuestions : IRequestHandler<LoadQuestionsInput, LoadQuestionsOutput>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<LoadQuestions> _logger;

        public LoadQuestions(IQuestionRepository questionRepository,
            ILogger<LoadQuestions> logger)
        {
            _questionRepository = questionRepository;
            _logger = logger;
        }

        public async Task<LoadQuestionsOutput> Handle(LoadQuestionsInput request, CancellationToken cancellationToken)
        {
            var output = new LoadQuestionsOutput();

            try
            {
                _logger.LogInformation("Starting LoadQuestions");

                output.Questions = (await _questionRepository.GetAll()).Select(x => new QuestionsOutput
                {
                    Answer = x.Answer,
                    Id = x.Id,
                    Question = x.Question
                }).ToList();

                output.IsValid = true;

                _logger.LogInformation("LoadQuestions ended with success");
            }
            catch (System.Exception ex)
            {
                output.IsValid = false;
                _logger.LogError(ex, "Error on LoadQuestions");
            }

            return output;
        }
    }
}
