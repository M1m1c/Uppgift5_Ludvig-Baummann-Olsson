using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class UI
    {
        private List<string> messageLog = new List<string>();
        public String ReadLine()
        {
            return Console.ReadLine();
        }

        public void Print(string input)
        {
            Console.WriteLine(input);
        }

        public void Clear()
        {
            Console.Clear();
        }
        public void AddToMessageLog(string message)
        {
            messageLog.Add(message);
        }

        public void PrintMessageLog()
        {
            foreach (var item in messageLog)
            {
                Print("->"+item);
            }
        }
        public void ClearMessageLog()
        {
            messageLog.Clear();
            messageLog.TrimExcess();
        }
      
    }
}
