using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using HarrDetector;
using Emgu.CV.UI;

namespace CSharpFaceOff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            FaceDetector facedetector = new FaceDetector ();
            if (dlgImagePicker.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> image=new Image<Bgr,byte>(dlgImagePicker.FileName);
                facedetector.DetectFace(image);
                facedetector.DrawObj(image);
                imageBox1.Image = image;
            }
        }
    }
}
