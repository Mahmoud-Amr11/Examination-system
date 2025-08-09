using Examination_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system.Repository
{
    public class QuestionRepository
    {
        private readonly Exam _Exam;
        public QuestionRepository(Exam ex)
        {
            _Exam = ex;
        }
        public void Add(Question q)
        {
            _Exam.Questions.Add(q);
        }

        public IEnumerable<Question> GetAll()
        {

            return _Exam.Questions;
        }

        
    }
}
