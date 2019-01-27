using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SchedulerSimulator
{
    class Process
    {
        public int name;

        public static int subprocessMax = 20 ;
        public int subprocess;
        public int arrivalSec ;
        public int waitT;
        public int runTimeT;
        public int turnaround; // Atributo calculado pelo método CalculateTurnaround().
        public Timer timerRuntime = new System.Timers.Timer();
        
        public DateTime startExec; // Atributo inicio da execução para contabilizar o tempo de execução.
        public DateTime finalExec;    // Atributo fim da execução para contabilizar o tempo de execução.
        public TimeSpan runTime = new TimeSpan(); // Atributo gerado pelo método CalculateRuntime().
        public TimeSpan waitingTime = new TimeSpan(); // Atributo calculado por metodo na queue.CalculawaitingTime().
        SubProcess[] listSubprocess = new SubProcess[subprocessMax];
        
        //Simula a execução do processo, método chamado no método ExecuteProcess() na classe queue.  
        //Obtem DateTimeNow para o inicio e fim da execução.

        public void SimulateProcess()
        {
            startExec = DateTime.Now;
            Console.WriteLine("\nProcesso " + this.name + " Executando...");
            Console.WriteLine("\nHora de inicio da execução   --    " + this.startExec);
            Console.WriteLine("Tempo de chegada em segundos :" + this.arrivalSec);
            
            for (int j = 0; j <= subprocess; j++)
            {
                for (int i = 0; i < 100000000; i++)
                {
                    string[] arr = new string[6] { "abc", "def", "ghi", "jkl", "mno", "pqr" };
                }
            }

            this.finalExec = DateTime.Now;
            Console.WriteLine("Processo Terminado   --    " + this.finalExec );
            subprocess = 1;
        } 

        //Adiciona SubProcesso na listsubprocess e acrescenta 1 ao int subprocess.

        public int AddSubprocess()
        {
            Console.Write("\nDigite o número de subprocess : ");
            subprocess = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < subprocess; i++)
            {
                this.listSubprocess[i] = new SubProcess();
            }
        
            return subprocess;
        }


        #region Calculando e retornando tempo.

        //Retorna Tempo de Execução como int de Segundos.
        //Grava a diferença entre incio e fim da execução a TimeSpan runTime.

        public int CalculateRuntime()
        {
            this.runTime = this.finalExec - this.startExec;
            return this.runTime.Seconds;
        }

        public int CalculateTurnaround()
        {
            runTimeT = runTime.Seconds;
            return turnaround = runTimeT + waitT;
        }

        public void ActiveTimer(int valor)
        {
            System.Threading.Thread.Sleep(valor);
            timerRuntime.Enabled = true;
        }
        #endregion

    }
}
