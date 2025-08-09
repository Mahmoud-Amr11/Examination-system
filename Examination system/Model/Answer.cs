namespace Examination_system.Model
{
    public class Answer
    {
        public int AnswerId{ get; set; }
        public string AnswerText{ get; set; }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }

}
