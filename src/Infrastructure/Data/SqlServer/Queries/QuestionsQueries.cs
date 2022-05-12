namespace Company.Project.Infrastructure.Data.SqlServer.Queries
{
    public static class QuestionsQueries
    {
        public const string GetAllQuestions = @"
            SELECT
                *
            FROM
                Questions";
    }
}
