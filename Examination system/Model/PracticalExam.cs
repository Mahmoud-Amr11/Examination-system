namespace Examination_system.Model
{
    public class PracticalExam:Exam
    {
        public override void ShowExamResult(TimeSpan duration)
        {
            Console.Clear();
            Console.WriteLine("==== Practical Exam ====");
            for (int i =1; i <= NumberOfQuestions; i++) {

                Console.WriteLine($"Question {i}: {Questions[i - 1].QuestionBody}");
               
                Console.WriteLine($"Correct Answer : {Questions[i - 1].RightAnswer.AnswerText}");
                Console.ResetColor();
                
            }
            Console.WriteLine($"Time Taken: {duration.Minutes} minutes {duration.Seconds} seconds");
            Console.WriteLine("Thank you");

            Console.ReadKey();
        }
    }
}
