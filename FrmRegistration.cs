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

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs error)//txtStudentNo will accepts numbers only
        {
            if (!char.IsDigit(error.KeyChar) && !char.IsControl(error.KeyChar))
                error.Handled = true;
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs error)//txtAge will accepts numbers only
        {
            if (!char.IsDigit(error.KeyChar) && !char.IsControl(error.KeyChar))
                error.Handled = true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs error)//txtContactNo will accepts numbers only
        {
            if (!char.IsDigit(error.KeyChar) && !char.IsControl(error.KeyChar))
                error.Handled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentNo.Text) ||string.IsNullOrEmpty(cbProgram.Text) ||
        string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtFirstName.Text) ||
        string.IsNullOrEmpty(txtMiddleName.Text) ||string.IsNullOrEmpty(txtAge.Text) ||
        string.IsNullOrEmpty(txtContactNo.Text) ||string.IsNullOrEmpty(txtAddress.Text)) //input validations if may blank na field
            {
                MessageBox.Show("Please fill up all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StudentInfoClass.StudentNo = long.Parse(txtStudentNo.Text);
            StudentInfoClass.Program = cbProgram.Text;
            StudentInfoClass.LastName = txtLastName.Text;
            StudentInfoClass.FirstName = txtFirstName.Text;
            StudentInfoClass.MiddleName = txtMiddleName.Text;
            StudentInfoClass.Age = long.Parse(txtAge.Text);
            StudentInfoClass.ContactNo = long.Parse(txtContactNo.Text);
            StudentInfoClass.Address = txtAddress.Text;

            FrmConfirm frmConfirm = new FrmConfirm(); // call the frmConfirm


            if (frmConfirm.ShowDialog() == DialogResult.OK) //if na close yung frmConfirm via submit or clicking ok button sa messageBox,
            {                                               //then mag re-reset lahat ng fields
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
