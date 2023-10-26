using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestinGList.DataLayer;
using TestinGList.Models;

namespace TestinGList
{
    public partial class frmDisplay : Form
    {
        public frmDisplay()
        {
            InitializeComponent();
        }

   
        private TaskDB context = new TaskDB();
        private Models.Task t1;
        private Customer c1;
       

        private const int delIndex = 5;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newFrm = new frmAddCustomer();
            DialogResult result = newFrm.ShowDialog();

            if(result == DialogResult.OK)
            {
                try
                {
                    c1 = newFrm.c2;
                    t1 = newFrm.t2;

                    context.Tasks.Add(t1);
                    context.Customers.Add(c1);        // Same this here with people coming from Customers - needed to add to both 
                    context.SaveChanges();
                    ShowList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Missing Customer entity or establishing a value for" +
                        $" \ncustomer class so context/db can save data","ERROR!");    
                }
            }
           // t1 = newFrm.t2;
            

            //context.TaskItems.Add(t1);  // notice taskItems here again from DB Context
            

        }

        private void ShowList()
        {
            dgvCustomers.Columns.Clear();

            //DB variables instances "People" of customer and TaskItems of Task.
            var query = context.Customers
                .Join(
                context.Tasks,
                p => p.PersonId,
                t => t.PersonId,
                (p, t) => new { p.PersonId, p.First, p.Last, t.TaskId, t.Description }
                ).ToList();

            //.Select(p => new { p.PersonId, p.First, p.Last })
            //.ToList();

            dgvCustomers.DataSource = query;
            

            dgvCustomers.Columns[0].Visible = false;

            var deleteButton = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "Delete Person",
                Text = "Delete",
                Name = "colDel"
            };

            dgvCustomers.Columns.Insert(delIndex, deleteButton);

        }

        private void DeletePerson()
        {
            DialogResult result = MessageBox.Show($"Delete {c1.First} {c1.Last}?", "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                context.Customers.Remove(c1);
                context.SaveChanges();
                ShowList();
            }


        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int personId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

                c1 = context.Customers.Find(personId);

                if (e.ColumnIndex == delIndex)
                {
                    DeletePerson();

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDisplay_Load(object sender, EventArgs e)
        {
            ShowList();
        }
    }
}
