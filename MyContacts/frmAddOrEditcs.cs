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
    public partial class frmAddOrEditcs : Form
    {
        IContactsRepository repository;
        public int contactID = 0;
        public frmAddOrEditcs()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void frmAddOrEditcs_Load(object sender, EventArgs e)
        {

            if (contactID == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = repository.SelectRow(contactID);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtEmail.Text = dt.Rows[0][3].ToString();
                txtAddress.Text = dt.Rows[0][4].ToString();
                txtMobile.Text = dt.Rows[0][5].ToString();
                txtAge.Text = dt.Rows[0][6].ToString();
                button1.Text = "ویرایش";
            }
        }

        bool ValidateInputs()
        {

            if (txtName.Text == "")
            {

                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {

                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {

                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {

                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {

                MessageBox.Show("لطفا موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess;
                if (contactID == 0)
                {
                    isSuccess = repository.Insert(txtName.Text, txtFamily.Text, txtEmail.Text, txtAddress.Text, txtMobile.Text, (int)txtAge.Value);
                }
                else
                {
                    isSuccess = repository.Update(contactID,txtName.Text, txtFamily.Text, txtEmail.Text, txtAddress.Text, txtMobile.Text, (int)txtAge.Value);
                }

                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت مواجه شد ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }







            }
        }
    }
}

