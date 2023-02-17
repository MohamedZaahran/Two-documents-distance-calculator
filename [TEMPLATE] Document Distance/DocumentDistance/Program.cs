using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DocumentDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // YOU WILL FIND A FOLDER IN THE PROJECT'S FILES TO ADD THE TWO DOCUMENTS IN AND USE THE FOLLOWING PATH:
                // Documents (Add documents here)\FILENAME.txt

                Console.Write("Please enter the two paths of the files you wish to calculate the distance between them:\n1) ");
                string path1 = (string)Console.ReadLine();
                Console.Write("2) ");
                string path2 = (string)Console.ReadLine();
                do
                {
                    try
                    {
                        string content1 = File.ReadAllText(path1);
                        string content2 = File.ReadAllText(path2);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("Enter correct files paths, do you want to re-enter files paths (y/n)? ");
                        char choicee = (char)Console.ReadLine()[0];
                        if (choicee == 'n' || choicee == 'N')
                            goto exit;
                        else if (choicee == 'y' || choicee == 'Y')
                        {
                            Console.Write("\nPlease enter the two paths of the files you wish to calculate the distance between them:\n1) ");
                            path1 = (string)Console.ReadLine();
                            Console.Write("2) ");
                            path2 = (string)Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Choice!");
                            goto exit;
                        }
                    }
                } while (true);
            
                Stopwatch sw = Stopwatch.StartNew();
                double Result = DocDistance.CalculateDistance(path1, path2);
                sw.Stop();
                if (Result == 1000) goto exit;
                Console.WriteLine("\nAngle = " + Math.Round(Result, 2));
                Console.WriteLine("Execution time (ms) = " + Math.Round((double)sw.ElapsedMilliseconds, 2));
                   
                Console.Write("\nDo you want to run again (y/n)? ");
                char choice = (char)Console.ReadLine()[0];
                if (choice == 'n' || choice == 'N')
                    break;
                else if (choice == 'y' || choice == 'Y')
                    continue;
                else
                {
                    Console.WriteLine("\nInvalid Choice!");
                    break;
                }
            } while (true);
        exit:
            Console.WriteLine("");
        }
    }
}
