using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ExercicioFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<string[]>> proofs = new List<List<string[]>>(); 
            List<string[]> questionsAndAnswers = Proof.RegisterQuestions(0); 
            List<string[]> studentExams = new List<string[]>();
            while (true)
            {

                //MOCKTEST
                string[] test = new string[] { "RAUL", "CSHARP", "10" };
                string[] test2 = new string[] { "TASSIA", "CSHARP", "10" };
                string[] test3 = new string[] { "JOÃO", "CSHARP", "0" };
                studentExams.Add(test);
                studentExams.Add(test2);
                studentExams.Add(test3);

                Console.WriteLine("\nProway Cursos \nDigite: ");
                Console.WriteLine("(1) Professor");
                Console.WriteLine("(2) Aluno");
                int opt = int.Parse(Console.ReadLine()); 

                if (opt == 1)
                {
                    int optTeacher = Proof.TeacherMenu();

                    switch (optTeacher)
                    {
                        case 1:
                            questionsAndAnswers.Clear();
                            Console.WriteLine("Digite o numero de questões que deseja cadastrar:");
                            int qtt = int.Parse(Console.ReadLine());
                            proofs.Add(Proof.RegisterQuestions(qtt));

                            break;

                        case 2:
                            Proof.CheckClassNotes(studentExams);

                            break;

                        case 3:
                            Proof.CheckBiggerAndSmallerGrade(studentExams);
                            
                            break; 

                        case 4:
                            Console.WriteLine("\nO total de alunos que utilizão o sistema é: " + studentExams.Count);

                            break; 

                        case 5:
                            Proof.CheckClassAverage(studentExams);
                            
                            break; 

                        case 6:
                            Proof.CheckAssessmentInformation(questionsAndAnswers);
                            
                            break; 
                        case 0:
                            break; 
                    };
                }
                else if (opt == 2)
                {
                    Console.WriteLine("\n1 - Para realizar PROVA");
                    Console.WriteLine("2 - Para consultar sua NOTA");
                    Console.WriteLine("Qualqur outro numero para voltar ao menu principal");
                    int optStudent = int.Parse(Console.ReadLine());

                    if (optStudent == 1)
                    {
                        Console.WriteLine("Nome do aluno:");
                        string studentsName = Console.ReadLine().ToUpper();

                        string subject = Proof.ChooseCourse();

                        var proof = proofs.Last();

                        string[] studentTest = Proof.ApplyTest(studentsName, subject, proof[1], proof[2]);

                        studentExams.Add(studentTest);
                    }
                    else if(optStudent == 2)
                    {
                        Proof.CheckStudentGrade(studentExams);                        
                    }
                }
                else
                {
                    Console.WriteLine("Opção invalida!");
                }

            }
            Console.ReadKey();
        }
    }
}
