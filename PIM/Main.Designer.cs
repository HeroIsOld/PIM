namespace PIM
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.销售ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.销售ToolStripMenuItem,
            this.入库ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.报表ToolStripMenuItem,
            this.备份ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 销售ToolStripMenuItem
            // 
            this.销售ToolStripMenuItem.Name = "销售ToolStripMenuItem";
            this.销售ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.销售ToolStripMenuItem.Text = "销售";
            this.销售ToolStripMenuItem.Visible = false;
            this.销售ToolStripMenuItem.Click += new System.EventHandler(this.销售ToolStripMenuItem_Click);
            // 
            // 入库ToolStripMenuItem
            // 
            this.入库ToolStripMenuItem.Name = "入库ToolStripMenuItem";
            this.入库ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.入库ToolStripMenuItem.Text = "入库";
            this.入库ToolStripMenuItem.Visible = false;
            this.入库ToolStripMenuItem.Click += new System.EventHandler(this.入库ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.产品信息ToolStripMenuItem,
            this.员工ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            this.配置ToolStripMenuItem.Visible = false;
            // 
            // 产品信息ToolStripMenuItem
            // 
            this.产品信息ToolStripMenuItem.Name = "产品信息ToolStripMenuItem";
            this.产品信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.产品信息ToolStripMenuItem.Text = "产品信息";
            this.产品信息ToolStripMenuItem.Click += new System.EventHandler(this.产品信息ToolStripMenuItem_Click);
            // 
            // 员工ToolStripMenuItem
            // 
            this.员工ToolStripMenuItem.Name = "员工ToolStripMenuItem";
            this.员工ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.员工ToolStripMenuItem.Text = "员工";
            this.员工ToolStripMenuItem.Click += new System.EventHandler(this.员工ToolStripMenuItem_Click);
            // 
            // 报表ToolStripMenuItem
            // 
            this.报表ToolStripMenuItem.Name = "报表ToolStripMenuItem";
            this.报表ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.报表ToolStripMenuItem.Text = "报表";
            this.报表ToolStripMenuItem.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前用户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 2;
            // 
            // 备份ToolStripMenuItem
            // 
            this.备份ToolStripMenuItem.Name = "备份ToolStripMenuItem";
            this.备份ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.备份ToolStripMenuItem.Text = "备份";
            this.备份ToolStripMenuItem.Visible = false;
            this.备份ToolStripMenuItem.Click += new System.EventHandler(this.备份ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 380);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 销售ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报表ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 产品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 员工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份ToolStripMenuItem;
    }
}