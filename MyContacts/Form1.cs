using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.DataSource = repository.SelectAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAddOrEditcs frm = new frmAddOrEditcs();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string family = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string FullName = name + " " + family;
                if (MessageBox.Show($"آیا از حذف {FullName} مطمعن هستید ؟ ", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactID);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخض را از لیست انتخاب کنید");

            }






        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int contactID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEditcs frm = new frmAddOrEditcs();
                frm.contactID = contactID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }





        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.Search(txtSearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
