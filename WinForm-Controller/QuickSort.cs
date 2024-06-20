using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Model;

namespace WinForm_Controller
{
    public class QuickSort : ISortingImplementation
    {

        public string SortString(string input, CorrelationIdentifier correlation)
        {

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry($"QuickSort Loaded {correlation.CorrelationId}", EventLogEntryType.Information);

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
                    eventLog.WriteEntry($"QuickSort Complete{correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
        }
        public string Sort(string input)
        {
            char[] charactersToSort = input.ToCharArray();
            int low = 0;
            int high = charactersToSort.Length - 1;
            Quick_Sort(charactersToSort, low, high);
            return new string(charactersToSort);
        }
        private static void Quick_Sort(char[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        // Method to partition the array
        private static int Partition(char[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    char temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }
    }
}
