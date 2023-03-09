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
    public partial class FRM_ORDERS_LIST : Form
    {
        int reference;
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        public FRM_ORDERS_LIST()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = order.SearchOrders("");
            dataGridView1.Sort(dataGridView1.Columns[0],ListSortDirection.Ascending);
        }
        public FRM_ORDERS_LIST(int x)
        {
            reference = x;
            if (x == 1)
            {
                InitializeComponent();
                this.dataGridView1.DataSource = order.SearchOrdersR("");
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            if (x == 2)
            {
                InitializeComponent();
                this.dataGridView1.DataSource = order.SearchOrdersD("");
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            if (x == 3)
            {
                InitializeComponent();
                this.dataGridView1.DataSource = order.DestructionProcess("");
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (reference == 1)
                {
                    this.dataGridView1.DataSource = order.SearchOrdersR(textSearch.Text);
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }
                if (reference == 2)
                {
                    this.dataGridView1.DataSource = order.SearchOrdersD(textSearch.Text);
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }
                if (reference == 3)
                {
                    this.dataGridView1.DataSource = order.DestructionProcess(textSearch.Text);
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
                xcelapp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

                }

                for(int i = 0; i < dataGridView1.Rows.Count;i++)
                {
                    for(int j=0;j<dataGridView1.Columns.Count;j++)
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
