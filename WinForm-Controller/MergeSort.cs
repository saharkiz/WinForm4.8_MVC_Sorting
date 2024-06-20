using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Model;

namespace WinForm_Controller
{
    public class MergeSort : ISortingImplementation
    {
        public string SortString(string input, CorrelationIdentifier correlation)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry($"MergeSort Loaded {correlation.CorrelationId}", EventLogEntryType.Information);

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
                    eventLog.WriteEntry($"MergeSort Complete{correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
        }
        private string Sort(string input)
        {
            var result = "";

            int size = (input.Length % 2 == 0) ? input.Length / 2 : (input.Length + 1) / 2;

            if (input.Length > 1)
            {
                char[] left = input.Substring(0, input.Length / 2).ToCharArray();
                char[] right = input.Substring(input.Length / 2, input.Length - (input.Length / 2)).ToCharArray();

                // recursively sort the two halves
                Sort(left.Length.ToString());
                Sort(right.Length.ToString());

                // merge the sorted left and right subLists together
                result = merge(input, left, right);
            }

            return result;
        }

        public string merge(string result, char[] left, char[] right)
        {
            int i1 = 0; // index for left
            int i2 = 0; // index for right

            var theString = result;
            var aStringBuilder = new StringBuilder(theString);

            for (int i = 0; i < aStringBuilder.Length; i++)
            {
                if (i2 >= right.Length || (i1 < left.Length && left.GetValue(i1).ToString().CompareTo(right.GetValue(i2).ToString()) < 0))
                {
                    aStringBuilder.Remove(i, 1);
                    aStringBuilder.Insert(i, left.GetValue(i1).ToString());
                    i1++;
                }
                else
                {
                    aStringBuilder.Remove(i, 1);
                    aStringBuilder.Insert(i, right.GetValue(i2).ToString());
                    i2++;
                }
            }

            theString = aStringBuilder.ToString();
            return theString;

        }
    }
}
