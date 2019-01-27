using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerSimulator
{
    class SubProcess
    {
        public DateTime inicio;
        public DateTime fim;

        public void SimularSubProcesso()
        {
            this.inicio = DateTime.Now;

            this.fim = DateTime.Now;
        }
        
    }
}
