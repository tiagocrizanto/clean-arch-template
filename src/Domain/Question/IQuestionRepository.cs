using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Project.Domain.Question
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetAll();
        Task AddQuestion(Questions question);
    }
}
