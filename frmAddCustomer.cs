using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestinGList.Models;

namespace TestinGList
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        public Customer c2 { get; set; }
        public Task t2 { get; set; }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            c2 = new Customer();
            
            t2 = new Task();
      
            c2.First = txtFirst.Text;
            c2.Last = txtLast.Text;
            t2.Description = txtTasks.Text;

            c2.Tasks.Add(t2);

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
