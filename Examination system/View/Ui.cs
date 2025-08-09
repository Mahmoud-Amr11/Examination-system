using Examination_system.Model;
using Examination_system.Repository;

namespace Examination_system.View
{
    public class Ui
    {
        SubjectRepository subjectRepo = new SubjectRepository();

        public void Window()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Subjects ===");
                foreach (var s in subjectRepo.GetAllSubjects())
                {
                    Console.WriteLine($"{s.SubjectId} - {s.SubjectName}");
                }
                Console.WriteLine($"0 - Exit");

                Console.Write("\nEnter Subject ID: ");

                int subId = int.Parse(Console.ReadLine());
                if (subId== 0) { break; }

                var subject = subjectRepo.GetSubjectByID(subId-1);

                if (subject == null)
                {
                    Console.WriteLine("Subject not found!");
                    Console.ReadKey();
                    continue;
                }

                ExamRepository examRepo = new ExamRepository(subject);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"=== {subject.SubjectName} ===");
                    Console.WriteLine("1. Add Exam");
                    Console.WriteLine("2. Show Exam");
                    Console.WriteLine("0. Back");

                    Console.Write("Choose: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        AddExam(examRepo);
                    }
                    else if (choice == "2")
                    {

                        if(subject.SubjectExam is null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no Exam !");
                            Console.ResetColor();
                            Console.WriteLine("press any key to bake to the list ");
                            Console.ReadKey();

                            continue;
                        }

                        DateTime startTime = DateTime.Now;
                        ShowExam(subject.SubjectExam);
                        DateTime endTime = DateTime.Now;
                        TimeSpan duration = endTime - startTime;
                        examRepo.ShowExamResult(subject.SubjectExam,  duration);


                    }
                    else if (choice == "0")
                    {
                        break;
                    }
                }
            }
        }






        private void AddExam(ExamRepository examRepo)
        {
            Console.Clear();
            Console.Write("Enter Exam Type (1 = Final, 2 = Practical): ");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Enter Exam Duration (minutes) From (30 min To 180 min): ");
            int minutes = int.Parse(Console.ReadLine());

            Console.Write("Enter Number of Questions: ");
            int numQuestions = int.Parse(Console.ReadLine());

            Exam exam;
            if (type == 1)
                exam = new FinalExam {
                    TimeOfExam = TimeSpan.
                    FromMinutes(minutes), 
                    NumberOfQuestions = numQuestions 
                };
            else
                exam = new PracticalExam {
                    TimeOfExam = TimeSpan.FromMinutes(minutes),
                    NumberOfQuestions = numQuestions
                };

            examRepo.Add(exam);

            QuestionRepository questionRepo = new QuestionRepository(exam);



            Console.Clear() ;
            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"\n=== Question {i + 1} ===");

                Question q;

                if (exam is FinalExam)
                {
                    Console.Write("Enter Question Type (1 = MCQ, 2 = True/False): ");
                    int qType = int.Parse(Console.ReadLine());

                    Console.Write("Enter Question Body: ");
                    string body = Console.ReadLine();

                    Console.Write("Enter Mark: ");
                    double mark = double.Parse(Console.ReadLine());

                    if (qType == 1)
                        q = CreateMCQ(body, mark);
                    else
                        q = CreateTrueFalse(body, mark);
                }
                else
                {
                    Console.Write("Enter Question Body: ");
                    string body = Console.ReadLine();

                    Console.Write("Enter Mark: ");
                    double mark = double.Parse(Console.ReadLine());

                    q = CreateMCQ(body, mark);
                }

                questionRepo.Add(q);
            }
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("Exam Created Successfully!");
            Console.ResetColor();
            Console.ReadKey();
        }





        private Question CreateMCQ(string body, double mark)
        {
            var mcq = new MCQQuestion
            {
                QuestionHeader = "MCQ",
                QuestionBody = body,
                Mark = mark,
                Answers = new List<Answer>()
            };

            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Answer {i}: ");
                mcq.Answers.Add(new Answer { AnswerId = i, AnswerText = Console.ReadLine() });
            }


            Console.Write("Enter Correct Answer ID: ");

            int correctId = int.Parse(Console.ReadLine());
            mcq.RightAnswer = mcq.Answers[correctId - 1];

            return mcq;
        }








        private Question CreateTrueFalse(string body, double mark)
        {
            var tf = new TrueFalseQuestion
            {
                QuestionHeader = "True/False",
                QuestionBody = body,
                Mark = mark,
                Answers = new List<Answer>
                    {
                        new Answer { AnswerId = 1, AnswerText = "True" },
                        new Answer { AnswerId = 2, AnswerText = "False" }
                    }
            };

            Console.Write("Enter Correct Answer ID (1=True, 2=False): ");
            int correctId = int.Parse(Console.ReadLine());
            tf.RightAnswer = tf.Answers[correctId - 1];

            return tf;
        }





        public void ShowExam(Exam ex)
        {
            Console.Clear();

            Console.WriteLine("==========================Exam=======================");
           
            ex.StudentDegree = 0;
            foreach (var Q in ex.Questions) {
                
                Q.ShowQuestion();
                

                Console.Write("Enter Answer Id :");

                int id=int.Parse(Console.ReadLine());
                Q.StudentAnswer = Q.Answers[id-1];


                if (Q.StudentAnswer.AnswerId == Q.RightAnswer.AnswerId) {
                    ex.StudentDegree += Q.Mark;
                 
                }
            
            }
          


        }
    }




}
