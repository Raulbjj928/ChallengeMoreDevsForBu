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
                string[] test2 = new string[] { "GIOVANNA", "CSHARP", "8" };
                string[] test3 = new string[] { "JOÃO", "CSHARP", "0" };
                studentExams.Add(test);
                studentExams.Add(test2);
                studentExams.Add(test3);

                Console.WriteLine("\nProway Cursos \nDigite: ");
                Console.WriteLine("1 - Para PROFESSOR");
                Console.WriteLine("2 - Para ALUNO");
                Console.WriteLine("Qualqur outro numero para sair.");
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
                            Console.WriteLine("\nO total de alunos que realizaram a prova: " + studentExams.Count);

                            break; 

                        case 5:
                            Proof.CheckClassAverage(studentExams);
                            
                            break; 

                        case 6:
                            List<string[]> proof = new List<string[]>();

                            if (proofs.Count == 0) proof = questionsAndAnswers; else proof = proofs.Last();

                            Proof.CheckAssessmentInformation(proof);
                            
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

                        List<string[]> proof = new List<string[]>();

                        if (proofs.Count == 0) proof = questionsAndAnswers; else proof = proofs.Last();

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
                    break;
                }

            }
            Console.ReadKey();
        }
    }
}
