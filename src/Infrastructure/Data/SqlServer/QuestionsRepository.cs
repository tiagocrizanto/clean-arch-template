using Company.Project.Domain;
using Company.Project.Domain.Question;
using Company.Project.Infrastructure.Data.Configuration;
using Company.Project.Infrastructure.Data.SqlServer.Command;
using Company.Project.Infrastructure.Data.SqlServer.Queries;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Company.Project.Infrastructure.Data.SqlServer
{
    public class QuestionsRepository : IQuestionRepository
    {
        private readonly SqlConnection _connection;
        public QuestionsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.SqlServerDatabaseName) as SqlConnection;
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
