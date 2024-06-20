using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using WinForm_Controller;
using WinForm_Model;

namespace WinForm_Ats
{
    public partial class Form1 : Form, IStringSorterView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler LoadFormSortEvent;
        public event EventHandler SortEvent;


        private void btnSort_Click(object sender, EventArgs e)
        {
            this.SortEvent?.Invoke(this, EventArgs.Empty);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadFormSortEvent?.Invoke(this, EventArgs.Empty);
        }

        public string InputData
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public string ProcessedData
        {
            get { return lblOutput.Text; }
            set { lblOutput.Text = value; }
        }

        public SortMethod SortingMethod
        {
            get {
                return (SortMethod)Enum.Parse(typeof(SortMethod), lstSortMethods.Text?.ToString() ?? "0");
            }
            set { lstSortMethods.Text = value.ToString(); }
        }
        public SortMethod[] SortingMethodList
        {
            get
            {
                return Enum.GetValues(typeof(SortMethod)).Cast<SortMethod>().ToArray();
            }
            set
            {
                lstSortMethods.Items.AddRange(value.Cast<object>().ToArray());
            }
        }

    }
}
