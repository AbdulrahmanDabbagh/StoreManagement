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
    public partial class FRM_LOGIN : Form
    {
        public static bool useradmin = false;
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGING(txtID.Text, txtPWD.Text);
            if(Dt.Rows.Count>0)
            {
                if (Dt.Rows[0][2].ToString() == "مدير")
                {
                    useradmin = true;

                    test.getMainFormT.btnCreate.Enabled = true;
                    test.getMainFormT.btnRestore.Enabled = true;
                    test.getMainFormT.btnCat.Enabled = true;
                    test.getMainFormT.btnCust.Enabled = true;
                    test.getMainFormT.btnUser.Enabled = true;
                    test.getMainFormT.button4.Enabled = true;
                    test.getMainFormT.button12.Enabled = true;
                    test.getMainFormT.button13.Enabled = true;
                    //  FRM_MAIN.getMainForm.المنتوجاتToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.إنشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    // FRM_MAIN.getMainForm.تسجيلالخروجToolStripMenuItem.Enabled = true;
                    // FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Visible = true;
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                    test.getMainFormT.openChildForm(new FRM_ORDERS());
                }
                else if(Dt.Rows[0][2].ToString() == "عادي")
                {
                    useradmin = false;
                    test.getMainFormT.btnCat.Enabled = true;
                    test.getMainFormT.btnCust.Enabled = true;
                    test.getMainFormT.btnUser.Enabled = false;
                    test.getMainFormT.btnCreate.Enabled = true;
                    test.getMainFormT.btnRestore.Enabled = false;
                    test.getMainFormT.button4.Enabled = true;
                    test.getMainFormT.button12.Enabled = true;
                    test.getMainFormT.button13.Enabled = true;
                    /*FRM_MAIN.getMainForm.المنتوجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.إنشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.تسجيلالخروجToolStripMenuItem.Enabled = true;*/
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                    test.getMainFormT.openChildForm(new FRM_ORDERS());

                }
                else if (Dt.Rows[0][2].ToString() == "مالية")
                {
                    useradmin = false;
                    test.getMainFormT.btnCat.Enabled = false;
                    test.getMainFormT.btnCust.Enabled = true;
                    test.getMainFormT.btnUser.Enabled = false;
                    test.getMainFormT.btnCreate.Enabled = true;
                    test.getMainFormT.btnRestore.Enabled = false;
                    test.getMainFormT.button4.Enabled = false;
                    test.getMainFormT.button12.Enabled = false;
                    test.getMainFormT.button13.Enabled = false;
                    /*FRM_MAIN.getMainForm.المنتوجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.إنشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.تسجيلالخروجToolStripMenuItem.Enabled = true;*/
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
                    test.getMainFormT.openChildForm(new FRM_ORDERS_LIST(1));
                }

            }
            else
            {
                MessageBox.Show("Login failed !");
            }
        }

        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
