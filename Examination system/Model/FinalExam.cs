namespace Examination_system.Model
{
    public class FinalExam:Exam
    {
        public override void ShowExamResult(TimeSpan duration)
        {

            Console.Clear();
            Console.WriteLine("==== Final Exam ====");
            for (int i = 1; i <= NumberOfQuestions; i++)
            {

                Console.WriteLine($"Question {i}: {Questions[i - 1].QuestionBody}");
                if (Questions[i - 1].RightAnswer == Questions[i - 1].StudentAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                Console.WriteLine($"Correct Answer : {Questions[i - 1].RightAnswer.AnswerText}\nYour Answer : {Questions[i - 1].StudentAnswer.AnswerText}");
                Console.ResetColor();
                Console.WriteLine("==================================================");

            }

            Console.WriteLine($"Time Taken: {duration.Minutes} minutes {duration.Seconds} seconds");
            Console.ResetColor();
            Console.WriteLine("===============================");
            Console.WriteLine($"Your Degree = {StudentDegree}");
            Console.WriteLine("===============================");
            Console.WriteLine("Thank you");

            Console.ReadKey();


        }
    }
}
