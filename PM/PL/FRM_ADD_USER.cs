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
    public partial class FRM_ADD_USER : Form
    {
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtPWD.Text == string.Empty
                || txtPWDCon.Text == string.Empty || txtFullN.Text == string.Empty)
            {
                MessageBox.Show("الرجاء ادخال جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPWD.Text != txtPWDCon.Text)
            {
                MessageBox.Show("كلمة السر غير متطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnSave.Text == "حفظ المستخدم")
            {
                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                user.ADD_USER(txtID.Text, txtFullN.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تمت اضافة مستخدم بنجاح", "اضافة مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnSave.Text == "تعديل")
            {
                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                user.EDIT_USER(txtID.Text, txtFullN.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تم تعديل المستخدم بنجاح", "تعديل مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtFullN.Clear();
            txtID.Clear();
            txtPWD.Clear();
            txtPWDCon.Clear();
            txtID.Focus();
        }

        private void txtPWDCon_Validated(object sender, EventArgs e)
        {
            if(txtPWD.Text != txtPWDCon.Text)
            {
                MessageBox.Show("كلمة السر غير متطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
