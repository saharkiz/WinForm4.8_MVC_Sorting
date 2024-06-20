using System.Diagnostics;
using WinForm_Model;

namespace WinForm_Controller
{
    public interface ISortingImplementation
    {
        string SortString(string input, CorrelationIdentifier correlation);
    }
    public class SortingFactory
    {
        public static ISortingImplementation GetSortingAlgorithm(SortMethod sortType, CorrelationIdentifier correlation)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry($"entered GetSortingAlgorithm {correlation.CorrelationId}", EventLogEntryType.Information);

                try
                {
                    ISortingImplementation sortingAlgorithm = null;
                    switch (sortType)
                    {
                        case SortMethod.BubblSort: sortingAlgorithm = new BubbleSort(); break;
                        case SortMethod.QuickSort: sortingAlgorithm = new QuickSort(); break;
                        case SortMethod.MergeSort: sortingAlgorithm = new MergeSort(); break;
                    }
                    return sortingAlgorithm;
                }
                catch (System.Exception ex)
                {
                    eventLog.WriteEntry($"{ex.ToString()} {correlation.CorrelationId}", EventLogEntryType.Error);
                    throw;
                }
                finally
                {
                    eventLog.WriteEntry($"Complete GetSortingAlgorithm {correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
        }
    }
}
