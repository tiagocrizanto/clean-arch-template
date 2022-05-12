namespace Company.Project.Infrastructure.Data.SqlServer.Command
{
    public static class QuestionCommand
    {
        public const string InserNewQuestion = @"
            INSERT INTO
                Questions(Question,Answer)
            VALUES
                (@question, @answer)";
    }
}
