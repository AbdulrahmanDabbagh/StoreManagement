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
    public partial class FRM_CATEGORES : Form
    {
        SqlConnection sqlcon = new SqlConnection("server=ABDULRAHMAN; Database=SMA; Integrated Security = true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmbd;
        public FRM_CATEGORES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select ID_CAT as 'المعرف' , DESCREPTION_CAT as 'الصنف'  from CATEGORIES", sqlcon);
            da.Fill(dt);
            DGList.DataSource = dt;
            txtID.DataBindings.Add("text", dt, "المعرف");
            txtDES.DataBindings.Add("text", dt, "الصنف");
            bmb = this.BindingContext[dt];
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count-1;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bmb.Position +=1;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            bmb.Position -=1;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnADD.Enabled = true;
            int id ;
            try
            {
                id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            }
            catch
            {
                id = 1;
            }
            txtID.Text = id.ToString();
            txtDES.Focus();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (txtDES.Text == "")
            {
                MessageBox.Show("ادخل اسم للصنف", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bmb.EndCurrentEdit();
                cmbd = new SqlCommandBuilder(da);
                da.Update(dt);
                MessageBox.Show("تمت الاضافة بنجاح", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnADD.Enabled = false;
                btnNew.Enabled = true;
                lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmbd = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmbd = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnADD.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }
    }
}
