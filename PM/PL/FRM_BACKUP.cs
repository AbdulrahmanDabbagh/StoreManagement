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
    public partial class FRM_BACKUP : Form
    {
        SqlConnection con = new SqlConnection("server=ABDULRAHMAN; Database=SMA; Integrated Security = true");
        SqlCommand cmd;
        public FRM_BACKUP()
        {
            InitializeComponent();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                txtFileN.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            string filename = txtFileN.Text + "\\SMA - "+DateTime.Now.ToShortDateString().Replace('/','-')+"-"+DateTime.Now.ToShortTimeString().Replace(':','-');
            string strquery = "Backup Database SMA to Disk= '"+filename+".bak'";
            cmd = new SqlCommand(strquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم انشاء نسخة بنجاح ", "انشاء نسخة احتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
