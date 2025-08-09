using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system.Model
{
    public abstract class Exam
    {

        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public double StudentDegree { get; set; } 
        public List<Question> Questions { get; set; }=new List<Question>();


        public abstract void ShowExamResult(TimeSpan duration);

    }
}
