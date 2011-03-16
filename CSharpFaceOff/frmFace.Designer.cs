namespace CSharpFaceOff
{
    partial class frmFace
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
            this.components = new System.ComponentModel.Container();
            this.imgBoxFace = new Emgu.CV.UI.ImageBox();
            this.cMouseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitScreemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxFace)).BeginInit();
            this.cMouseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBoxFace
            // 
            this.imgBoxFace.ContextMenuStrip = this.cMouseMenu;
            this.imgBoxFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBoxFace.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxFace.Location = new System.Drawing.Point(0, 0);
            this.imgBoxFace.Name = "imgBoxFace";
            this.imgBoxFace.Size = new System.Drawing.Size(277, 306);
            this.imgBoxFace.TabIndex = 2;
            this.imgBoxFace.TabStop = false;
            this.imgBoxFace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseDown);
            this.imgBoxFace.MouseLeave += new System.EventHandler(this.imageBox1_MouseLeave);
            this.imgBoxFace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            this.imgBoxFace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBoxFace_MouseUp);
            // 
            // cMouseMenu
            // 
            this.cMouseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.cMouseMenu.Name = "cMouseMenu";
            this.cMouseMenu.Size = new System.Drawing.Size(95, 48);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem1,
            this.zoomOutToolStripMenuItem,
            this.fitScreemToolStripMenuItem});
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem1
            // 
            this.zoomInToolStripMenuItem1.Name = "zoomInToolStripMenuItem1";
            this.zoomInToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.zoomInToolStripMenuItem1.Text = "Zoom In";
            this.zoomInToolStripMenuItem1.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // fitScreemToolStripMenuItem
            // 
            this.fitScreemToolStripMenuItem.Name = "fitScreemToolStripMenuItem";
            this.fitScreemToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fitScreemToolStripMenuItem.Text = "Fit screem";
            this.fitScreemToolStripMenuItem.Click += new System.EventHandler(this.fitScreemToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOriginalToolStripMenuItem,
            this.saveViewToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveOriginalToolStripMenuItem
            // 
            this.saveOriginalToolStripMenuItem.Name = "saveOriginalToolStripMenuItem";
            this.saveOriginalToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveOriginalToolStripMenuItem.Text = "Save Original";
            // 
            // saveViewToolStripMenuItem
            // 
            this.saveViewToolStripMenuItem.Name = "saveViewToolStripMenuItem";
            this.saveViewToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveViewToolStripMenuItem.Text = "Save View";
            // 
            // frmFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 306);
            this.Controls.Add(this.imgBoxFace);
            this.Name = "frmFace";
            this.Text = "frmFace";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmFace_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmFace_DragEnter);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmFace_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxFace)).EndInit();
            this.cMouseMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBoxFace;
        private System.Windows.Forms.ContextMenuStrip cMouseMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitScreemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveViewToolStripMenuItem;
    }
}