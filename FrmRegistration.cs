using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Account_Registration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            ArrayList programList = new ArrayList();
            programList.Add("BS Information Technology");
            programList.Add("BS Computer Engineering");
            programList.Add("BS Computer Science");
            programList.Add("BS Psychology");
            programList.Add("BS Tourism");
            programList.Add("BS Criminology");

            cbProgram.Items.AddRange(programList.ToArray());
        }

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs error)
        {
            if (!char.IsDigit(error.KeyChar) && !char.IsControl(error.KeyChar))
                error.Handled = true;
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            StudentInfoClass.StudentNo = long.Parse(txtStudentNo.Text);
            StudentInfoClass.Program = cbProgram.Text;
            StudentInfoClass.LastName = txtLastName.Text;
            StudentInfoClass.FirstName = txtFirstName.Text;
            StudentInfoClass.MiddleName = txtMiddleName.Text;
            StudentInfoClass.Age = long.Parse(txtAge.Text);
            StudentInfoClass.ContactNo = long.Parse(txtContactNo.Text);
            StudentInfoClass.Address = txtAddress.Text;

            FrmConfirm frmConfirm = new FrmConfirm();
            if (frmConfirm.ShowDialog() == DialogResult.OK)
            {
                txtStudentNo.Clear();
                cbProgram.SelectedIndex = -1;
                txtLastName.Clear();
                txtFirstName.Clear();
                txtMiddleName.Clear();
                txtAge.Clear();
                txtContactNo.Clear();
                txtAddress.Clear();
            }
        }
    }
}
