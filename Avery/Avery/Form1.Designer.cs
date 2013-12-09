namespace Avery
{
    partial class MainTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTool));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtUrl = new System.Windows.Forms.ToolStripTextBox();
            this.btnStartProcessing = new System.Windows.Forms.ToolStripButton();
            this.btnShowSelectionForm = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtUrl,
            this.btnStartProcessing,
            this.btnShowSelectionForm});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1181, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtUrl
            // 
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(700, 25);
            // 
            // btnStartProcessing
            // 
            this.btnStartProcessing.AutoSize = false;
            this.btnStartProcessing.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnStartProcessing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStartProcessing.Image = ((System.Drawing.Image)(resources.GetObject("btnStartProcessing.Image")));
            this.btnStartProcessing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(50, 22);
            this.btnStartProcessing.Text = "GO";
            this.btnStartProcessing.Click += new System.EventHandler(this.btnStartProcessing_Click);
            // 
            // btnShowSelectionForm
            // 
            this.btnShowSelectionForm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowSelectionForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowSelectionForm.Enabled = false;
            this.btnShowSelectionForm.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSelectionForm.Image")));
            this.btnShowSelectionForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowSelectionForm.Name = "btnShowSelectionForm";
            this.btnShowSelectionForm.Size = new System.Drawing.Size(76, 22);
            this.btnShowSelectionForm.Text = "Select Again";
            this.btnShowSelectionForm.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1181, 695);
            this.webBrowser1.TabIndex = 1;
            // 
            // MainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 720);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtUrl;
        private System.Windows.Forms.ToolStripButton btnStartProcessing;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripButton btnShowSelectionForm;
    }
}

