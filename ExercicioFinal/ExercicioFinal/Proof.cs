using System;
using System.Collections.Generic;
using System.Linq;

namespace ExercicioFinal
{
    public class Proof
    {
        public static List<string[]> RegisterQuestions(int totalQuestions)
        {
            string[] questions = new string[totalQuestions];
            string[] answers = new string[totalQuestions];
            string[] subjectAndTeacher = new string[2];
            string label = "Digite A, B, C, OU D para responder: "
;
            if (totalQuestions == 0)
            {
                questions = new string[10] { label, label, label, label, label, label, label, label, label, label };

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

                    string subject = ChooseCourse();

                    subjectAndTeacher[1] = subject;
                }
                for (int i = 0; i <= totalQuestions - 1; i++)
                {
                    Console.WriteLine("Digite a questão:");
                    string question = label + Console.ReadLine();

                    questions[i] = question;

                    Console.WriteLine("Digite a opção correta:");
                    string answer = Console.ReadLine().ToUpper();

                    answers[i] = answer;
                }
            }

            List<string[]> questionsAndAnswers = new List<string[]>() { subjectAndTeacher, questions, answers };

            return questionsAndAnswers;
        }
        public static string[] ApplyTest(string student, string subject, string[] questions, string[] testAnswer)
        {
            int fullMark = 10;

            for (int i = 0; i < testAnswer.Length; i++)
            {
                Console.WriteLine(questions[i]);
                string option = Console.ReadLine().ToUpper();

                if (testAnswer[i] != option)
                {
                    fullMark--;
                }
            }

            Console.WriteLine("\n______________________________________");
            Console.WriteLine("\nNota obtida: " + fullMark);
            Console.WriteLine("______________________________________");

            string[] studentInfo = new string[] { student, subject, fullMark.ToString() };

            return studentInfo;
        }

        public static string ChooseCourse()
        {
            string subject;

            while (true)
            {

                Console.WriteLine("\n______________________________________");
                Console.WriteLine("\nCURSO\nDigite a opção desejada:\n1 - CSHARP \n2 - FLUTTER\n3 - DEVOPS\n4 - JAVA");
                Console.WriteLine("\n______________________________________");
                subject = Console.ReadLine();

                switch (subject)
                {
                    case "1": subject = "CSHARP"; break;
                    case "2": subject = "FLUTTER"; break;
                    case "3": subject = "DEVOPS"; break;
                    case "4": subject = "JAVA"; break;
                    default: Console.WriteLine("\n OPÇÃO INVALIDA!"); continue;
                }
                Console.WriteLine($"\nVocê escolheu {subject}\n");

                break;
            };

            return subject;
        }
        public static int TeacherMenu()
        {
            Console.WriteLine("\n1 - Para cadastrar PROVA");
            Console.WriteLine("2 - Para consultar NOTAS DOS ALUNOS");
            Console.WriteLine("3 - Para consultar MAIOR E MENOR NOTA");
            Console.WriteLine("4 - Para consultar o TOTAL DE ALUNOS QUE REALIZRAM A PROVA");
            Console.WriteLine("5 - Para consultar a MEDIA DA TURMA");
            Console.WriteLine("6 - Para consultar o GABARITO");
            Console.WriteLine("0 - Para voltar ao menu principal");
            int optTeacher = int.Parse(Console.ReadLine());

            return optTeacher;
        }

        public static void CheckBiggerAndSmallerGrade(List<string[]> studentExams)
        {
            int maxValue = 0;
            string[] bestGrade = new string[] { };

            int minValue = 10;
            string[] worstGrade = new string[] { };

            for (int i = 0; i < studentExams.Count; i++)
            {
                if (int.Parse(studentExams[i][2]) > maxValue)
                {
                    maxValue = int.Parse(studentExams[i][2]);
                    bestGrade = studentExams[i];
                }
                if (int.Parse(studentExams[i][2]) < minValue)
                {
                    minValue = int.Parse(studentExams[i][2]);
                    worstGrade = studentExams[i];
                }
            }

            for (int i = 0; i == 0; i++)
            {
                Console.WriteLine("\n______________________________________");
                Console.WriteLine("\nMAIOR nota:___________________________");
                Console.WriteLine("Nome: " + bestGrade[0]);
                Console.WriteLine("Curso: " + bestGrade[1]);
                Console.WriteLine("Nota: " + bestGrade[2]);

                Console.WriteLine("\nMENOR nota:___________________________");
                Console.WriteLine("Nome: " + worstGrade[0]);
                Console.WriteLine("Curso: " + worstGrade[1]);
                Console.WriteLine("Nota: " + worstGrade[2]);
                Console.WriteLine("\n______________________________________");
            }
        }

        public static void CheckClassNotes(List<string[]> studentExams)
        {
            for (int i = 0; i < studentExams.Count; i++)
            {
                Console.WriteLine("\n______________________________________");
                Console.WriteLine("\nNome: " + studentExams[i][0]);
                Console.WriteLine("Curso: " + studentExams[i][1]);
                Console.WriteLine("Nota: " + studentExams[i][2]);
                Console.WriteLine("\n______________________________________");
            }
        }

        public static void CheckClassAverage(List<string[]> studentExams)
        {
            List<int> gradeList = new List<int>();

            for (int i = 0; i < studentExams.Count; i++)
            {
                gradeList.Add(int.Parse(studentExams[i][2]));
            }
            double media = gradeList.Sum() / gradeList.Count;
            Console.WriteLine("A media da turma é : " + media);
        }

        public static void CheckAssessmentInformation(List<string[]> questionsAndAnswers)
        {
            for (int i = 0; i == 0; i++)
            {
                Console.WriteLine("\nINFORMAÇÕES DA PROVA______________________________________ \n");
                Console.WriteLine("Nome do ministrador da prova: " + questionsAndAnswers[0][0]);
                Console.WriteLine("Curso: " + questionsAndAnswers[0][1]);
                Console.WriteLine("\nQUESTÕES DA PROVA: ");
                foreach (var item in questionsAndAnswers[1])
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\nGABARITO: ");
                foreach (var item in questionsAndAnswers[2])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("\n______________________________________");
            }
        }

        public static void CheckStudentGrade(List<string[]> studentExams)
        {
            Console.WriteLine("Nome do aluno:");
            string studentsName = Console.ReadLine().ToUpper();

            string subject = ChooseCourse();

            int j = 0; 
            for (int i = 0; i < studentExams.Count; i++)
            {
                if (studentExams[i][0] == studentsName && studentExams[i][1] == subject)
                {
                    j++;
                    Console.WriteLine("\nINFORMAÇÕES DA SUA AVALIAÇÃO______________\n");
                    Console.WriteLine("Nome: " + studentExams[i][0]);
                    Console.WriteLine("Curso: " + studentExams[i][1]);
                    Console.WriteLine("Nota: " + studentExams[i][2]);
                    Console.WriteLine("\n______________________________________");
                }

            }
            Console.WriteLine(j == 0 ? "\nALUNO NÃO ENCONTRADO!\n" : "") ;
        }
    }
}
