using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Account_Registration
{
    public partial class FrmConfirm : Form
    {
        private StudentInfoClass.DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;
        private StudentInfoClass.DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;

        public FrmConfirm()
        {
            InitializeComponent();
            DelProgram = new StudentInfoClass.DelegateText(StudentInfoClass.GetProgram);
            DelLastName = new StudentInfoClass.DelegateText(StudentInfoClass.GetLastName);
            DelFirstName = new StudentInfoClass.DelegateText(StudentInfoClass.GetFirstName);
            DelMiddleName = new StudentInfoClass.DelegateText(StudentInfoClass.GetMiddleName);
            DelAddress = new StudentInfoClass.DelegateText(StudentInfoClass.GetAddress);
            DelNumAge = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetAge);
            DelNumContactNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetContactNo);
            DelStudNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetStudentNo);
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            lblProgram.Text = DelProgram();
            lblLastName.Text = DelLastName();
            lblFirstName.Text = DelFirstName();
            lblMiddleName.Text = DelMiddleName();
            lblAddress.Text = DelAddress();
            lblAge.Text = DelNumAge().ToString();
            lblContactNo.Text = DelNumContactNo().ToString();
            lblStudentNo.Text = DelStudNo().ToString();
        }

        private bool isSubmitted = false;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration completed.", "Success",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            isSubmitted = true;
            this.Close();


        }

        private void FrmConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = isSubmitted ? DialogResult.OK : DialogResult.Cancel; // clear all fields if user submit it properly not closed by X without clicking submit.
        }
    }
}
