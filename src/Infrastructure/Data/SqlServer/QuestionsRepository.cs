using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Upstack.Faq.Domain;
using Upstack.Faq.Domain.Question;
using Upstack.Faq.Infrastructure.Data.Configuration;
using Upstack.Faq.Infrastructure.Data.SqlServer.Command;
using Upstack.Faq.Infrastructure.Data.SqlServer.Queries;

namespace Upstack.Faq.Infrastructure.Data.SqlServer
{
    public class QuestionsRepository : IQuestionRepository
    {
        private readonly SqlConnection _connection;
        public QuestionsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.SqlServerUpstackFaq) as SqlConnection;
        }

        public async Task AddQuestion(Questions question)
        {
            var param = new DynamicParameters();
            param.Add("question", question.Question);
            param.Add("answer", question.Answer);

            await _connection.ExecuteAsync(QuestionCommand.InserNewQuestion, param);
        }

        public async Task<IEnumerable<Questions>> GetAll()
        {
            return await _connection.QueryAsync<Questions>(QuestionsQueries.GetAllQuestions);
        }
    }
}
