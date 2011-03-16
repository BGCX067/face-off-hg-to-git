namespace CSharpFaceOff
{
    partial class frmMain
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
            this.btnRun = new System.Windows.Forms.Button();
            this.dlgImagePicker = new System.Windows.Forms.OpenFileDialog();
            this.imgboxBackground = new Emgu.CV.UI.ImageBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAnImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imgboxFore = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxBackground)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxFore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(430, 384);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dlgImagePicker
            // 
            this.dlgImagePicker.FileName = "*.jpg";
            this.dlgImagePicker.Filter = "jpg file(*.jpg)|*.jpg";
            this.dlgImagePicker.RestoreDirectory = true;
            // 
            // imgboxBackground
            // 
            this.imgboxBackground.Location = new System.Drawing.Point(12, 27);
            this.imgboxBackground.Name = "imgboxBackground";
            this.imgboxBackground.Size = new System.Drawing.Size(412, 380);
            this.imgboxBackground.TabIndex = 2;
            this.imgboxBackground.TabStop = false;
            this.imgboxBackground.DragDrop += new System.Windows.Forms.DragEventHandler(this.imgboxDraging_DragDrop);
            this.imgboxBackground.DragEnter += new System.Windows.Forms.DragEventHandler(this.imgboxDraging_DragEnter);
            this.imgboxBackground.DragOver += new System.Windows.Forms.DragEventHandler(this.imgboxDraging_DragOver);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(511, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgSaveImage
            // 
            this.dlgSaveImage.FileName = "*.jpg";
            this.dlgSaveImage.Filter = "jpg image(*.jpg)|*.jpg";
            this.dlgSaveImage.RestoreDirectory = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadAnImageToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadAnImageToolStripMenuItem
            // 
            this.loadAnImageToolStripMenuItem.Name = "loadAnImageToolStripMenuItem";
            this.loadAnImageToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.loadAnImageToolStripMenuItem.Text = "Open";
            this.loadAnImageToolStripMenuItem.Click += new System.EventHandler(this.loadAnImageToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.saveToolStripMenuItem.Text = "Detect";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // imgboxFore
            // 
            this.imgboxFore.Location = new System.Drawing.Point(430, 29);
            this.imgboxFore.Name = "imgboxFore";
            this.imgboxFore.Size = new System.Drawing.Size(342, 349);
            this.imgboxFore.TabIndex = 2;
            this.imgboxFore.TabStop = false;
            this.imgboxFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgboxFore_MouseDown);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 476);
            this.Controls.Add(this.imgboxFore);
            this.Controls.Add(this.imgboxBackground);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Face off";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.frmMain_DragOver);
            this.DragLeave += new System.EventHandler(this.frmMain_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.imgboxBackground)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxFore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.OpenFileDialog dlgImagePicker;
        private Emgu.CV.UI.ImageBox imgboxBackground;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog dlgSaveImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAnImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private Emgu.CV.UI.ImageBox imgboxFore;
    }
}

