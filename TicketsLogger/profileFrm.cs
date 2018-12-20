using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    public partial class profileFrm : Form
    {
        public profileFrm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void profileFrm_Load(object sender, EventArgs e)
        {
            txtName.Text = Global.Staff.Name;
            txtSurname.Text = Global.Staff.Surname;
            txtStaffID.Text = Global.Staff.ID;
            //txtPhoneNum.Text=Global.Staff.
            txtDept.Text = Global.Staff.Department;
            txtUnit.Text = Global.Staff.Unit;
            txtEmail.Text = Global.Staff.Email;
        }
    }
}
