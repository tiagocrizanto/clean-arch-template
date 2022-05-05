namespace Upstack.Faq.Infrastructure.Data.SqlServer.Queries
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
