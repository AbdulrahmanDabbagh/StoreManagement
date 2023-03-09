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
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLC_CUSTOMERS cust = new BL.CLC_CUSTOMERS();
        int ID , Position;
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            dgList.Columns[0].Visible = false;
            btnDelete.Enabled = false;
            btnADD.Enabled = false;
            btnEdit.Enabled = false;
            lblPosition.Text = "0/" + cust.GET_ALL_CUSTOMERS().Rows.Count;
            
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                cust.ADD_CUSTOMERS(txtFirstName.Text, txtLastName.Text);
                MessageBox.Show("تمت الاضافة بنجاح", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            }
            catch
            {
                return;
            }
            btnADD.Enabled = false;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnADD.Enabled = true;
            btnEdit.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnADD.Focus();
            }
        }

        private void dgList_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            lblPosition.Text = (dgList.CurrentCell.RowIndex+1).ToString() +"/"+ cust.GET_ALL_CUSTOMERS().Rows.Count;

            try
            {
                ID = Convert.ToInt32(dgList.CurrentRow.Cells[0].Value);
                this.txtFirstName.Text = dgList.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dgList.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cust.EDIT_CUSTOMERS(txtFirstName.Text, txtLastName.Text,ID);
                MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            }
            catch
            {
                return;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد فعلا حذف العميل", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DElETE_CUSTOMER_CUSTOMERS(ID);
                MessageBox.Show("تم الحذف بنجاح", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgList.DataSource = cust.Search_Customer(txtSearch.Text);

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        void Navigate(int Index)
        {
            
            DataRowCollection DRC = cust.GET_ALL_CUSTOMERS().Rows;
            ID = Convert.ToInt32(DRC[Index][0]);
            txtFirstName.Text = DRC[Index][1].ToString();
            txtLastName.Text = DRC[Index][2].ToString();
            lblPosition.Text = (Position + 1).ToString()+"/"+ cust.GET_ALL_CUSTOMERS().Rows.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            Navigate(0);
            lblPosition.Text = "1" + "/" + cust.GET_ALL_CUSTOMERS().Rows.Count;
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            if (Position == 0)
            {
                Navigate(Position);
            }
            else
            {
                Position -= 1;
                Navigate(Position);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            if (Position == cust.GET_ALL_CUSTOMERS().Rows.Count-1)
            {
                Navigate(Position);
            }
            else
            {
                Position += 1;
                Navigate(Position);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            Position = cust.GET_ALL_CUSTOMERS().Rows.Count - 1;
            Navigate(Position);
        }
    }

}
