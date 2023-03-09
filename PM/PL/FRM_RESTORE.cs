using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PM.PL
{
    public partial class FRM_RESTORE : Form
    {
        SqlConnection con = new SqlConnection("server=ABDULRAHMAN; Database=master; Integrated Security = true");
        SqlCommand cmd;
        public FRM_RESTORE()
        {
            InitializeComponent();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileN.Text = openFileDialog1.FileName;
            }
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            string strquery = "ALTER Database SMA set OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database SMA From Disk= '" + txtFileN.Text + "'";
            cmd = new SqlCommand(strquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم استعادة نسخة بنجاح ", "استعادة نسخة احتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
