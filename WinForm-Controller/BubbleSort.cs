using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Model;

namespace WinForm_Controller
{
    public class BubbleSort : ISortingImplementation
    {
        public string SortString(string input, CorrelationIdentifier correlation)
        {

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry($"BubbleSort Loaded {correlation.CorrelationId}", EventLogEntryType.Information);

                try
                {
                    return Sort(input);
                }
                catch (Exception ex)
                {
                    eventLog.WriteEntry($"{ex.ToString()} {correlation.CorrelationId}", EventLogEntryType.Error);
                    return "Error";
                }
                finally
                {
                    eventLog.WriteEntry($"BubbleSort Complete{correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
        }
        private string Sort(string input)
        {
            var result = "";
            var arr = input.ToCharArray();
            char temp;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
                result += arr[i];

            return result;
        }
    }
}
