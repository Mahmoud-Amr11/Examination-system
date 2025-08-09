using Examination_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system.DataBase
{
    public static class SubjectDataBase
    {
       public static List<Subject> subjects { get; set; }= new List<Subject>() {
                    new Subject
                        {
                            SubjectId = 1,
                            SubjectName = "Math",
                            SubjectExam = null
                        },
                    new Subject
                        {
                            SubjectId = 2,
                            SubjectName = "Physics",
                            SubjectExam = null
                        },
                    new Subject
                        {
                            SubjectId = 3,
                            SubjectName = "Computer Science",
                            SubjectExam = null
                        }
       };
    }
}
