namespace fromstretching
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enhanceBrightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseBrightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gAMMAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.opToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.opToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.opToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gamma1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamma2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enhanceBrightnessToolStripMenuItem,
            this.decreaseBrightnessToolStripMenuItem,
            this.gAMMAToolStripMenuItem,
            this.stretchingToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // enhanceBrightnessToolStripMenuItem
            // 
            this.enhanceBrightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opToolStripMenuItem,
            this.opToolStripMenuItem1});
            this.enhanceBrightnessToolStripMenuItem.Name = "enhanceBrightnessToolStripMenuItem";
            this.enhanceBrightnessToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enhanceBrightnessToolStripMenuItem.Text = "Increase Brightness";
            // 
            // decreaseBrightnessToolStripMenuItem
            // 
            this.decreaseBrightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opToolStripMenuItem2,
            this.opToolStripMenuItem3});
            this.decreaseBrightnessToolStripMenuItem.Name = "decreaseBrightnessToolStripMenuItem";
            this.decreaseBrightnessToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.decreaseBrightnessToolStripMenuItem.Text = "Decrease Brightness";
            // 
            // gAMMAToolStripMenuItem
            // 
            this.gAMMAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamma1ToolStripMenuItem,
            this.gamma2ToolStripMenuItem});
            this.gAMMAToolStripMenuItem.Name = "gAMMAToolStripMenuItem";
            this.gAMMAToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.gAMMAToolStripMenuItem.Text = "Gamma";
            // 
            // stretchingToolStripMenuItem
            // 
            this.stretchingToolStripMenuItem.Name = "stretchingToolStripMenuItem";
            this.stretchingToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.stretchingToolStripMenuItem.Text = "Stretching";
            this.stretchingToolStripMenuItem.Click += new System.EventHandler(this.stretchingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // opToolStripMenuItem
            // 
            this.opToolStripMenuItem.Name = "opToolStripMenuItem";
            this.opToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opToolStripMenuItem.Text = "+ op";
            this.opToolStripMenuItem.Click += new System.EventHandler(this.opToolStripMenuItem_Click);
            // 
            // opToolStripMenuItem1
            // 
            this.opToolStripMenuItem1.Name = "opToolStripMenuItem1";
            this.opToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.opToolStripMenuItem1.Text = "* op";
            this.opToolStripMenuItem1.Click += new System.EventHandler(this.opToolStripMenuItem1_Click);
            // 
            // opToolStripMenuItem2
            // 
            this.opToolStripMenuItem2.Name = "opToolStripMenuItem2";
            this.opToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.opToolStripMenuItem2.Text = "- op";
            this.opToolStripMenuItem2.Click += new System.EventHandler(this.opToolStripMenuItem2_Click);
            // 
            // opToolStripMenuItem3
            // 
            this.opToolStripMenuItem3.Name = "opToolStripMenuItem3";
            this.opToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.opToolStripMenuItem3.Text = "/ op";
            this.opToolStripMenuItem3.Click += new System.EventHandler(this.opToolStripMenuItem3_Click);
            // 
            // gamma1ToolStripMenuItem
            // 
            this.gamma1ToolStripMenuItem.Name = "gamma1ToolStripMenuItem";
            this.gamma1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gamma1ToolStripMenuItem.Text = "Gamma1";
            this.gamma1ToolStripMenuItem.Click += new System.EventHandler(this.gamma1ToolStripMenuItem_Click);
            // 
            // gamma2ToolStripMenuItem
            // 
            this.gamma2ToolStripMenuItem.Name = "gamma2ToolStripMenuItem";
            this.gamma2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gamma2ToolStripMenuItem.Text = "Gamma2";
            this.gamma2ToolStripMenuItem.Click += new System.EventHandler(this.gamma2ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enhanceBrightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseBrightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gAMMAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem gamma1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamma2ToolStripMenuItem;
    }
}

