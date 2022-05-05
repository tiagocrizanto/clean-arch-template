using System.Collections.Generic;
using System.Threading.Tasks;

namespace Upstack.Faq.Domain.Question
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetAll();
        Task AddQuestion(Questions question);
    }
}
