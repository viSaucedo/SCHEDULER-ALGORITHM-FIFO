using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SchedulerSimulator
{
    class Queue
    {
        static int count = 0;
        static int maxSize = 10 ;
        public int nProcess;
        public int totalQueueTime;
        public int timer;
        static Random arrivalTime = null;
        public DateTime queueStartTime;

        public Process[] processList = new Process[maxSize];

        public void QueueStartTime( ) { 
        
                this.queueStartTime = DateTime.Now;
               
        }

        public void AddProcess()
        {
            if (processList.Count() <= maxSize)
            {
                var x = GenerateArrivalTime();

                for (int i = 0; i < nProcess; i++)
                {
                    this.processList[i] = new Process();
                    this.processList[i].name = i + 1;
                    this.processList[i].arrivalSec = x[i]; 
                    
                    count++;
                }
                this.OrderQueue();

                Console.WriteLine("\nqueue de processos por tempo de chegada");

                for (int i = 0; i < nProcess; i++)
                {
                    Console.Write("\nProcesso " + this.processList[i].name );
                }

                Console.Write("\n");

            }
            else
            {
                Console.WriteLine("Não é possível adicionar mais processos. queue Cheia.");
            }
        }

        //Gera valor random ao tmpChegada
        //Adiciona ao int arrivalSec o valor em segudos para ser inciado na queue.

        public List<int> GenerateArrivalTime()
        {
            List<int> list = new List<int>();

            while (list.Count < nProcess)
            {
                arrivalTime = new Random();
                int number = arrivalTime.Next(0,15);
                if (list.Contains(number) == false)
                {
                    list.Add(number);

                }
            }
            
            return list;
        }

        public void ExecuteProcess(Process[] processLists)
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("Tempo de Inicio da queue : " + queueStartTime);

            foreach (var processo in processList)
            {
                if (processo != null)
                {
                    ProcessArrivalTimer(i);

                    processo.ActiveTimer(timer);

                    if (processo.timerRuntime.Enabled == true)
                    {
                        processo.SimulateProcess();
                        Console.WriteLine("Tempo de execução : " + processo.CalculateRuntime() + "\n");
                        CalculateWaitingTime();

                        Console.WriteLine("Tempo de espera : " + processo.waitT + "\n");
                        //processo.timerRuntime.Enabled = false;

                        Console.WriteLine("Turnaround : " + processo.CalculateTurnaround() + "\n");

                        i++;
                    }
                    
                }
               
            }
        }

        public void OrderQueue()
        {
            Process orderedProcess = new Process();

            for (int i = 0; i < nProcess ; i++)
            {
                for (int j = 0; j < nProcess - 1 ; j++) 
                {
                    if (processList[i].arrivalSec < processList[j].arrivalSec)
                    {
                        orderedProcess = processList[i];
                        processList[i] = processList[j];
                        processList[j] = orderedProcess;

                    }
                }
            }
            
        }

        public void CalculateWaitingTime()
        {
            for (int i = 0; i < nProcess ; i++)
            {
                if (i == 0)
                {
                    //processList[i].waitingTime = null;
                    processList[i].waitT = processList[i].waitingTime.Seconds;
                    totalQueueTime = processList[0].runTime.Seconds;
                }
                else
                {
                    totalQueueTime += processList[i].runTime.Seconds;
                    
                        processList[i].waitT = totalQueueTime - processList[i].runTime.Seconds - processList[i].arrivalSec;
                        
                    if (processList[i].waitT < 0)
                    {
                        processList[i].waitT = 0;
                    }
                }

            }
        }

        public void ProcessArrivalTimer(int i)
        {
            i = i - 1;
            if(i < nProcess - 1)
            {
                if (i == 0)
                {
                    timer = processList[i].arrivalSec;
                }
                else if (i == nProcess - 1)
                {
                    if (processList[i].arrivalSec > processList[i-1].arrivalSec)
                    {
                        timer = processList[i].arrivalSec - totalQueueTime;
                    }

                    timer = 0;
                }
                else
                {
                    if (processList[i].arrivalSec > processList[i - 1].arrivalSec)
                    {
                        timer = processList[i].arrivalSec - totalQueueTime;
                    }

                    timer = 0;
                }

            }
               
        }
        
    }
}
