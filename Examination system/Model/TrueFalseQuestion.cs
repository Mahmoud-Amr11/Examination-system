namespace Examination_system.Model
{
    public class TrueFalseQuestion : Question
    {
        public override void ShowQuestion()
        {
            QuestionHeader = "True or False Question";
            base.ShowQuestion();
        }
    }

}
