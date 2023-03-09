using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.PL
{
    public partial class FRM_USERS_LIST : Form
    {

        BL.CLS_LOGIN login = new BL.CLS_LOGIN();
        public FRM_USERS_LIST()
        {
            InitializeComponent();
            this.dgvUsers.DataSource = login.SearchUsers("");
            dgvUsers.Columns["اسم المستخدم"].Visible = false ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
            this.dgvUsers.DataSource = login.SearchUsers("");
        }

        private void editeUser_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.txtID.Text = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullN.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            frm.txtPWD.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.txtPWDCon.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.cmbType.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            frm.btnSave.Text = "تعديل";
            frm.ShowDialog();
            this.dgvUsers.DataSource = login.SearchUsers("");
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            this.dgvUsers.DataSource = login.SearchUsers(textSearch.Text);

        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل تريد حذف المستخدم؟","حذف",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                login.DELETE_USER_USER(dgvUsers.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvUsers.DataSource = login.SearchUsers("");
            }
        }
    }
}
