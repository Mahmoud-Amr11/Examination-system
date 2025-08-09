using Examination_system.Model;

namespace Examination_system.Repository
{
    public class ExamRepository
    {
        private readonly Subject _Subject;


        public ExamRepository(Subject subject)
        {
            _Subject = subject;
        }

        public void Add(Exam exam)
        {
            _Subject.CreateExam(exam);
        }
        public void ShowExamResult(Exam exam, TimeSpan duration)
        {
            exam.ShowExamResult(duration);

        }



    }
}
