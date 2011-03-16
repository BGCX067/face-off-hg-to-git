using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Diagnostics;

namespace CSharpFaceOff
{
    public partial class frmFace : Form
    {
        public frmFace()
        {
            InitializeComponent();
        }
        Image<Bgr, Byte> imageDrag;
        Image<Bgr, Byte> imageShow;
        Image<Bgr, Byte> imageDroped;
        Point ptClicked=Point.Empty;

        bool bDropFrom = false;
        public Image<Bgr, Byte> Face
        {
            get
            {
                return imageShow;
            }
            set
            {
                imageShow = value;
                this.imgBoxFace.Image = value;
            }
        }

        private void imageBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (imageDrag != null)
                {
                    this.DoDragDrop(imageDrag, DragDropEffects.Move);
                    bDropFrom = true;
                }
            }
            else
            {
                bDropFrom = false;
            }
        }

        private void imageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            imageDrag = imageShow;
            ptClicked = e.Location;
            
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imgBoxFace.SetZoomScale(imgBoxFace.ZoomScale * 2, ptClicked);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imgBoxFace.SetZoomScale(imgBoxFace.ZoomScale / 2, ptClicked);
        }

        private void fitScreemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double scaleY = this.imgBoxFace.Size.Height * 1.0 / this.imageShow.Size.Height;
            double scaleX = this.imgBoxFace.Size.Width * 1.0 / this.imageShow.Size.Width;
            if (scaleX < scaleY)
            {
                this.imgBoxFace.SetZoomScale(scaleX, ptClicked);
            }
            else
            {
                this.imgBoxFace.SetZoomScale(scaleY, ptClicked);
            }
        }

        private void frmFace_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void frmFace_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void imgBoxFace_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void frmFace_MouseUp(object sender, MouseEventArgs e)
        {
        }

    }
}
