
namespace PM.PL
{
    partial class FRM_USERS_LIST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteUser = new System.Windows.Forms.Button();
            this.editeUser = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(122, 169);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(468, 320);
            this.dgvUsers.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mudir MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(488, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "خروج";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(283, 117);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(307, 20);
            this.textSearch.TabIndex = 7;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mudir MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(90, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "قم بإدخال الكلمة المراد البحث عنها:";
            // 
            // deleteUser
            // 
            this.deleteUser.BackColor = System.Drawing.Color.DarkGreen;
            this.deleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteUser.Font = new System.Drawing.Font("Mudir MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.deleteUser.ForeColor = System.Drawing.Color.White;
            this.deleteUser.Location = new System.Drawing.Point(361, 507);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(108, 32);
            this.deleteUser.TabIndex = 11;
            this.deleteUser.Text = "حذف مستخدم";
            this.deleteUser.UseVisualStyleBackColor = false;
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // editeUser
            // 
            this.editeUser.BackColor = System.Drawing.Color.DarkGreen;
            this.editeUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editeUser.Font = new System.Drawing.Font("Mudir MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.editeUser.ForeColor = System.Drawing.Color.White;
            this.editeUser.Location = new System.Drawing.Point(250, 507);
            this.editeUser.Name = "editeUser";
            this.editeUser.Size = new System.Drawing.Size(105, 32);
            this.editeUser.TabIndex = 12;
            this.editeUser.Text = "تعديل مستخدم";
            this.editeUser.UseVisualStyleBackColor = false;
            this.editeUser.Click += new System.EventHandler(this.editeUser_Click);
            // 
            // addUser
            // 
            this.addUser.BackColor = System.Drawing.Color.DarkGreen;
            this.addUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUser.Font = new System.Drawing.Font("Mudir MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.addUser.ForeColor = System.Drawing.Color.White;
            this.addUser.Location = new System.Drawing.Point(138, 507);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(103, 32);
            this.addUser.TabIndex = 13;
            this.addUser.Text = "اضافة مستخدم ";
            this.addUser.UseVisualStyleBackColor = false;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // FRM_USERS_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 710);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.editeUser);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_USERS_LIST";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ادارة المستخدمون";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.Button editeUser;
        private System.Windows.Forms.Button addUser;
    }
}