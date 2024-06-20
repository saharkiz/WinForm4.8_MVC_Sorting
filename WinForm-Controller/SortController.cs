using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_Model;

namespace WinForm_Controller
{
    public class SortController
    {
        private readonly IStringSorterView _stringSorterView;
        public SortController(IStringSorterView stringSorterView)
        {
            _stringSorterView = stringSorterView;
            this._stringSorterView.SortEvent += btnSort_Click;
            this._stringSorterView.LoadFormSortEvent += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var correlation = new CorrelationIdentifier();
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry($"Form Loaded {correlation.CorrelationId}", EventLogEntryType.Information);

                    _stringSorterView.SortingMethodList = Enum.GetValues(typeof(SortMethod)).Cast<SortMethod>().ToArray();
                    _stringSorterView.SortingMethod = SortMethod.BubblSort;

                    eventLog.WriteEntry($"Form Loaded Complete{correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                _stringSorterView.ProcessedData = ex.ToString();
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                var correlation = new CorrelationIdentifier();
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry($"Sort Clicked {correlation.CorrelationId}", EventLogEntryType.Information);

                    HandleSort(correlation);

                    eventLog.WriteEntry($"Sort Click Complete{correlation.CorrelationId}", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                _stringSorterView.ProcessedData = ex.ToString();
            }
            
        }
        public void HandleSort(CorrelationIdentifier correlation)
        {
            if (_stringSorterView.InputData.Length < 1)
            {
                _stringSorterView.ProcessedData = "Input empty";
                return;
            }
            //get sort algo
            ISortingImplementation sortAlgo = SortingFactory.GetSortingAlgorithm(_stringSorterView.SortingMethod, correlation);

            //perform sort
            _stringSorterView.ProcessedData = sortAlgo.SortString(_stringSorterView.InputData, correlation);
        }

    }
}
