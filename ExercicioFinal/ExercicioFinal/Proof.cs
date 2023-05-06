using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFinal
{
    public class Proof
    {
        public static List<string[]> RegisterQuestions(int totalQuestions)
        {
            string[] questions = new string[totalQuestions];
            string[] answers = new string[totalQuestions];
            string[] subjectAndTeacher = new string[2];

            if (totalQuestions == 0)
            {
                questions = new string[10] {
                    "A, B, C ou D ?", "A, B, C ou D ?", "A, B, C ou D ?",
                    "A, B, C ou D ?", "A, B, C ou D ?", "A, B, C ou D ?",
                    "A, B, C ou D ?", "A, B, C ou D ?", "A, B, C ou D ?", "A, B, C ou D ?"};

                 answers = new string[10] { "A", "B", "C", "D", "E", "E", "D", "C", "B", "A" };
                 subjectAndTeacher = new string[2] { "PROWAY", "CSHARP" };
            }
            else
            {              
                for (int i = 0; i <= 0; i++)
                {
                    Console.WriteLine("Professor ministrador da avaliação:");
                    string teacher = Console.ReadLine();
                    subjectAndTeacher[0] = teacher;

                    Console.WriteLine("\nCURSO\nDigite a opção desejada:\n1 - CSHARP \n2 - FLUTTER\n3 - DEVOPS\n4 - JAVA");
                    string subject = Console.ReadLine();

                    switch (subject)
                    {
                        case "1": subject = "CSHARP"; break;
                        case "2": subject = "FLUTTER"; break;
                        case "3": subject = "DEVOPS"; break;
                        case "4": subject = "JAVA"; break;
                        default: break;

                    }
                    subjectAndTeacher[1] = subject;
                }
                for (int i = 0; i <= totalQuestions - 1; i++)
                {
                    Console.WriteLine("Digite a questão:");
                    string question = "Digite A, B, C, OU D para responder: " + Console.ReadLine();
                    questions[i] = question;

                    Console.WriteLine("Digite a opção correta:");
                    string answer = Console.ReadLine().ToUpper();
                    answers[i] = answer;
                }
            } 

            List<string[]> questionsAndAnswers = new List<string[]>() { subjectAndTeacher, questions, answers };

            return questionsAndAnswers;

        }
        public static string[] ApplyTest(string student,  string subject, string[] questions, string[] testAnswer)
        {            
            int fullMark = 10;

            for (int i = 0; i <= testAnswer.Length - 1; i++)
            {
                Console.WriteLine(questions[i]);
                string option = Console.ReadLine().ToUpper();

                if (testAnswer[i] != option)
                {
                    fullMark--;
                }
            }

            Console.WriteLine("Nota obtida: " + fullMark);

            string[] studentInfo = new string[] { student, subject, fullMark.ToString() };

            return studentInfo;
        }
    }
}
