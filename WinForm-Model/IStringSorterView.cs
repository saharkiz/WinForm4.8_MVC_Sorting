using System;
using WinForm_Model;

namespace WinForm_Model
{
    public interface IStringSorterView
    {
        event EventHandler SortEvent; 
        event EventHandler LoadFormSortEvent;


        string InputData { get; set; }
        SortMethod SortingMethod { get; set; }
        SortMethod[] SortingMethodList { get; set; }
        string ProcessedData { get; set; }
    }
    
}
