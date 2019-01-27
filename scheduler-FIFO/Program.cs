using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberProcesses = 0;
            int choice = 1;
            Console.Write("\nDigite o número de processos a serem executados : ");
            numberProcesses =  Int32.Parse(Console.ReadLine());

            Queue queue = new Queue();
            queue.nProcess = numberProcesses;

            queue.AddProcess();
            do
            {
                Console.Write("\nDeseja adicionar subprocess ? 0 para não 1 para sim : ");
                choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    //.listrProcessos();

                    Console.Write("\nDigite o número do processo : ");

                    int choiceProcess = Int32.Parse(Console.ReadLine());

                    for (int i = 0; i < numberProcesses; i++)
                    {
                        if ((choiceProcess ) == queue.processList[i].name)
                        {
                            queue.processList[i].AddSubprocess();
                        }
                    }


                }

            } while (choice != 0);
            
            queue.QueueStartTime();
            queue.ExecuteProcess(queue.processList);
            
            Console.ReadKey();
        }
    }
}
