namespace Examination_system.Model
{
    public class MCQQuestion : Question
    {
        public override void ShowQuestion()
        {
            QuestionHeader = "MCQ Question";
            base.ShowQuestion();
        }
    }

}
