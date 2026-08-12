using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Models
{
    public class Process
    {
        public int Id { get; set; }

        public int ArrivalTime { get; set; }

        public int BurstTime { get; set; }

        public int Priority { get; set; }

        public int WaitingTime { get; set; }

        public int TurnaroundTime { get; set; }

        public int CompletionTime { get; set; }

        public int RemainingTime { get; set; }
    }
}
