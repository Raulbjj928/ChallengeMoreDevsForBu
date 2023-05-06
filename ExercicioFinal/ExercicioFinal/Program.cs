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
            while (true)
            {
                List<List<string[]>> Proofs = new List<List<string[]>>(); 
                List<string[]> questionsAndAnswers = Proof.RegisterQuestions(0); 
                List<string[]> studentExams = new List<string[]>();

                //MOCKTEST
                string[] test = new string[] { "RAUL", "PROWAY", "10" };
                string[] test2 = new string[] { "TASSIA", "PROWAY", "10" };
                string[] test3 = new string[] { "JOÃO", "PROWAY", "0" };
                studentExams.Add(test);
                studentExams.Add(test2);
                studentExams.Add(test3);

                Console.WriteLine("\nProway Cursos \nDigite: ");
                Console.WriteLine("(1) Professor");
                Console.WriteLine("(2) Aluno");
                int opt = int.Parse(Console.ReadLine()); 

                if (opt == 1)
                {
                    Console.WriteLine("\n1 - Para cadastrar questoes e respostas");
                    Console.WriteLine("2 - Para consultar notas de alunos");
                    Console.WriteLine("3 - Para consultar maior e menor acerto");
                    Console.WriteLine("4 - Para consultar o total de alunos que utilizaram o sistema;,");
                    Console.WriteLine("5 - Para consultar a média de notas da turma");
                    Console.WriteLine("6 - Para consultar o gabarito");
                    Console.WriteLine("0 - Para voltar ao menu principal");    
                    int optTeacher = int.Parse(Console.ReadLine());

                    switch (optTeacher)
                    {
                        case 1:
                            questionsAndAnswers.Clear();
                            Console.WriteLine("Digite o numero de questões que deseja cadastrar:");
                            int qtt = int.Parse(Console.ReadLine());
                            Proofs.Add(Proof.RegisterQuestions(qtt));
                            break;

                        case 2:
                            for (int i = 0; i < studentExams.Count; i++)
                            {
                                Console.WriteLine("\nNome: " + studentExams[i][0]);
                                Console.WriteLine("Curso: " + studentExams[i][1]);
                                Console.WriteLine("Nota: " + studentExams[i][2]);
                            }
                            break;

                        case 3:
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

                            for (int i = 0; i <= 0; i++)
                            {
                                Console.WriteLine("\nMelhor nota:");
                                Console.WriteLine("Nome: " + bestGrade[0]);
                                Console.WriteLine("Curso: " + bestGrade[1]);
                                Console.WriteLine("Nota: " + bestGrade[2]);

                                Console.WriteLine("\nPior nota:");
                                Console.WriteLine("Nome: " + worstGrade[0]);
                                Console.WriteLine("Curso: " + worstGrade[1]);
                                Console.WriteLine("Nota: " + worstGrade[2]);
                            }
                            break; 

                        case 4:
                            Console.WriteLine("\nO total de alunos que utilizão o sistema é: " + studentExams.Count);
                            break; 

                        case 5:
                            List<int> gradeList = new List<int>();

                            for (int i = 0; i < studentExams.Count; i++)
                            {
                                gradeList.Add(int.Parse(studentExams[i][2]));
                            }
                            double media = gradeList.Sum() / gradeList.Count;
                            Console.WriteLine("A media da turma é : " +  media);
                            break; 

                        case 6:
                            for (int i = 0; i <= 0; i++)
                            {
                                Console.WriteLine("______________________________________\nINFORMAÇÕES DA PROVA : ");
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
                                    Console.Write(item + " - ");
                                }
                                Console.WriteLine("\n______________________________________");
                            }
                            break; 
                        case 0:
                            break; 
                    };
                }
                else if (opt == 2)
                {
                    Console.WriteLine("\n1 - Para realizar prova");
                    Console.WriteLine("2 - Para consultar sua nota");
                    Console.WriteLine("0 - Para voltar ao menu principal");
                    int optStudent = int.Parse(Console.ReadLine());

                    if (optStudent == 1)
                    {
                        Console.WriteLine("Nome do aluno:");
                        string studentsName = Console.ReadLine().ToUpper();

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

                        string[] studentTest = Proof.ApplyTest(studentsName, subject, questionsAndAnswers[1], questionsAndAnswers[2]);

                        studentExams.Add(studentTest);
                    }
                    else if(optStudent == 2)
                    {
                        Console.WriteLine("Nome do aluno:");
                        string studentsName = Console.ReadLine().ToUpper();

                        Console.WriteLine("Nome do Curso:");
                        string subject = Console.ReadLine().ToUpper();

                        for (int i = 0; i < studentExams.Count; i++)
                        {
                            if (studentExams[i][0] == studentsName && studentExams[i][1] == subject)
                            {
                                Console.WriteLine("Nome: " + studentExams[i][0]);
                                Console.WriteLine("Curso: " + studentExams[i][1]);
                                Console.WriteLine("Nota: " + studentExams[i][2]);
                            }
                            
                        }
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
