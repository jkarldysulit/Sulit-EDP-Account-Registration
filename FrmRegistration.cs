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

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
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
            if (string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                cbProgram.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtContactNo.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtStudentNo.Text, out long studentNo))
            {
                MessageBox.Show("Student No. must be a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentNo.Focus();
                return;
            }

            if (!long.TryParse(txtAge.Text, out long age) || age <= 0 || age > 160)
            {
                MessageBox.Show("Age must be a valid number", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            if (!long.TryParse(txtContactNo.Text, out long contactNo))
            {
                MessageBox.Show("Contact No. must be a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return;
            }

            try
            {
                StudentInfoClass.StudentNo = studentNo;
                StudentInfoClass.Program = cbProgram.Text;
                StudentInfoClass.LastName = txtLastName.Text;
                StudentInfoClass.FirstName = txtFirstName.Text;
                StudentInfoClass.MiddleName = txtMiddleName.Text;
                StudentInfoClass.Age = age;
                StudentInfoClass.ContactNo = contactNo;
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
