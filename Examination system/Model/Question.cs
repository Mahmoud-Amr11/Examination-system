using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system.Model
{
    public abstract class Question
    {
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public double Mark { get; set; }

        public Answer RightAnswer{ get; set; }
        public Answer? StudentAnswer{ get; set; }
        public List<Answer> Answers { get; set; }



        public virtual  void ShowQuestion() {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{QuestionHeader} \t  Mark : {Mark}");
            Console.WriteLine("=======================================");
            Console.WriteLine(QuestionBody);
            Console.WriteLine("=======================================");

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (var answer in Answers)
            {
                Console.WriteLine(answer.ToString());
            }
            Console.ResetColor();

        }


    }

}
