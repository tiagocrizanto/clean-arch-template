using MediatR;

namespace Upstack.Faq.Application.UseCases.NewQuestion
{
    public class NewQuestionInput : IRequest<NewQuestionOutput>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
