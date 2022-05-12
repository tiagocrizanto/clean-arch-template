using MediatR;

namespace Company.Project.Application.UseCases.NewQuestion
{
    public class NewQuestionInput : IRequest<NewQuestionOutput>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
