using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using System.Windows.Forms;

namespace PM.PL
{
    public partial class FRM_PRODUCTS : Form
    {
        private static FRM_PRODUCTS frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_PRODUCTS getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCTS();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();

        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = prd.SearchProduct(textSearch.Text);
            this.dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FRM_LOGIN.useradmin == true)
            {
                if (MessageBox.Show("هل تريد حذف المنتوج المحدد؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
                }
                else
                {
                    MessageBox.Show("تم إالغاء عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("لاتوجد لديك صلاحية لتقوم بهذا الامر", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FRM_LOGIN.useradmin == true)
            {
                FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
                frm.txtRef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.txtDes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.txtQte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.cmbCategories.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm.TBPrice.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.Text = "تحديث الصنف : " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.btnOK.Text = "تحديث";
                frm.state = "update";
                frm.txtRef.ReadOnly = true;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("لاتوجد لديك صلاحية لتقوم بهذا الامر", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
                xcelapp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                    }
                }
                xcelapp.Columns.AutoFit();
                xcelapp.Visible = true;

            }
        }
    }
}
