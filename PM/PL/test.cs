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
    public partial class test : Form
    {
        //single instance
        private static test frm;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static test getMainFormT
        {
            get
            {
                if (frm == null)
                {
                    frm = new test();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        public test()
        {
            InitializeComponent();
            customizeDesign();
            if (frm == null)
            {
                frm = this;
            }
            this.btnCat.Enabled = false;
            this.btnCust.Enabled = false;
            this.btnUser.Enabled = false;
            this.btnCreate.Enabled = false;
            this.btnRestore.Enabled = false;
            openChildForm(new FRM_LOGIN());
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        
        private void customizeDesign()
        {
            panelFile.Visible = false;
            panelCat.Visible = false;
            panelCust.Visible = false;
            panelUser.Visible = false;

        }
        private void hideSubMenu()
        {
            if (panelFile.Visible == true)
            {
                panelFile.Visible = false;
            }
            if (panelCat.Visible == true)
            {
                panelCat.Visible = false;
            }
            if (panelCust.Visible == true)
            {
                panelCust.Visible = false;
            }
            if (panelUser.Visible == true)
            {
                panelUser.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_LOGIN());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_BACKUP());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_RESTORE());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCat);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ADD_PRODUCT());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_PRODUCTS());
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_CATEGORES());
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCust);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_CUSTOMERS());
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ORDERS());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ORDERS_LIST(1));
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showSubMenu(panelUser);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ADD_USER());
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_USERS_LIST());
            hideSubMenu();
        }
        private Form activeForm = null;
        public void openChildForm(Form childeForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childeForm;
            childeForm.TopLevel = false;
            childeForm.FormBorderStyle = FormBorderStyle.None;
            panelChilde.Controls.Add(childeForm);
            panelChilde.Tag = childeForm;
            childeForm.BringToFront();
            childeForm.Show();
        }
        public void openChildForm2(Form childeForm)
        {
            activeForm = childeForm;
            childeForm.TopLevel = false;
            childeForm.FormBorderStyle = FormBorderStyle.None;
            panelChilde.Controls.Add(childeForm);
            panelChilde.Tag = childeForm;
            childeForm.BringToFront();
            childeForm.Show();
        }
        private void panelBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                mouseX = MousePosition.X - 352;
                mouseY = MousePosition.Y - 27;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ORDERS(1));
            hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ORDERS_LIST(2));
            hideSubMenu();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //code
            openChildForm(new FRM_ORDERS_LIST(3));
            hideSubMenu();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FRM_CONFIG());
            hideSubMenu();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
