using System.Collections.Generic;

namespace Upstack.Faq.Application.UseCases.LoadQuestions
{
    public class LoadQuestionsOutput
    {
        public bool IsValid { get; set; }
        public List<QuestionsOutput> Questions { get; set; }
    }

    public class QuestionsOutput
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
