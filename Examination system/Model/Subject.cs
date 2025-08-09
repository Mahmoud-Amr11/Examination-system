namespace Examination_system.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public void CreateExam(Exam? exam)
        {
            if (exam is FinalExam F)
            {
                SubjectExam = new FinalExam
                {
                    TimeOfExam = F.TimeOfExam,
                    NumberOfQuestions = F.NumberOfQuestions,
                    Questions = F.Questions,
                };
            }
            else if (exam is PracticalExam P)
            {
                SubjectExam = new PracticalExam
                {
                    TimeOfExam = P.TimeOfExam,
                    NumberOfQuestions = P.NumberOfQuestions,
                    Questions= P.Questions,
                };
            }
        }
    }
}
