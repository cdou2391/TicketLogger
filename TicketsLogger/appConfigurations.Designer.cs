namespace TicketsLogger
{
    partial class appConfigurations
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLogs = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panelLogs = new System.Windows.Forms.Panel();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.activityLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSmtp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLogs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelEmail.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 994);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelLogs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Margin = new System.Windows.Forms.Padding(7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 54);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // labelLogs
            // 
            this.labelLogs.AutoSize = true;
            this.labelLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogs.ForeColor = System.Drawing.Color.White;
            this.labelLogs.Location = new System.Drawing.Point(7, 7);
            this.labelLogs.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelLogs.Name = "labelLogs";
            this.labelLogs.Size = new System.Drawing.Size(81, 36);
            this.labelLogs.TabIndex = 1;
            this.labelLogs.Text = "Logs";
            this.labelLogs.Click += new System.EventHandler(this.labelLogs_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelEmail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 54);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(7, 9);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(290, 36);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email Configurations";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // panelLogs
            // 
            this.panelLogs.Controls.Add(this.txtLogs);
            this.panelLogs.Controls.Add(this.menuStrip1);
            this.panelLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogs.Location = new System.Drawing.Point(343, 0);
            this.panelLogs.Margin = new System.Windows.Forms.Padding(7);
            this.panelLogs.Name = "panelLogs";
            this.panelLogs.Size = new System.Drawing.Size(1045, 994);
            this.panelLogs.TabIndex = 2;
            // 
            // txtLogs
            // 
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogs.Location = new System.Drawing.Point(0, 49);
            this.txtLogs.Margin = new System.Windows.Forms.Padding(7);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1045, 945);
            this.txtLogs.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activityLogsToolStripMenuItem,
            this.loginLogsToolStripMenuItem,
            this.errorLogsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // activityLogsToolStripMenuItem
            // 
            this.activityLogsToolStripMenuItem.Name = "activityLogsToolStripMenuItem";
            this.activityLogsToolStripMenuItem.Size = new System.Drawing.Size(179, 41);
            this.activityLogsToolStripMenuItem.Text = "Activity Logs";
            this.activityLogsToolStripMenuItem.Click += new System.EventHandler(this.activityLogsToolStripMenuItem_Click);
            // 
            // loginLogsToolStripMenuItem
            // 
            this.loginLogsToolStripMenuItem.Name = "loginLogsToolStripMenuItem";
            this.loginLogsToolStripMenuItem.Size = new System.Drawing.Size(159, 41);
            this.loginLogsToolStripMenuItem.Text = "Login Logs";
            this.loginLogsToolStripMenuItem.Click += new System.EventHandler(this.loginLogsToolStripMenuItem_Click);
            // 
            // errorLogsToolStripMenuItem
            // 
            this.errorLogsToolStripMenuItem.Name = "errorLogsToolStripMenuItem";
            this.errorLogsToolStripMenuItem.Size = new System.Drawing.Size(149, 41);
            this.errorLogsToolStripMenuItem.Text = "Error Logs";
            this.errorLogsToolStripMenuItem.Click += new System.EventHandler(this.errorLogsToolStripMenuItem_Click);
            // 
            // panelEmail
            // 
            this.panelEmail.Controls.Add(this.txtCompany);
            this.panelEmail.Controls.Add(this.label4);
            this.panelEmail.Controls.Add(this.txtPassword);
            this.panelEmail.Controls.Add(this.label3);
            this.panelEmail.Controls.Add(this.txtEmail);
            this.panelEmail.Controls.Add(this.label2);
            this.panelEmail.Controls.Add(this.btnUpdate);
            this.panelEmail.Controls.Add(this.button1);
            this.panelEmail.Controls.Add(this.cmdSmtp);
            this.panelEmail.Controls.Add(this.label1);
            this.panelEmail.Controls.Add(this.menuStrip2);
            this.panelEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEmail.Location = new System.Drawing.Point(343, 532);
            this.panelEmail.Margin = new System.Windows.Forms.Padding(7);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(1045, 462);
            this.panelEmail.TabIndex = 3;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(211, 63);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(446, 35);
            this.txtCompany.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Company:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(211, 209);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(446, 35);
            this.txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(211, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(446, 35);
            this.txtEmail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(730, 381);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(288, 52);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Configurations";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 74);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSmtp
            // 
            this.cmdSmtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSmtp.FormattingEnabled = true;
            this.cmdSmtp.Items.AddRange(new object[] {
            "Office 365",
            "Gmail"});
            this.cmdSmtp.Location = new System.Drawing.Point(211, 112);
            this.cmdSmtp.Name = "cmdSmtp";
            this.cmdSmtp.Size = new System.Drawing.Size(446, 37);
            this.cmdSmtp.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "SMTP Server:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.menuStrip2.Size = new System.Drawing.Size(1045, 49);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(276, 41);
            this.toolStripMenuItem1.Text = "Email Configurations";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(41, 913);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 51);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // appConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 994);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.panelLogs);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "appConfigurations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "appConfigurations";
            this.Load += new System.EventHandler(this.appConfigurations_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelLogs.ResumeLayout(false);
            this.panelLogs.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelLogs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Panel panelLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem activityLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLogsToolStripMenuItem;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox cmdSmtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
    }
}