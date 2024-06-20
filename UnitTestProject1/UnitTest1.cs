using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WinForm_Controller;
using WinForm_Model;

namespace UnitTestProject1
{
    public class StringSorterView : IStringSorterView
    {
        public string InputData { get; set; }
        public SortMethod SortingMethod { get; set; }
        public SortMethod[] SortingMethodList { get; set; }
        public string ProcessedData { get; set; }

        public event EventHandler SortEvent;
        public event EventHandler LoadFormSortEvent;
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_BubbleSort()
        {
            var correlation = new CorrelationIdentifier();
            var currentString = "zbxayc";
            var expectedString = "abcxyz";

            var form = new StringSorterView();
            form.InputData = currentString;
            form.SortingMethod = WinForm_Model.SortMethod.BubblSort;

            var controller = new SortController(form);

            controller.HandleSort(correlation);

            Assert.AreEqual(expectedString, form.ProcessedData);
            ;
        }
        [TestMethod]
        public void TestMethod_QuickSort()
        {
            var correlation = new CorrelationIdentifier();
            var currentString = "befdac";
            var expectedString = "abcdef";

            var form = new StringSorterView();
            form.InputData = currentString;
            form.SortingMethod = WinForm_Model.SortMethod.QuickSort;

            var controller = new SortController(form);

            controller.HandleSort(correlation);

            Assert.AreEqual(expectedString, form.ProcessedData);
            ;
        }
    }
}
