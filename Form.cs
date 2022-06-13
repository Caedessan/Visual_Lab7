using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_7
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool _editingNewRow;

        public Form()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            videostudentBindingSource.Clear();
            var dataList = Program.Getstudents();
            foreach (var dataEntry in dataList) 
            {
                videostudentBindingSource.Add(dataEntry);
            }
            dataGridView1.DataSource = videostudentBindingSource;
            UpdateList();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DiscipleBindingSource.Clear();
            var dataList = Program.GetDisciples();
            foreach (var dataEntry in dataList)
            {
                DiscipleBindingSource.Add(dataEntry);
            }
            dataGridView1.DataSource = DiscipleBindingSource;
            UpdateList();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            LectorBindingSource.Clear();
            var dataList = Program.GetAgencies();
            foreach (var dataEntry in dataList)
            {
                LectorBindingSource.Add(dataEntry);
            }
            dataGridView1.DataSource = LectorBindingSource;
            UpdateList();
        }

        private void UpdateList() 
        {
            dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.None).ReadOnly = true;
        }

        private void EditDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveChanges();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _editingNewRow = true;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var deletedRow = e.Row;
            Program.Delete(deletedRow.DataBoundItem);
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_editingNewRow) 
            {
                var addedRow = dataGridView1.Rows[e.RowIndex];
                if (dataGridView1.DataSource == videostudentBindingSource)
                {
                    var dataEntry = (Student)addedRow.DataBoundItem;
                    Program.Addstudent(dataEntry);
                }
                else if (dataGridView1.DataSource == DiscipleBindingSource)
                {
                    var dataEntry = (Disciple)addedRow.DataBoundItem;
                    Program.AddDisciple(dataEntry);
                }
                else
                {
                    var dataEntry = (Lector)addedRow.DataBoundItem;
                    Program.AddLector(dataEntry);
                }
            }
            _editingNewRow = false;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            Program.SaveChanges();
        }
    }
}
