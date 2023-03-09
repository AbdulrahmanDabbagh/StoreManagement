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
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        DataTable dt = new DataTable();
        void ClearBoxes()
        {
            txtIDProducts.Clear();
            txtNameP.Clear();
            txtQte.Clear();
            btnBrowse.Focus();
        }
        void ClearData()
        {
            txtOrderID.Clear();
            txtDesOrder.Clear();
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            dtOrder.ResetText();
            ClearBoxes();
            dt.Clear();
            dgvProducts.DataSource = null;
            btnADD.Enabled = false;
            btnNew.Enabled = true;
        }
        void CreateDataTable()
        {
            dt.Columns.Add("معرف المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("الكمية");
            dgvProducts.DataSource = dt;
        }
        void ResizeDGV()
        {
            this.dgvProducts.RowHeadersWidth = 103;
        }
        public FRM_ORDERS()
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtSM.Text = Program.SalesMan;

        }

        public FRM_ORDERS(int x)
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtSM.Text = Program.SalesMan;
            txtCustomerID.Hide();
            txtCustomerID.Text = "1015";
            button1.Hide();
            txtFirstName.Hide();
            txtFirstName.Text = "عملية";
            txtLastName.Hide();
            txtLastName.Text = "اتلاف";
            cbType.SelectedIndex = cbType.FindStringExact("تسليم");
            cbType.Enabled = false;
            label1.Hide();
            label2.Hide();
            label3.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnNew.Enabled = false;
            btnADD.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            this.txtCustomerID.Text = frm.dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            this.txtFirstName.Text = frm.dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            this.txtLastName.Text = frm.dgvCustomer.CurrentRow.Cells[2].Value.ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClearBoxes();
            test frm1 = new test();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            //frm.ShowDialog();
            frm1.openChildForm2(frm);
            txtIDProducts.Text = frm.dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtNameP.Text = frm.dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtQte.Focus();
        }

        private void txtQte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!=8)
            {
                e.Handled = true;

            }
        }

        private void txtQte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtQte.Text))
            {
                if (order.VerifyQty(txtIDProducts.Text, Convert.ToInt32(txtQte.Text)).Rows.Count < 1 && cbType.Text!= "استلام")
                {

                    MessageBox.Show("غير متوفرة " + txtIDProducts.Text + " الكمية المدخلة للمنتج", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                for (int i=0; i <dgvProducts.Rows.Count-1;i++)
                {
                    if(dgvProducts.Rows[i].Cells[0].Value.ToString()==txtIDProducts.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                DataRow r = dt.NewRow();
                r[0] = txtIDProducts.Text;
                r[1] = txtNameP.Text;
                r[2] = txtQte.Text;
                dt.Rows.Add(r);

                dgvProducts.DataSource = dt;

                ClearBoxes();
            } 
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIDProducts.Text = this.dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtNameP.Text = this.dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtQte.Text = this.dgvProducts.CurrentRow.Cells[2].Value.ToString();
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                txtQte.Focus();
            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
            }
            catch
            {
                return;
            }

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            dt.Clear();
            dgvProducts.Refresh();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if(txtOrderID.Text==string.Empty || txtCustomerID.Text == string.Empty || dgvProducts.Rows.Count<1 || txtDesOrder.Text== string.Empty || cbType.Text == string.Empty)
            {
                MessageBox.Show("ينبغي تسجيل المعلومات اعلاه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtOrder.Value, Convert.ToInt32(txtCustomerID.Text),
                            txtDesOrder.Text, txtSM.Text, cbType.Text);
            for (int i = 0; i <dgvProducts.Rows.Count-1; i++)
            {
                order.ADD_ORDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                                        Convert.ToInt32(txtOrderID.Text),
                                        Convert.ToInt32( dgvProducts.Rows[i].Cells[2].Value)
                                        ,cbType.Text);
            }
            MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
