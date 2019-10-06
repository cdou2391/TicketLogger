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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmail = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 872);
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
            this.panelLogs.Size = new System.Drawing.Size(1045, 872);
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
            this.txtLogs.Size = new System.Drawing.Size(1045, 823);
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
            this.panelEmail.Controls.Add(this.btnEmail);
            this.panelEmail.Controls.Add(this.menuStrip2);
            this.panelEmail.Controls.Add(this.textBox1);
            this.panelEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEmail.Location = new System.Drawing.Point(343, 410);
            this.panelEmail.Margin = new System.Windows.Forms.Padding(7);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(1045, 462);
            this.panelEmail.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1045, 462);
            this.textBox1.TabIndex = 1;
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
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(326, 193);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(233, 74);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "test email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // appConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 872);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.panelLogs);
            this.Controls.Add(this.panel1);
            this.Name = "appConfigurations";
            this.Text = "appConfigurations";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnEmail;
    }
}