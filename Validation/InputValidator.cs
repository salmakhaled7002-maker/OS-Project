using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Validation
{
    public static class InputValidator
    {
        public static bool IsValidProcessData(
            string arrivalTimeText,
            string burstTimeText,
            string priorityText,
            out int arrivalTime,
            out int burstTime,
            out int priority)
        {
            arrivalTime = 0;
            burstTime = 0;
            priority = 0;

            if (!int.TryParse(arrivalTimeText, out arrivalTime))
                return false;

            if (!int.TryParse(burstTimeText, out burstTime))
                return false;

            if (!int.TryParse(priorityText, out priority))
                return false;

            if (arrivalTime < 0)
                return false;

            if (burstTime <= 0)
                return false;

            if (priority < 0)
                return false;

            return true;
        }
    }
}